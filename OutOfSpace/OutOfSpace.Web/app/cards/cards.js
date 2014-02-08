(function () {
    'use strict';
    console.log('booom cards');
    var controllerId = 'cards';
    angular.module('OutOfSpaceApp').controller(controllerId, ['common', 'dataservice', cards]);
    console.log('booom after cards');

    function cards(common, dataservice) {
        console.log('booom cards cards');
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Cards motherfucker!',
            description: 'JUST CARDS!'
        };
        vm.cardsCount = 0;
        vm.cards = [];
        vm.title = 'Cards';

        activate();

        function activate() {
            console.log('booom cards activate');
            var promises = [getCardsCount(), getCards()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Cards View'); });
        }

        function getCardsCount() {
            return dataservice.getCardsCount().then(function (data) {
                return vm.cardsCount = data;
            });
        }

        function getCards() {
            return dataservice.getCards().then(function (data) {
                return vm.cards = data;
            });
        }
    }
})();