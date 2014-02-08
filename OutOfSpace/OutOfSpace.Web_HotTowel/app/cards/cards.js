(function () {
    'use strict';
    var controllerId = 'cards';
    angular.module('app').controller(controllerId, ['common', 'datacontext', cards]);

    function cards(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Cards',
            description: 'Space object cards'
        };
        vm.cardsCount = 0;
        vm.cards = [];
        vm.title = 'Cards';

        activate();

        function activate() {
            var promises = [getCardsCount(), getCards()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Cards View'); });
        }

        function getCardsCount() {
            return datacontext.getCardsCount().then(function (data) {
                return vm.cardsCount = data;
            });
        }

        function getCards() {
            return datacontext.getCards().then(function (data) {
                return vm.cards = data;
            });
        }
    }
})();