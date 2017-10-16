angular.module('myApp').config(function ($stateProvider) {
    $stateProvider
        .state('addNewSeedling', {
            url: '/seedlings/new',
            controller: 'addNewSeedlingController',
            templateUrl: 'scripts/app/routes/addNewSeedling/addNewSeedling.template.html'
        });
});