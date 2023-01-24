$(document).ready(function () {

    console.log("Hello java script");
});
      

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("Buy button has been clicked")
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).text())
        
    });


    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupForm.fadeToggle(1000);
    });