angular.module('myApp').config(function ($stateProvider) {
    $stateProvider
        .state('plantDetails', {
            url: '/plants/details/:plantId/',
            controller: 'plantDetailsController',
            templateUrl: 'scripts/app/routes/plantDetails/plantDetails.template.html',
            params: {
                plantId: null
            }
        });
});