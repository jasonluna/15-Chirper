(function() {
    'use strict';

    var chirperApp = angular.module('chirperApp', ['ui.router', 'LocalStorageModule']);
    chirperApp.config(function($stateProvider, $urlRouterProvider, $httpProvider) {
      $httpProvider.interceptors.push('authInterceptor');

 //
 // For any unmatched url, redirect to /state1
 $urlRouterProvider.otherwise("/home");
 //
 // Now set up the states
 $stateProvider
   .state('register', {
     url: "/register",
     templateUrl: "app/partials/state1.html",
     controller:"authController",
     controllerAs:"vm"
   })

.state('home', {
     url: "/home",
     templateUrl: "app/partials/state2.html",
     controller:"authController",
     controllerAs:"vm"
   })
.state('userPage', {
  url:"/userPage",
  templateUrl:"app/partials/state3.html",
  controller:"chirpController",
  controllerAs:"vm"
   })
})
.value('apiUrl', 'http://localhost:53125/api/');
    
})();