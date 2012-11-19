// pop up functions

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
        if (type == 'openAntibodies') {
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

//  ajax binding
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

//  popuplate popup fields
function populateFields(obj) {
    $('#popUp input').each(function () {
        if ($(this).attr('type') == 'text') {
            if ($(this).attr('id').indexOf('txt') != -1) {
                var attr = $(this).attr('id').replace('body_txt', '');
                if (obj[attr] != '' && obj[attr] != 'n/a') {
                    $(this).val(obj[attr]);
                    $(this).attr('disabled', 'disabled');
                }
            };
        }
    });
    if (obj.protocolHREF != '') {
        var protocol = obj.protocolHREF.substring(0, obj.protocolHREF.length - 1).split(",");
        var html = "";
        for (var i = 0; i < protocol.length; i++) {
            var name = protocol[i].substring(protocol[i].indexOf("Uploads\\") + 8);
            html = "<li><a href=\"" + protocol[i] + "\">" + name + "</a></li>" + html;
        }
        $('#popUp #protocol').html(html);
    }
    if (obj.type != '') {
        var attr = obj.type.toLowerCase().replace(" antibody", "");
        $("#body_rb" + attr).attr('checked', 'checked');
    }
    //console.log(obj);
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

//  on load
$(document).ready(function () {

    popUp.init('#popUp');

    // open popup
    $('a.view').click(function (e) {
        popUp.open('#popUp', $(this).parent().attr('id'), $(this).attr('href'), e);
    });

    $('a.edit').click(function (e) {
        $(this).hide();
        $(this).parent().find('.save').show();
        popUp.edit('#popUp', e);
    });

});