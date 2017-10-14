angular.module('myApp').controller('homeController', function ($scope, $stateParams, $http) {

    $scope.testFunction = function () {
        $http.get("http://localhost:51267/api/plant/getAll/5").then(function (result) { $scope.varijabla = result.data; });
        console.log("test function angular");
    };
});