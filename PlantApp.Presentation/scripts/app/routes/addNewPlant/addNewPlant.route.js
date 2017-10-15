angular.module('myApp').config(function ($stateProvider) {
    $stateProvider
        .state('addNewPlant', {
            url: '/plants/new',
            controller: 'addNewPlantController',
            templateUrl: 'scripts/app/routes/addNewPlant/addNewPlant.template.html'
        });
});