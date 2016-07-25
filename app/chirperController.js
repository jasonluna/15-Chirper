(function() {
    'use strict';

    angular
        .module('chirperApp')
        .controller('chirperController', chirperController);

    chirperController.$inject = ['chirperFactory', '$stateParams'];

    /* @ngInject */
    function chirperController(chirperFactory, $stateParams) {
        var vm = this;
        vm.title = 'chirperController';

        activate();

        ////////////////

        function activate() {
        }
    }
})();