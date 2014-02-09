(function () {
    'use strict';

    var serviceId = 'dataservice';
    angular.module('app', ['ngResource']).factory(serviceId, ['common', dataservice]);

    function dataservice(common, $resource) {
        //var $q = common.$q;

        //return $resource('http://localhost\\:40833/api/spaceObjects/', {}, {
        //    query: { method: 'GET', isArray: true },
        //    post: { method: 'POST' },
        //    update: { method: 'PUT' },
        //    remove: { method: 'DELETE' }
        //});

    }
})();