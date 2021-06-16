var app = angular.module("myApp", []);

app.controller("myCtrl", function ($scope, $http, $filter) {
    $scope.successMessage = "";
    $scope.errorMessage = "";

    $scope.Title = "";
    $scope.Content = "";

    $scope.houseInfo = [];

    $scope.dropdown = function () {
        if ($scope.dropdownValue != 0) {
            $scope.houseInfo = $filter('filter')($scope.tempHouseInfo, { houseTypeId: $scope.dropdownValue });
        }
        else {
            $scope.houseInfo = $scope.tempHouseInfo;
        }
    }

    $scope.GetAllData = function () {
        $scope.dropdownValue = 0;

        $http.get("GetFavourites")
        .then(function (response)
        {
           $scope.tempHouseInfo = response.data;

            angular.forEach($scope.tempHouseInfo, function (value, key)
            {
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

                    'toggle': true
                })
            })
        }); 
    };
})  
