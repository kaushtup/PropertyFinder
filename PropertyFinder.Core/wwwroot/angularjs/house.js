var app = angular.module("myApp", []);

app.controller("myCtrl", function ($scope, $http, $filter)
{
    $scope.successMessage = "";
    $scope.errorMessage = "";

    $scope.Title = "";
    $scope.Content = "";

    //to check if there is any user or not to share diary information.
    $scope.userStatus = false;

    $scope.dropdown = function ()
    {
        if ($scope.dropdownValue != 0)
        {
            $scope.houseInfo = $filter('filter')($scope.tempHouseInfo, { houseTypeId: $scope.dropdownValue });
        }
        else
        {   
            $scope.houseInfo = $scope.tempHouseInfo;
        }
    }

    $scope.GetAllData = function ()
    {
        $scope.dropdownValue = 0;

        $http.get("Get_HouseInfoData")
        .then(function (response)
        {
            $scope.houseInfo = response.data;
            $scope.tempHouseInfo = response.data;
        }); 
    };

    $scope.InsertData = function ()
    {
        var data =
        {
            Title: $scope.Title,
            CreatedDateTime: new Date(),
            Content: $scope.Content
        }

        if ($scope.Title == "" || $scope.Content == "")
        {
            $scope.successMessage = "";
            $scope.errorMessage = "All the data is required";
            $('#errorModal').modal('show');
        }
        else
        {
            var post = $http
            ({
                url: "Add_Diary",
                method: "POST",
                params: data
            })

            post.success(function (data, status)
            {
                $scope.diaryDatas = {};
                $scope.diaryDatas.id = data.id
                $scope.diaryDatas.title = data.title;
                $scope.diaryDatas.createdDateTime = data.createdDateTime;
                $scope.diaryDatas.content = data.content;
                $scope.diaryDatas.userId = data.userId;

                $scope.diaries.push($scope.diaryDatas)

                $scope.Title = "";
                $scope.Content = "";
                $scope.successMessage = "Successfully Added";
                $scope.errorMessage = "";
                $('#successModal').modal('show');
            });

            post.error(function (data, status)
            {
                $scope.successMessage = "";
                $scope.errorMessage = "Error "+status;
                $('#errorModal').modal('show');
            });
        }

        
    }

    $scope.CloseData = function ()
    {
        $scope.Title = "";
        $scope.Content = "";
    }

    //id of diary to be deleted
    $scope.DeleteId;

    //index of diary in angular scope model
    $scope.index;
    $scope.DeleteData = function ()
    {
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

        post.success(function (data, status)
        {
            $scope.successMessage = "Successfully Deleted";
            $scope.errorMessage = "";

            $scope.diaries.splice($scope.index, 1);
            $('#successModal').modal('show');
        });

        post.error(function (data, status)
        {
            $scope.successMessage = "";
            $scope.errorMessage = "Error Occured While Deleting";
            $('#errorModal').modal('show');
        });
    }

    // delete a row 
    $scope.DeletePopup = function (id, index)
    {
        $scope.index = index;
        $scope.DeleteId = id;
        $('#deleteModal').modal('show');
    };

    $scope.ViewPopup = function (id)
    {
        //filter the array
        var foundItem = $filter('filter')($scope.diaries, { id: id }, true)[0];

        $scope.viewTitle = foundItem.title;
        $scope.viewContent = foundItem.content;

        $('#viewModal').modal('show');
    };

    $scope.ShareData = function ()
    {
        var data =
        {
            UserId: $scope.selectedUser.userModel.id,
            DiaryId: $scope.diaryId
        }

        var post = $http
        ({
            url: "Add_SharedDiary",
            method: "POST",
            params: data
        })

        post.success(function (data, status)
        {
            $scope.successMessage = "Successfully Shared";
            $scope.errorMessage = "";
            $('#successModal').modal('show');
        });

        post.error(function (data, status)
        {
            $scope.successMessage = "";
            $scope.errorMessage = "Error Occured While Sharing";
            $('#errorModal').modal('show');
        });


    }

    //diary id of selected diary while sharing to other user.
    $scope.diaryId;
    $scope.SharePopup = function (id)
    {
        $scope.diaryId = id;
        $('#shareModal').modal('show');
    }
})  




