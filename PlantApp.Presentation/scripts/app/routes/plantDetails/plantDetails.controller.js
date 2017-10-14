angular.module('myApp').controller('plantDetailsController', function ($scope, $stateParams, $http) {

    //get plant from Api by id (IIFE), invoked upon route loading
    ($scope.init = function ()
    {
        $http.get("http://localhost:51267/api/plant/getPlant/"+$stateParams.plantId).then(function (result) { $scope.plant = result.data; });
    })();
});