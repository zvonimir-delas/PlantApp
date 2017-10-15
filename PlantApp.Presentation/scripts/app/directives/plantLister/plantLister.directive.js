angular.module('myApp').directive('plantlister', function () {
    return {
        templateUrl: 'scripts/app/directives/plantLister/plantLister.template.html',
        controller: 'plantListerController',
        // inherits scope from parent
        scope: false
    };
});