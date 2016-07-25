(function() {
    'use strict';

    angular
        .module('chirperApp')
        .factory('authFactory', authFactory);

    authFactory.$inject = ['$http', '$q', '$location', 'localStorageService', 'apiUrl'];

    /* @ngInject */
    function authFactory($http, $q, $location, localStorageService, apiUrl) {
        var state = {
            loggedIn: false
        };
        var service = {
            login: login,
            register: register
        };
        return service;

        ////////////////



        function login(username, password) {
            logout();
            var loginUser = "grant_type=password&username=" + username + "&password=" + password;
            return $http({
                method: "POST",
                url: apiUrl + 'token',
                data: loginUser,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function(response) {

                localStorageService.set('authorizationData', response.data);
                localStorageService.set('username', username);

                return response.data;
            }, function(error) {
                console.log(error);
                debugger;
            });
        }

        function logout() {
            localStorageService.remove('authorizationData');
            state.loggedIn = false;
            $location.path('#/home');
        };


        function register(username, password, confirmPassword) {
            var registerUser = {EmailAddress: username, Password: password, ConfirmPassword: confirmPassword};
            return $http({
                method: "POST",
                url: apiUrl + 'accounts/register',
                data: registerUser
            }).then(function(response) {
                return response.data;
            }, function(error) {
                console.log(error);
                debugger;
            });
        };
    }

})();
