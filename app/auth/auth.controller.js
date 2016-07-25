(function() {
    'use strict';

    angular
        .module('chirperApp')
        .controller('authController', authController);

    authController.$inject = ['authFactory'];

    /* @ngInject */
    function authController(authFactory) {
        var vm = this;
        vm.title = 'authController';
        vm.login = login;
        vm.register = register;

        activate();

        ////////////////

        function activate() {
        	
        }
        function login(username, password) {
        	authFactory.login(username, password)
        	.then(
        		function(response) {
        			vm.loginInfo = response;
        			console.log(response)
        		},function(error){
        			console.log(error);
        			debugger;
        		})
        }

        function register(username, password, confirmPassword) {
            authFactory.register(username, password, confirmPassword )
            .then(
                function(response) { 
                    vm.registerInfo = response;
                    console.log(response)
                },function(error){
                    console.log(error);
                    debugger;
                })
        }
    }
})();