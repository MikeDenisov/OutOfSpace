(function () {
    'use strict';

    var serviceId = 'dataservice';
    angular.module('OutOfSpaceApp').factory(serviceId, ['common', dataservice]);

    function dataservice(common) {
        var $q = common.$q;

        var service = {
            getSpaceObjects: getSpaceObjects,
            getSpaceObjectsCount: getSpaceObjectsCount,
            getCards: getCards,
            getCardsCount: getCardsCount
        };

        return service;

        function getSpaceObjects() {
            var spaceObjects = [
                { name: 'Not a Death Star', alt: 10000 },
                { name: 'Death Star', alt: 100000 }
            ];
            return $q.when(spaceObjects);
        }

        function getSpaceObjectsCount() { return $q.when(72); }

        function getCards() {
            var cards = [
                { id: 0, title: 'Test card'},
                { id: 1, title: 'First card' },
                { id: 2, title: 'Second card' }
            ];
            return $q.when(cards);
        }

        function getCardsCount() { return $q.when(100); }

    }
})();