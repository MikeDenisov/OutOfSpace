(function () {
    'use strict';
    var controllerId = 'cards';
    angular.module('app').controller(controllerId, ['$http', 'common', 'datacontext', 'crossdatacontext', cards]);

    function cards($http, common, datacontext, crossdatacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        $http.get('http://localhost:40833/api/spaceObjects').success(function (data) {
            //$scope.greeting = data;
            console.log(data);
        });


        var vm = this;
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
            
            //var $cardElement = $event.target.parentNode.parentNode;
            //console.log($cardElement);
            //$/cardElement.toggleClassName('flipped');
        }

        activate();

        function activate() {
            var promises = [getCardsCount(), getCards()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Cards View'); });
        }

        //dataservice.query( function (data) {
            //$location.path('/');
        //    console.log(data);

        //});

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

        function getCards() {
            return datacontext.getCards().then(function (data) {
                return vm.cards = data;
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