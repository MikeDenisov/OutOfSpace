﻿function initGoogleEarth (isTarget, target) {
    'use strict';
    var ge;

    function init() {
        return google.earth.createInstance('skymap', initCB, failureCB);
    }
    function failureCB(errorCode) {
        console.log("Error in goole.earth.createInstance()", errorCode);
    }
    function initCB(instance) {
        ge = instance;
        ge.getOptions().setMapType(ge.MAP_TYPE_SKY);
        ge.getOptions().setFlyToSpeed(ge.SPEED_TELEPORT);
        ge.getNavigationControl().setVisibility(ge.VISIBILITY_AUTO);

        //ge.getSun().setVisibility(true);
        //ge.getOptions().setAtmosphereVisibility(true);
        //FIXME: Think about adding the sun..
        ge.getNavigationControl().getScreenXY().setXUnits(ge.UNITS_PIXELS);
        ge.getNavigationControl().getScreenXY().setYUnits(ge.UNITS_PIXELS);

        if (isTarget) {
            setTimeout(function () {
                var oldFlyToSpeed = ge.getOptions().getFlyToSpeed();
                ge.getOptions().setFlyToSpeed(.4); // Slow down the camera flyTo speed.
                var lookAt = ge.createLookAt('');

                lookAt.set(target.lat, target.lng, target.alt,
                target.alt_enum, target.heading,
                target.tilt, target.range);

                ge.getView().setAbstractView(lookAt);
                ge.getOptions().setFlyToSpeed(oldFlyToSpeed);
            }, 2000)
        }

        ge.getWindow().setVisibility(true);
    }

    function definePlacemark(ge, spaceObject) {
        var placemark = ge.createPlacemark('');

        // Define a custom icon.
        var icon = ge.createIcon('');
        icon.setHref('');//image for placemark
        
        var style = ge.createStyle(''); //create a new style
        style.getIconStyle().setIcon(icon); //apply the icon to the style
        style.getIconStyle().setScale(3.0); // apply icon size
        placemark.setStyleSelector(style); //apply the style to the placemark

        // Set the placemark's location.
        var point = ge.createPoint('');
        point.setLatitude(spaceObject.lat);
        point.setLongitude(spaceObject.lng);
        placemark.setGeometry(point);
        // give the placemark a name and a description (a balloon will
        // automatically show on click)
        placemark.setName(spaceObject.name);
        placemark.setDescription(spaceObject.description);

        google.earth.addEventListener(placemark, 'click', function (event) {
            // Prevent the default balloon from popping up.
            event.preventDefault();
            //TODO: implement ClickEventListener
        });

        // add the placemark to the earth DOM
        ge.getFeatures().appendChild(placemark);
    }

        init();

}