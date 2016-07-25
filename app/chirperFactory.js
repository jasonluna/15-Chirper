(function() {
    'use strict';

    angular
        .module('chirperApp')
        .factory('chirperFactory', chirperFactory);

    chirperFactory.$inject = ['$http', '$q'];

    /* @ngInject */
    function chirperFactory($http, $q) {
        var service = {
          
        };
        return service;

        ////////////////

        function chirp (){}

    }
})()