$(window).load(function () {
    $("#navigation-button").click(function () {
        $("#dropdown-navigation").toggleClass("hidden");
    });
    $("*:not(*:has(#dropdown-navigation), #search, #navigation-button)").click(function () {
        $("#dropdown-navigation").addClass("hidden");
    });
});