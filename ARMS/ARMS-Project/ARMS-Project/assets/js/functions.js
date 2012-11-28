// pop up functions

var popUp = {
    init: function (popUp) {
        // hide popup
        $(popUp).hide();

        // close popup
        $('a[href^=#close]').click(function (e) {
            e.preventDefault();
            $(this).parents('div').first().hide();
            $('a.edit').show();
            $('a.save').addClass('hide');
        });
    },

    open: function (popUp, type, id, e) {
        e.preventDefault();
        $(popUp).height($(window).height() - 120);
        $(popUp).show();
        if (type == 'openAntibodies') {
            BindAntibody(id);
        } else if (type == 'openSecondaryAntibodies') {
            BindSecondaryAntibody(id);
        } else if (type == 'openVectors') {
            BindVector(id);
        } else {
            BindConstruct(id);
        }
    },

    edit: function (popup, e) {
        e.preventDefault();

        $(popup).find('input, select, button, file').each(function () {
            $(this).removeAttr('disabled');
        });

        $('select').trigger("liszt:updated");
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

function BindVector(id) {
    $.ajax({
        type: "POST",
        url: "Vectors.aspx/GetVector",
        data: "{id:'" + id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            populateFields(msg.d);
        }
    });
}

function BindConstruct(id) {
    $.ajax({
        type: "POST",
        url: "Constructs.aspx/GetConstruct",
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
    $('#popUp select').each(function () {
        $(this).attr('disabled', 'disabled');
        var attr = $(this).attr('id').replace('body_ddl', '');
        if (obj[attr] != '' && obj[attr] != 'n/a') {
            var value = obj[attr].toString();
            if (value.indexOf(',') != -1) {
                value = value.split(",");
            }
            $(this).val(value).trigger("liszt:updated");
        }
    });
    $('#popUp input').not('.chzn-container input').each(function () {
        if ($(this).attr('type') == 'text' || $(this).attr('type') == 'hidden') {
            $(this).attr('disabled', 'disabled');
            if ($(this).attr('id').indexOf('txt') != -1) {
                var attr = $(this).attr('id').replace('body_txt', '');
                if (obj[attr] != '' && obj[attr] != 'n/a') {
                    $(this).val(obj[attr]);
                    if ($(this).val() == $('#body_ddl' + attr).val()) {
                        $(this).hide();
                    } else {
                        $('#body_ddl' + attr).val("Other").trigger("liszt:updated");
                    }
                }
            };
        }
    });
    if (obj.protocolHREF != '' && obj.protocolHREF) {
        var protocol = obj.protocolHREF.substring(0, obj.protocolHREF.length - 1).split(",");
        var html = "";
        for (var i = 0; i < protocol.length; i++) {
            var name = protocol[i].substring(protocol[i].indexOf("Uploads\\") + 8);
            html = "<li><a href=\"" + protocol[i] + "\">" + name + "</a></li>" + html;
        }
        $('#popUp #protocol').html(html);
    }
    if (obj.type != '' && obj.type) {
        var attr = obj.type.toLowerCase().replace(" antibody", "");
        $("#body_rb" + attr).attr('checked', 'checked');
    }
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
        $(this).parent().find('.save').removeClass('hide');
        popUp.edit('#popUp', e);
    });

    $(".chzn-select").chosen();

    $("select").change(function () {
        if ($(this).find("option:selected").val() == "Other") {
            $(this).parent().find('input.other').removeClass("hide");
        } else {
            $(this).parent().find('input.other').addClass("hide");
        }
    });

});