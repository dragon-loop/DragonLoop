window.jsFunctions = {
    initMap: function () {
        var map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 39.955615, lng: -75.189490 },
            zoom: 14
        });
    }
}