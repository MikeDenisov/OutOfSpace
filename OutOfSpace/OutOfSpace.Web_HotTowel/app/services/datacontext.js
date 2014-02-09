(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', datacontext]);

    function datacontext(common) {
        var $q = common.$q;

        var service = {
            getCards: getCards,
            getCardsCount: getCardsCount
        };

        return service;

        function getCardsCount() { return $q.when(72); }

        function getCards() {
            var cards = [
                { alt: 0, alt_enum: 1, description: 'The star of death', heading: 0, id: 1, lat: 10.4748333333333, lng: 9.96954166666666, name: 'Death Star', range: 7337, tilt: 0, flipped: false },
                { alt: 0, alt_enum: 1, description: 'The star of life', heading: 0, id: 2, lat: 2.4748333333333, lng: 5.96954166666666, name: 'Life Star', range: 7337, tilt: 0, flipped: false },
                { alt: 0, alt_enum: 1, description: 'The star of happieness', heading: 0, id: 3, lat: 6.4748333333333, lng: 1.96954166666666, name: 'Happieness Star', range: 7337, tilt: 0, flipped: false },
                { alt: 0, alt_enum: 1, description: 'The star of love', heading: 0, id: 4, lat: 15.4748333333333, lng: 0.96954166666666, name: 'Love Star', range: 7337, tilt: 0, flipped: false },
                { alt: 0, alt_enum: 1, description: 'The star of health', heading: 0, id: 5, lat: 45.4748333333333, lng: 9.96954166666666, name: 'Health Star', range: 7337, tilt: 0, flipped: false },
            ];
            return $q.when(cards);
        }
    }
})();