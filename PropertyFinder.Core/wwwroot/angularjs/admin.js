var app = angular.module("myApp", []);

app.controller("myCtrl", function ($scope, $http, $filter)
{
    $scope.successMessage = "";
    $scope.errorMessage = "";

    $scope.GetAllData = function ()
    {
        $http.get("Get_OwnerInfoData")
            .then(function (response)
            {
                $scope.userOwner = response.data;
                console.log(response.data);
            }); 

        $http.get("Get_TenantInfoData")
            .then(function (response) {
                $scope.userTenant = response.data;
            });
    };

    $scope.ownerIndex;
    $scope.tenantIndex;

    //id of diary to be deleted
    $scope.DeleteOwnerId;
    $scope.DeleteTenantId;

    $scope.DeleteOwnerData = function ()
    {
        var data =
        {
            Id: $scope.DeleteOwnerId
        };

        var post = $http
        ({
            url: "Delete_OwnerData",
            method: "POST",
            params: data
        })

        post.success(function (data, status)
        {
            $scope.successMessage = "Successfully Deleted";
            $scope.errorMessage = "";

            $scope.userOwner.splice($scope.ownerIndex, 1);
            $('#successModal').modal('show');
        });

        post.error(function (data, status)
        {
            $scope.successMessage = "";
            $scope.errorMessage = "Error Occured While Deleting";
            $('#errorModal').modal('show');
        });
    }

    $scope.DeleteTenantData = function () {
        var data =
        {
            Id: $scope.DeleteTenantId
        };

        console.log("hereee", data);

        var post = $http
            ({
                url: "Delete_TenantData",
                method: "POST",
                params: data
            })

        post.success(function (data, status) {
            $scope.successMessage = "Successfully Deleted";
            $scope.errorMessage = "";

            $scope.userTenant.splice($scope.tenantIndex, 1);
            $('#successModal').modal('show');
        });

        post.error(function (data, status) {
            $scope.successMessage = "";
            $scope.errorMessage = "Error Occured While Deleting";
            $('#errorModal').modal('show');
        });
    }

    // delete a row 
    $scope.DeleteOwnerPopup = function (id, index)
    {
        console.log("aaa", id);
        console.log("bbb", index);

        $scope.ownerIndex = index;
        $scope.DeleteOwnerId = id;
        $('#deleteModal').modal('show');
    };

    // delete a row 
    $scope.DeleteTenantPopup = function (id, index) {
        console.log("aaa", id);
        console.log("bbb", index);

        $scope.tenantIndex = index;
        $scope.DeleteTenantId = id;
        $('#deleteTenantModal').modal('show');
    };

    //$scope.ViewPopup = function (id)
    //{
    //    //filter the array
    //    var foundItem = $filter('filter')($scope.diaries, { id: id }, true)[0];

    //    $scope.viewTitle = foundItem.title;
    //    $scope.viewContent = foundItem.content;

    //    $('#viewModal').modal('show');
    //};


})  

