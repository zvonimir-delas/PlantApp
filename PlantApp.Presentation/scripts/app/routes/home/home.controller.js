angular.module('myApp').controller('homeController', function ($scope, $stateParams, $http) {

    // get all plants from Api (IIFE), invoked upon route loading
    ($scope.init = function () {
        $http.get("http://localhost:51267/api/plantSpecie/getAll").then(function (result) { $scope.plantSpecies = result.data;});
    })();
});