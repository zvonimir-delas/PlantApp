angular.module('myApp').config(function ($stateProvider) {
    $stateProvider
        .state('plantSpecieDetails', {
            url: '/plantSpecies/details/:plantSpecieId/',
            controller: 'plantSpecieDetailsController',
            templateUrl: 'scripts/app/routes/plantSpecieDetails/plantSpecieDetails.template.html',
            params: {
                plantSpecieId: null
            }
        });
});