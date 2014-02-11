(function () {
    'use strict';
    var controllerId = 'cards';
    angular.module('app').controller(controllerId, ['$scope', '$modal', '$http', 'common', 'datacontext', 'crossdatacontext', cards]);

    function cards($scope, $modal, $http, common, datacontext, crossdatacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);


        var vm = this;

        $http.get('http://localhost:40833/api/spaceObjects').success(function (data) {
            console.log(data);
            return vm.cards = data;
        });

        vm.addObject = function () {
        };

        vm.news = {
            title: 'Cards',
            description: 'Space object cards'
        };
        vm.cardsCount = 0;
        vm.cards = [];
        vm.title = 'Cards';
        vm.flipped = false;

        vm.onHeaderClick = function (data) {
            goToObject(data);
        }

        vm.onFlipCard = function (c) {
            if (c.flipped) {
                c.flipped = false;
            } else {
                c.flipped = true;
            }
        }

        activate();

        function activate() {
            var promises = [getCardsCount()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Cards View'); });
        }

        function goToObject(data) {
            setIsTarget();
            setTarget(data);
            window.location.hash = '/skymap';
        }

        function getCardsCount() {
            return datacontext.getCardsCount().then(function (data) {
                return vm.cardsCount = data;
            });
        }

        function setIsTarget() {
            crossdatacontext.setIsTarget(true);
        }

        function setTarget(data) {
            crossdatacontext.setTarget(data);
        }
    }
})();