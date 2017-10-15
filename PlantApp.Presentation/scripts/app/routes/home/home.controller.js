angular.module('myApp').controller('homeController', function ($scope, $stateParams, $http) {

    // get all plants from Api by id (IIFE), invoked upon route loading
    ($scope.init = function () {
        $http.get("http://localhost:51267/api/plant/getAll").then(function (result) { $scope.plants = result.data;});
    })();
});