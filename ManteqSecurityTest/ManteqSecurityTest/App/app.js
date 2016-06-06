(function () {
    'use strict';

    /* App Module */

    var ManteqSecurityApp = angular.module('ManteqSecurityApp', [
     , 'ngRoute'
     , 'ngResource'
     , 'ngSanitize'
     , 'ManteqSecurityAppControllers'
    
    ]);

    angular.module('ManteqSecurityAppControllers', []);

    ManteqSecurityApp.config(['$routeProvider', '$httpProvider', '$locationProvider',
            function ($routeProvider, $httpProvider, $locationProvider) {

                $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';

                $routeProvider.
               when('/', {
                   templateUrl: 'app/view/home.html',
                   controller: 'homeController'
               })
                .otherwise({
                    redirectTo: '/'
                });

            }]);


}());