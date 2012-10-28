var popUp = {
    init: function (popUp) {
        // hide popup
        $(popUp).hide();

        // close popup
        $('a[href^=#close]').click(function (e) {
            e.preventDefault();
            $(this).parents('div').first().hide();
        });
    },

    open: function (popUp, type, id, e) {
        e.preventDefault();
        $(popUp).show();
        BindAntibody(id);
    }
}

function BindAntibody(id) {
    $.ajax({
        type: "GET",
        url: "Antibodies.aspx/GetAntibody",
        data: {id:id},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data.d);
        },
        error: function (data) {
            console.log("fail");
        }
    })
}

$(document).ready(function () {

    popUp.init('#popUp');

    // open popup
    $('a.view').click(function (e) {
        popUp.open('#popUp', 'PrimaryAntibody', $(this).attr('href'), e);
    });

});