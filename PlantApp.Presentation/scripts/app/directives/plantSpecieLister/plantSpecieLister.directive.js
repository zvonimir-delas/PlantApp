angular.module('myApp').directive('plantspecielister', function () {
    return {
        templateUrl: 'scripts/app/directives/plantSpecieLister/plantSpecieLister.template.html',
        controller: 'plantSpecieListerController',
        // inherits scope from parent
        scope: false
    };
});