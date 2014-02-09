(function () {
    'use strict';
    var controllerId = 'skymap';
    angular.module('app').controller(controllerId, ['common', 'crossdatacontext', skymap]);

    

    function skymap(common, crossdatacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Skymap';
        vm.isTarget = false;
        vm.target = {};

        activate();

        function activate() {
            var promises = [getIsTarget(), getTarget()];
            common.activateController(promises, controllerId)
                .then(function () {
                    log('Activated Skymap View');
                    initGoogleEarth(vm.isTarget, vm.target);
                });
        }

        function setIsTarget() {
            crossdatacontext.setIsTarget(true);
        }

        function getIsTarget() {
            return crossdatacontext.getIsTarget().then(function (data) {
                return vm.isTarget = data;
            });
        }

        function getTarget() {
            return crossdatacontext.getTarget().then(function (data) {
                return vm.target = data;
            });
        }
    }
})();