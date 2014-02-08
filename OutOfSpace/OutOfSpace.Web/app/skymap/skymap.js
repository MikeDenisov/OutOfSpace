(function () {
    'use strict';
    var controllerId = 'skymap';
    angular.module('OutOfSpaceApp').controller(controllerId, ['common', skymap]);

    function skymap(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Skymap';

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated Skymap View'); });
        }
    }
})();