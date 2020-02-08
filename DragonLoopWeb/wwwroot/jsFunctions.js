window.jsFunctions = {
    initMap: function () {
        map = jsFunctions.getMap();
    },
    getMap: function () {
        var map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 39.955615, lng: -75.189490 },
            zoom: 14
        });

        return map;
    },
    setMarker: function (posX, postY, name) {
        var marker = new google.maps.Marker({
            position: { lat: posX, lng: postY },
            map: map,
            animation: google.maps.Animation.DROP,
            title: name
        });

        marker.addListener('click', function () {
            if (marker.getAnimation() !== null) {
                marker.setAnimation(null);
            } else {
                marker.setAnimation(google.maps.Animation.BOUNCE);
            }
        });

    }
}