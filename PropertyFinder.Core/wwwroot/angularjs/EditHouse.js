var app = angular.module("myApp", []);

app.controller("myCtrl", function ($scope, $http, $filter)
{
    //an array of files selected
    $scope.files = [];

    $scope.previewData = [];
    $scope.previewData1 = [];

    $scope.originalImageData = [];

    $scope.SelectFile = function (ee)
    {
        var reader = new FileReader();
        reader.onload = function (e)
        {
            $scope.PreviewImage = e.target.result;

            $scope.previewData1.push
            ({
                'id': 2,
                'name': ee.target.files[0].name,
                'file': e.target.result
            });

            $scope.originalImageData.push
            ({
                'Name': ee.target.files[0].name,
                'File': ee.target.files[0],
                'DelStatus': false
            })

            $scope.$apply();
        };

        reader.readAsDataURL(ee.target.files[0]);
    };

    $scope.successMessage = "";

    $scope.GetAllData = function (data, addressData, houseTypeData)
    {
        $scope.originalData = data;

        $scope.Id = data.Id;
        $scope.Title = data.Title;
        $scope.Description = data.Description;
        $scope.Cost = data.Cost;
        $scope.NumberOfBedroom = data.NumberOfBedroom;

        var array = data.AvailableDate.split('/');
        $scope.AvailableDate = array[2] + "-" + array[0] + "-" + array[1];

        $scope.addrData = addressData;
        $scope.houseData = houseTypeData;

        //radio button
        if (data.IsRent == true)
        {
            $scope.radioVal = "Rent";
        }
        else
        {
            $scope.radioVal = "Buy";
        }

        //drop down
        $scope.selectedItemvalue = data.AddressInfoId;
        $scope.selectedAddress = data.AddressInfoId;

        $scope.selectedhouseItemvalue = data.HouseTypeId;
        $scope.selectedHouseType = data.HouseTypeId;

        angular.forEach(data.Photo, function (value, key)
        {
            $scope.previewData.push
            ({
                'id':1,
                'name': value.Image,
                'src': '/images/' + value.Image
            });

            $scope.originalImageData.push
            ({
                'Name': value.Image,
                'File': "",
                'DelStatus': false
            })
        }); 
    };

    $scope.removeImage = function (data)
    {
        if (data.id == 1)
        {
            var index = $scope.previewData.indexOf(data);
            $scope.previewData.splice(index, 1);

            var keyVal = 0;
            angular.forEach($scope.originalImageData, function (value, key)
            {
                if (value.Name == data.name && value.File == "" && value.DelStatus == false)
                {
                    keyVal = key; 
                }
            })

            $scope.originalImageData.splice(keyVal, 1);
            $scope.originalImageData.push
            ({
                'Name': data.name,
                'File': "",
                'DelStatus': true
            })
        }
        else
        {
            var index = $scope.previewData1.indexOf(data);
            $scope.previewData1.splice(index, 1);

            var keyVal = 0;
            angular.forEach($scope.originalImageData, function (value, key) {
                if (value.Name == data.name && value.File != "" && value.DelStatus == false)
                {
                    keyVal = key;
                }
            })

            $scope.originalImageData.splice(keyVal, 1);
        }
    };

    $scope.InsertData = function ()
    {
        var IsRent = true;
        if ($scope.radioVal == "Buy")
        {
            IsRent = false;   
        }

        console.log("imageData", $scope.originalImageData);

        $scope.ImageData = [];
        $scope.DefaultImageData = [];
        angular.forEach($scope.originalImageData, function (value, key)
        {
            if (value.File == "")
            {
                $scope.ImageData.push
                ({
                    'Name': value.Name,
                    'DelStatus': value.DelStatus
                })
            }
            else
            {
                $scope.DefaultImageData.push
                ({
                    'Name': value.Name,
                    'File': value.File
                })
            }
        })

        var data = new FormData();

        data.append("id", $scope.Id);

        data.append("title", $scope.Title);
        data.append("description", $scope.Description);
        data.append("cost", $scope.Cost);
        data.append("numberofbedroom", $scope.NumberOfBedroom);
        data.append("availabledate", $scope.AvailableDate);
        data.append("isrent", IsRent);
        data.append("addressinfoid", $scope.selectedAddress);
        data.append("housetypeid", $scope.selectedHouseType);

        angular.forEach($scope.DefaultImageData, function (value, key)
        {
            data.append(value.Name, value.File);
        })

        angular.forEach($scope.ImageData, function (value, key)
        {
            data.append(value.Name, value.DelStatus);
        })

        var post = $http.post("Edit_HouseInfo", data,
        {
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })

        post.success(function (data, status)
        {
            $scope.successMessage = data;
            $('#messageModal').modal('show');
        });

        post.error(function (data, status)
        {
            $scope.successMessage = data;
            $('#messageModal').modal('show');
        });
    }

    $scope.DeleteData = function () {
        var data =
        {
            Id: $scope.DeleteId
        }

        var post = $http
            ({
                url: "Delete_Diary",
                method: "POST",
                params: data
            })

        post.success(function (data, status) {
            $scope.successMessage = "Successfully Deleted";
            $scope.errorMessage = "";

            $scope.diaries.splice($scope.index, 1);
            $('#successModal').modal('show');
        });

        post.error(function (data, status) {
            $scope.successMessage = "";
            $scope.errorMessage = "Error Occured While Deleting";
            $('#errorModal').modal('show');
        });
    }

    // delete a row 
    $scope.DeletePopup = function (id, index) {
        $scope.index = index;
        $scope.DeleteId = id;
        $('#deleteModal').modal('show');
    };

    $scope.ViewPopup = function (id) {
        //filter the array
        var foundItem = $filter('filter')($scope.diaries, { id: id }, true)[0];

        $scope.viewTitle = foundItem.title;
        $scope.viewContent = foundItem.content;

        $('#viewModal').modal('show');
    };
})


