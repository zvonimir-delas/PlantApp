angular.module('myApp').controller('plantSpecieDetailsController', function ($scope, $stateParams, $http) {

    //get plant from Api by id (IIFE), invoked upon route loading
    ($scope.init = function ()
    {
        $http.get("http://localhost:51267/api/plantSpecie/getPlantSpecie/" + $stateParams.plantSpecieId).then(function (result) { $scope.plantSpecie = result.data; });
    })();

    $scope.saveChanges = function () {

        $http({
            url: "http://localhost:51267/api/plantSpecie/update/",
            dataType: 'json',
            method: 'POST',
            data: $scope.plantSpecie,
            headers: {
                "Content-Type": "application/json"
            }
        }).then(function (result) { $scope.savedMessage = result.data; });
    };
});