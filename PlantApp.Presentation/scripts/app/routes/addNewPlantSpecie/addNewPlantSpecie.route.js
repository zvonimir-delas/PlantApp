angular.module('myApp').config(function ($stateProvider) {
    $stateProvider
        .state('addNewPlantSpecie', {
            url: '/plantSpecies/new',
            controller: 'addNewPlantSpecieController',
            templateUrl: 'scripts/app/routes/addNewPlantSpecie/addNewPlantSpecie.template.html'
        });
});