(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/cards/cards.html',
                    title: 'cards',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-cards"></i> Cards'
                    }
                }
            }, {
                url: '/skymap',
                config: {
                    title: 'skymap',
                    templateUrl: 'app/skymap/skymap.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Skymap'
                    }
                }
            }
        ];
    }
})();