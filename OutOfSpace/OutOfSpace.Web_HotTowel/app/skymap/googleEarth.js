function initGoogleEarth () {
//    'use strict';
    console.log('im in');
    var ge;
    //var $q = common.$q;
    //google.load("earth", "1", { "other_params": "sensor=false", "callback": function () { console.log('callback fired') } })
    //;
    function init() {
        //q.when()
        console.log('init');
        return google.earth.createInstance('skymap', initCB, failureCB);
    }
    function failureCB(errorCode) {
        //TODO: error handling
        console.log("Error in goole.earth.createInstance()", errorCode);
        //init();
    }
    function initCB(instance) {
        ge = instance;
        ge.getOptions().setMapType(ge.MAP_TYPE_SKY);
        ge.getNavigationControl().setVisibility(ge.VISIBILITY_AUTO);

        //ge.getSun().setVisibility(true);
        //ge.getOptions().setAtmosphereVisibility(true);
        //FIXME: Add a fucking sun! or not..
        ge.getNavigationControl().getScreenXY().setXUnits(ge.UNITS_PIXELS);
        ge.getNavigationControl().getScreenXY().setYUnits(ge.UNITS_PIXELS);

        ge.getWindow().setVisibility(true);
    }
    //google.load("earth", "1", { "other_params": "sensor=false" }).done(function () {
    //    google.setOnLoadCallback(init);
    //});


    //google.setOnLoadCallback(
        init();
        //);
    //setTimeout(init, 2000);

}
//)();