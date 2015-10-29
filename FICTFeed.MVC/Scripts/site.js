$(window).load(function () {
    $("#navigation-button").click(function () {
        $("#dropdown-navigation").toggleClass("hidden");
    });
    $("*:not(*:has(#dropdown-navigation), #search, #navigation-button)").click(function () {
        $("#dropdown-navigation").addClass("hidden");
    });
    $('select').material_select();
    $('.commentForm .js-sendComment').click(function () {
        var model = {
            Description: $('input[name="text"]').val(),
            AuthorId: $('input[name="authorId"]').val(),
            NewsItemId: $('input[name="newsitemId"]').val()
        };

        $.post(document.location.origin + "/comment/create", model, function (data) {
            $('.comments-list').prepend("<li>" + data.AuthorName + " : " + data.PostingDateString + "<p>" + data.Description + "</p></li>");
        });
    });
});