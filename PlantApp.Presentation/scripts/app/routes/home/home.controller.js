angular.module('myApp').controller('homeController', function ($scope, $stateParams, $http) {

    $scope.testFunction = function () {
        $http.get("http://localhost:51267/api/test/testFunction").then(function (result) { $scope.varijabla = result.data; });
        console.log("test function angular");
    };
});