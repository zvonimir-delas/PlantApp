angular.module('myApp').controller('seedlingDetailsController', function ($scope, $stateParams, $http, $state) {

    // get seedling from Api (IIFE), invoked upon route loading
    ($scope.init = function () {
        $http.get("http://localhost:51267/api/seedling/get/" + $stateParams.seedlingId).then(function (result) { $scope.seedling = result.data; $scope.calculateWaterVolume();});
    })();

    $scope.newName = "";

    $scope.calculateWaterVolume = function (seedling) {
        $http.get("http://localhost:51267/api/seedling/calculateWater/" + $stateParams.seedlingId).then(function (result) { $scope.waterVolume = result.data; });
    };

    $scope.deletePlant = function (plantId) {
        $http.post("http://localhost:51267/api/seedling/deletePlant/" + plantId);
    };

    $scope.newPlant = function () {
        $http.post("http://localhost:51267/api/seedling/addPlant/" + $scope.newName + "/" + $scope.seedling.Id);
        $scope.water();
    };

    $scope.water = function (seedling) {
        $http.post("http://localhost:51267/api/seedling/water/" + $scope.seedling.Id).then(function (result) { console.log(result.data); });
    }
});