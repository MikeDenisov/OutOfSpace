(function () {
	'use strict';

	var serviceId = 'crossdatacontext';
	angular.module('app').factory(serviceId, ['common', crossdatacontext]);

	function crossdatacontext(common) {
		var $q = common.$q;
		var isTarget = false;
		var target = {};

		var service = {
			setIsTarget: setIsTarget,
			getIsTarget: getIsTarget,
			setTarget: setTarget,
			getTarget: getTarget
		};

		return service;

		function setIsTarget(value) {
			isTarget = value;
		}

		function getIsTarget() {
			return $q.when(isTarget);
		}

		function setTarget(value) {
			target = value;
		}

		function getTarget() {
			return $q.when(target);
		}

	}
})();