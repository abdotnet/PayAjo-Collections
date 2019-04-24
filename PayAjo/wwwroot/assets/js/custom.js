$(document).ready(function(){
    // Comment Section Toggling
    $(".post-comment").hide();
    $("#show-comment").click(function () {
        $("#show-comment").slideToggle("slow");
        $(".post-comment").slideToggle("slow");
    });
    $("#Comment-cancel").click(function () {
        $("#show-comment").slideToggle("slow");
        $(".post-comment").slideToggle("slow");
    });
});