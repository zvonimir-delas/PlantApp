angular.module('myApp').controller('addNewSeedlingController', function ($scope, $stateParams, $http) {
    $scope.seedling = {};

    $scope.saveChanges = function () {
        $http({
            url: "http://localhost:51267/api/seedling/addSeedling",
            dataType: 'json',
            method: 'POST',
            data: $scope.seedling,
            headers: {
                "Content-Type": "application/json"
            }
        }).then(function (result) { $scope.savedMessage = result.data; });

        $scope.seedling = {};
    };
});