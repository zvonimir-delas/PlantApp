angular.module('myApp').controller('seedlingListController', function ($scope, $stateParams, $http, $state) {

    // get all seedlings from Api (IIFE), invoked upon route loading
    ($scope.init = function () {
        $http.get("http://localhost:51267/api/seedling/getAll").then(function (result) { $scope.seedlings = result.data; console.log($scope.seedlings);});
    })();

    $scope.water = function (seedling) {
        //POSLAT HTTP REQ
    }

    $scope.toggleExpand = function (seedling) {
        $scope.expandedSeedling = $scope.expandedSeedling === seedling ? null : seedling;
    };
});