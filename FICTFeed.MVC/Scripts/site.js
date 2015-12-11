var InitializeSpoilers = function () {
    $('.spoiler-link').click(function () {
        $(this).next('.spoiler-body').toggle('normal');
        return false;
    });
};

$(window).load(function () {
    $("#navigation-button").click(function () {
        $("#dropdown-navigation").toggleClass("hidden");
    });
    $("*:not(*:has(#dropdown-navigation), #search, #navigation-button)").click(function () {
        $("#dropdown-navigation").addClass("hidden");
    });
    $('select').material_select();
    $('.js-sendComment').click(function () {
        var model = {
            Description: $('textarea#text').val(),
            AuthorId: $('input[name="authorId"]').val(),
            NewsItemId: $('input[name="newsitemId"]').val()
        };

        $.post(document.location.origin + "/comment/create", model, function (data) {
            if (data == "")
                return;
            $('.comments-list').prepend(data);
            $('textarea#text').val("");
            $($('.comments-list').children()[0]).fadeOut(0);
            $($('.comments-list').children()[0]).fadeIn(1500);
        });
    });

    InitializeSpoilers();
});