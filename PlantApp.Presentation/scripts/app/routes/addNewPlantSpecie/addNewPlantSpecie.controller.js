angular.module('myApp').controller('addNewPlantSpecieController', function ($scope, $stateParams, $http) {
    $scope.plantSpecie = {};

    $scope.saveChanges = function () {
        $http({
            url: "http://localhost:51267/api/plantSpecie/add",
            dataType: 'json',
            method: 'POST',
            data: $scope.plantSpecie,
            headers: {
                "Content-Type": "application/json"
            }
        }).then(function (result) { $scope.savedMessage = result.data; });

        $scope.plantSpecie = {};
    };
});