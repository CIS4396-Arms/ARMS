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
        $(popUp).height($(window).height() - 120);
        $(popUp).show();
        if (type == 'PrimaryAntibody') {
            BindAntibody(id);
        }
    },

    edit: function (popup, e) {
        e.preventDefault();
        
        $(popup).find('input').each(function () {
            $(this).removeAttr('disabled');
        });
    }
}

function BindAntibody(id) {
    $.ajax({
        type: "POST",
        url: "Antibodies.aspx/GetAntibody",
        data: "{id:'" + id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            populateFields(msg.d);
        }
    });
}

function BindSecondaryAntibody(id) {
    $.ajax({
        type: "POST",
        url: "SecondaryAntibodies.aspx/GetAntibody",
        data: "{id:'" + id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            populateFields(msg.d);
        }
    });
}

function populateFields(obj) {
    console.log(obj);
    $('#popUp input').each(function () {
        if ($(this).attr('id').indexOf('txt') != -1) {
            var attr = $(this).attr('id').replace('body_txt', '');
            if (obj[attr] != '' && obj[attr] != 'n/a') {
                $(this).val(obj[attr]);
            }
        };
    });
}

$(document).ready(function () {

    popUp.init('#popUp');

    // open popup
    $('a.view').click(function (e) {
        popUp.open('#popUp', 'PrimaryAntibody', $(this).attr('href'), e);
    });

    $('a.edit').click(function (e) {
        $(this).hide();
        $(this).parent().find('.save').show();
        popUp.edit('#popUp', e);
    });

});