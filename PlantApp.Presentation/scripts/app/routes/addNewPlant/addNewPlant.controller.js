angular.module('myApp').controller('addNewPlantController', function ($scope, $stateParams, $http) {
    $scope.plant = {};

    $scope.saveChanges = function () {
        $http({
            url: "http://localhost:51267/api/plant/add",
            dataType: 'json',
            method: 'POST',
            data: $scope.plant,
            headers: {
                "Content-Type": "application/json"
            }
        }).then(function (result) { $scope.savedMessage = result.data; });

        $scope.plant = {};
    };
});