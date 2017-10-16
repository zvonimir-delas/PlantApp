angular.module('myApp').config(function ($stateProvider) {
    $stateProvider
        .state('seedlingList', {
            url: '/seedlings',
            controller: 'seedlingListController',
            templateUrl: 'scripts/app/routes/seedlingList/seedlingList.template.html'
        });
});