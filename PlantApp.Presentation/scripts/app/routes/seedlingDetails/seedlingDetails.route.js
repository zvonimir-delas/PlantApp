angular.module('myApp').config(function ($stateProvider) {
    $stateProvider
        .state('seedlingDetails', {
            url: '/seedlings/details/:seedlingId',
            controller: 'seedlingDetailsController',
            templateUrl: 'scripts/app/routes/seedlingDetails/seedlingDetails.template.html',
            params: {
                seedlingId: null
            }
        });
});