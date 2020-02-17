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
            icon: '/stop.png',
            title: name
        });

        marker.addListener('click', function () {
            if (marker.getAnimation() !== null) {
                marker.setAnimation(null);
            } else {
                marker.setAnimation(google.maps.Animation.BOUNCE);
            }
        });
    },
    setRouteSegments: function (startX, startY, endX, endY, color) {
        var routeCoordinates = [
            { lat: startX, lng: startY },
            { lat: endX, lng: endY }
        ];
        var routePath = new google.maps.Polyline({
            path: routeCoordinates,
            geodesic: true,
            strokeColor: color,
            strokeOpacity: 1.0,
            strokeWeight: 2
        });

        routePath.setMap(map);
    }
}