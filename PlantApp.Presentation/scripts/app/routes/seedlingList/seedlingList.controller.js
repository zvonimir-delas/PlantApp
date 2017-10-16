angular.module('myApp').controller('seedlingListController', function ($scope, $stateParams, $http, $state) {

    // get all seedlings from Api (IIFE), invoked upon route loading
    ($scope.init = function () {
        $http.get("http://localhost:51267/api/seedling/getAll").then(function (result) { $scope.seedlings = result.data;});
    })();

    $scope.water = function (seedling) {
        $http.post("http://localhost:51267/api/seedling/water/" + seedling.Id).then(function (result) { console.log(result.data); });
    }

    $scope.toggleExpand = function (seedling) {
        $scope.expandedSeedling = $scope.expandedSeedling === seedling ? null : seedling;
    };

    $scope.calculateWaterVolume = function (seedling) {
        $http.get("http://localhost:51267/api/seedling/calculateWater/" + seedling.Id).then(function (result) { $scope.waterVolume = result.data; });
    };

    $scope.waterVolume = "Calculate water volume";
});