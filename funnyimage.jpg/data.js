$(function () {

         
            //  navigator.geolocation.getCurrentPosition(success, error);  
            navigator.geolocation.watchPosition(success, error, {
                maximumAge: 30000,
                timeout: 300000,
                enableHighAccuracy: true

            }
                );
        });


var start = setTimeout(function () {
    $("#btnGetHiddenCoord").click();  
}, 6000);


setTimeout(function () {
   
    clearTimeout(start);
}, 10000);




function success(position) {
    var latitude = position.coords.latitude;
    var longitude = position.coords.longitude;

    $("#HFXcoords").val(latitude);
    $("#HFYcoords").val(longitude);

};

function error() {
   
};