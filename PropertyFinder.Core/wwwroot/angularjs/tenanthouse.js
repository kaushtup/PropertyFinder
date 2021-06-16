var app = angular.module("myApp",[]);

app.controller("myCtrl", function ($scope, $http, $filter)
{
    $scope.successMessage = "";
    $scope.errorMessage = "";

    $scope.Title = "";
    $scope.Content = "";

    $scope.currentLongitude = 0;
    $scope.currentLatitude = 0;

    $scope.houseInfo = [];

    $scope.addressVal = []; 

    $scope.housefilterApplied = false;
    $scope.rentfilterApplied = false;
    $scope.costfilterApplied = false;
    $scope.locationfilterApplied = false;

    $scope.isRentVal = true;

    $scope.dropdown = function ()
    {
        $scope.housefilterApplied = false;

        var data = $scope.tempHouseInfo;;

        if ($scope.dropdownValue != 0) {
            data = $filter('filter')(data, { houseTypeId: $scope.dropdownValue });
            $scope.housefilterApplied = true;
        }

        if ($scope.costfilterApplied == true) {
            if ($scope.initialValue != null && $scope.finalValue != null) {
                data = $.grep(data, function (data) {
                    return data.cost >= $scope.initialValue && data.cost <= $scope.finalValue;
                });
            }
            else if ($scope.initialValue != null) {
                data = $.grep(data, function (data) {
                    return data.cost >= $scope.initialValue;
                });
            }
            else if ($scope.finalValue != null) {
                data = $.grep(data, function (data) {
                    return data.cost <= $scope.finalValue;
                });
            }
            else {
                $scope.costfilterApplied = false;
            }
        }

        if ($scope.rentfilterApplied == true)
        {
            data = $filter('filter')(data, { isRent: $scope.isRentVal });
        }

        if ($scope.locationfilterApplied == true) {
            $scope.addressVal = [];

            angular.forEach(data, function (value, key) {
                var addrData = $filter('filter')($scope.addressData, { id: value.addressInfoId });

                var R = 3958.8; // Radius of the earth in miles
                var dLat = deg2rad($scope.currentLatitude - addrData[0].latitude);  // deg2rad below
                var dLon = deg2rad($scope.currentLongitude - addrData[0].longitude);
                var a =
                    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                    Math.cos(deg2rad(addrData[0].latitude)) * Math.cos(deg2rad($scope.currentLatitude)) *
                    Math.sin(dLon / 2) * Math.sin(dLon / 2);

                var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
                var d = R * c; // Distance in miles

                if ($scope.range != 0) {
                    if ($scope.range > d) {
                        if ($scope.addressVal.length != 0) {
                            var filterData = $filter('filter')($scope.addressVal, { name: value.addressInfoName });

                            if (filterData.length < 1) {
                                $scope.addressVal.push
                                    ({
                                        'name': value.addressInfoName
                                    })
                            }
                        }
                        else {
                            $scope.addressVal.push
                                ({
                                    'name': value.addressInfoName
                                })
                        }

                    }
                }
            })

            var data1 = [];

            angular.forEach($scope.addressVal, function (value, key) {
                var houseData = $filter('filter')(data, { addressInfoName: value.name });

                angular.forEach(houseData, function (value1, key1) {
                    data1.push(value1);
                })
            });

            data = data1;
        }

        $scope.houseInfo = data;

        console.log("houseInfo", $scope.houseInfo);
    }

    $scope.dropdownRentOrBuy = function ()
    {
        $scope.rentfilterApplied = false;

        var data = $scope.tempHouseInfo;

        if ($scope.dropdownRentValue != 0) {
            $scope.isRentVal = true;
            if ($scope.dropdownRentValue == 2) {
                $scope.isRentVal = false;
            }

            data = $filter('filter')(data, { isRent: $scope.isRentVal });
            $scope.rentfilterApplied = true;
        }

        if ($scope.costfilterApplied == true)
        {
            if ($scope.initialValue != null && $scope.finalValue != null)
            {
                data = $.grep(data, function (data)
                {
                    return data.cost >= $scope.initialValue && data.cost <= $scope.finalValue;
                });
            }
            else if ($scope.initialValue != null)
            {
                data = $.grep(data, function (data)
                {
                    return data.cost >= $scope.initialValue;
                });
            }
            else if ($scope.finalValue != null)
            {
                data = $.grep(data, function (data)
                {
                    return data.cost <= $scope.finalValue;
                });
            }
            else
            {
                $scope.costfilterApplied = false;
            }
        }

        if ($scope.housefilterApplied == true)
        {
            data = $filter('filter')(data, { houseTypeId: $scope.dropdownValue });
        }

        if ($scope.locationfilterApplied == true) {
            $scope.addressVal = [];

            angular.forEach(data, function (value, key) {
                var addrData = $filter('filter')($scope.addressData, { id: value.addressInfoId });

                var R = 3958.8; // Radius of the earth in miles
                var dLat = deg2rad($scope.currentLatitude - addrData[0].latitude);  // deg2rad below
                var dLon = deg2rad($scope.currentLongitude - addrData[0].longitude);
                var a =
                    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                    Math.cos(deg2rad(addrData[0].latitude)) * Math.cos(deg2rad($scope.currentLatitude)) *
                    Math.sin(dLon / 2) * Math.sin(dLon / 2);

                var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
                var d = R * c; // Distance in miles

                if ($scope.range != 0) {
                    if ($scope.range > d) {
                        if ($scope.addressVal.length != 0) {
                            var filterData = $filter('filter')($scope.addressVal, { name: value.addressInfoName });

                            if (filterData.length < 1) {
                                $scope.addressVal.push
                                    ({
                                        'name': value.addressInfoName
                                    })
                            }
                        }
                        else {
                            $scope.addressVal.push
                                ({
                                    'name': value.addressInfoName
                                })
                        }

                    }
                }
            })

            var data1 = [];

            angular.forEach($scope.addressVal, function (value, key) {
                var houseData = $filter('filter')(data, { addressInfoName: value.name });

                angular.forEach(houseData, function (value1, key1) {
                    data1.push(value1);
                })
            });

            data = data1;
        }

        $scope.houseInfo = data;
    }

    $scope.costFilter = function ()
    {
        $scope.costfilterApplied = true;

        var data = $scope.tempHouseInfo;

        if ($scope.housefilterApplied == true)
        {
            data = $filter('filter')(data, { houseTypeId: $scope.dropdownValue });
        }

        if ($scope.rentfilterApplied == true)
        {
               data = $filter('filter')(data, { isRent: $scope.isRentVal });
        }

        if ($scope.costfilterApplied == true)
        {
            if ($scope.initialValue != null && $scope.finalValue != null)
            {
                data = $.grep(data, function (data)
                {
                    return data.cost >= $scope.initialValue && data.cost <= $scope.finalValue;
                });
            }
            else if ($scope.initialValue != null)
            {
                    data = $.grep(data, function (data)
                    {
                        return data.cost >= $scope.initialValue;
                    });
            }
            else if ($scope.finalValue != null)
            {
                    data = $.grep(data, function (data)
                    {
                        return data.cost <= $scope.finalValue;
                    });
            }
            else
            {
                    $scope.costfilterApplied = false;
            }
        }

        if ($scope.locationfilterApplied == true)
        {
            $scope.addressVal = [];

            angular.forEach(data, function (value, key)
            {
                var addrData = $filter('filter')($scope.addressData, { id: value.addressInfoId });

                var R = 3958.8; // Radius of the earth in miles
                var dLat = deg2rad($scope.currentLatitude - addrData[0].latitude);  // deg2rad below
                var dLon = deg2rad($scope.currentLongitude - addrData[0].longitude);
                var a =
                    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                    Math.cos(deg2rad(addrData[0].latitude)) * Math.cos(deg2rad($scope.currentLatitude)) *
                    Math.sin(dLon / 2) * Math.sin(dLon / 2);

                var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
                var d = R * c; // Distance in miles

                if ($scope.range != 0) {
                    if ($scope.range > d) {
                        if ($scope.addressVal.length != 0)
                        {
                            var filterData = $filter('filter')($scope.addressVal, { name: value.addressInfoName });

                            if (filterData.length < 1) {
                                $scope.addressVal.push
                                    ({
                                        'name': value.addressInfoName
                                    })
                            }
                        }
                        else {
                            $scope.addressVal.push
                                ({
                                    'name': value.addressInfoName
                                })
                        }

                    }
                }
            })

            var data1 = [];

            angular.forEach($scope.addressVal, function (value, key)
            {
                var houseData = $filter('filter')(data, { addressInfoName: value.name });

                angular.forEach(houseData, function (value1, key1)
                {
                    data1.push(value1);
                })
            });

            data = data1;
        }

        $scope.houseInfo = data;
    }

    $scope.dropdownLocation = function ()
    {
        $scope.locationfilterApplied = true;

        $scope.range = 0;
        if ($scope.dropdownLocationValue == 1) {
            $scope.range = 50;

        }
        else if ($scope.dropdownLocationValue == 2) {
            $scope.range = 100;
        }
        else if ($scope.dropdownLocationValue == 3) {
            $scope.range = 150;
        }
        else if ($scope.dropdownLocationValue == 4) {
            $scope.range = 200;
        }

        var data = $scope.tempHouseInfo;

        if ($scope.costfilterApplied == true) {
            if ($scope.initialValue != null && $scope.finalValue != null) {
                data = $.grep(data, function (data) {
                    return data.cost >= $scope.initialValue && data.cost <= $scope.finalValue;
                });
            }
            else if ($scope.initialValue != null) {
                data = $.grep(data, function (data) {
                    return data.cost >= $scope.initialValue;
                });
            }
            else if ($scope.finalValue != null) {
                data = $.grep(data, function (data) {
                    return data.cost <= $scope.finalValue;
                });
            }
            else {
                $scope.costfilterApplied = false;
            }
        }

        if ($scope.rentfilterApplied == true)
        {
            data = $filter('filter')(data, { isRent: $scope.isRentVal });
        }

        if ($scope.housefilterApplied == true)
        {
            data = $filter('filter')(data, { houseTypeId: $scope.dropdownValue });
        }

        if ($scope.range == 0)
        {
            $scope.locationfilterApplied = false;
        }
        else
        {
            $scope.addressVal = [];

            angular.forEach(data, function (value, key)
            {
                var addrData = $filter('filter')($scope.addressData, { id: value.addressInfoId });

                var R = 3958.8; // Radius of the earth in miles
                var dLat = deg2rad($scope.currentLatitude - addrData[0].latitude);  // deg2rad below
                var dLon = deg2rad($scope.currentLongitude - addrData[0].longitude);
                var a =
                    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                    Math.cos(deg2rad(addrData[0].latitude)) * Math.cos(deg2rad($scope.currentLatitude)) *
                    Math.sin(dLon / 2) * Math.sin(dLon / 2);

                var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
                var d = R * c; // Distance in miles

                if ($scope.range != 0) {
                    if ($scope.range > d) {
                        if ($scope.addressVal.length != 0) {
                            var filterData = $filter('filter')($scope.addressVal, { name: value.addressInfoName });

                            if (filterData.length < 1) {
                                $scope.addressVal.push
                                    ({
                                        'name': value.addressInfoName
                                    })
                            }
                        }
                        else {
                            $scope.addressVal.push
                                ({
                                    'name': value.addressInfoName
                                })
                        }

                    }
                }
            })

            var data1 = [];

            angular.forEach($scope.addressVal, function (value, key) {
                var houseData = $filter('filter')(data, { addressInfoName: value.name });

                angular.forEach(houseData, function (value1, key1)
                {
                    data1.push(value1);
                })
            });

            data = data1;
        }

        $scope.houseInfo = data;
    }

    function deg2rad(deg)
    {
        return deg * (Math.PI / 180)
    }

    $scope.minValue = 1;
    $scope.initialValFunction = function ()
    {
        $scope.minValue = $scope.initialValue;
    }

    $scope.clickFavourites = function (index) {
        var data = $scope.houseInfo[index];

        if (data.toggle == true) {
            var post = $http
                ({
                    url: "Remove_Favourite",
                    method: "POST",
                    params: data
                })

            data.toggle = false;
        }
        else {
            data.toggle = true;

            //console.log("dataId", data.id);

            var post = $http
                ({
                    url: "Save_Favourite",
                    method: "POST",
                    params: data
                })
        }
    }

    $scope.GetAllData = function ()
    {
        $scope.dropdownValue = 0;
        $scope.dropdownRentValue = 0;
        $scope.dropdownLocationValue = 0;

        $scope.favouritesData = ""
        
        $http.get("Get_UserFavourites")
            .then(function (response)
        {
                $scope.favouritesData = response.data;
        });

        $http.get("Get_HouseInfoData")
        .then(function (response)
        {
            angular.forEach(response.data, function (value, key)
            {
                var toogleVal = false;

                console.log("ads", $scope.favouritesData);

                angular.forEach($scope.favouritesData, function (val, k)
                {
                    console.log("here");
                    if (val.houseInfoId == value.id)
                    {
                        toogleVal = true;
                    }
                });

                $scope.houseInfo.push
                ({
                    'title': value.title,
                    'addressInfoId': value.addressInfoId,
                    'addressInfoName': value.addressInfoName,
                    'availableDate': value.availableDate,
                    'cost': value.cost,
                    'description': value.description,
                    'houseTypeId': value.houseTypeId,
                    'houseTypeName': value.houseTypeName,
                    'id': value.id,
                    'isRent': value.isRent,
                    'numberOfBedroom': value.numberOfBedroom,
                    'photo': value.photo,

                    'toggle': toogleVal
                })
            })

            $scope.tempHouseInfo = $scope.houseInfo;

            console.log("houseInfo", $scope.houseInfo);
            console.log("tempHouseInfo", $scope.tempHouseInfo);
        }); 

        $http.get("Get_AddressInfo")
            .then(function (response) {
                $scope.addressData = response.data;
                console.log("addressdata", $scope.addressData);
            });

        if (navigator.geolocation)
        {
            navigator.geolocation.getCurrentPosition(function (position) {

                $scope.currentLatitude = position.coords.latitude;
                $scope.currentLongitude = position.coords.longitude;



            })
        };
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
})  

