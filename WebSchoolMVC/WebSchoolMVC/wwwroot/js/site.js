// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let ModalWnd;

function openPartialClick(btn)
{
    var actionUrl = $(btn).data('url');
    var formActionUrl = $(btn).attr('formaction');

    if (actionUrl != null || actionUrl != undefined)
    {
        $.get(actionUrl).done(function (e)
        {
            $('#mainDiv').append('<div id="ModalWindow"></div>');
            ModalWnd = $('#ModalWindow');
            ModalWnd.html(e);
            ModalWnd.find('.modal').modal('show');
        })
    }
    else if (formActionUrl != null || formActionUrl != undefined)
    {
        $.get(formActionUrl).done(function (e)
        {
            $('#mainDiv').append('<div id="ModalWindow"></div>');
            ModalWnd = $('#ModalWindow');
            ModalWnd.html(e);
            ModalWnd.find('.modal').modal('show');
        })
    }
}

function closePartialClick(btn)
{
    ModalWnd.find('.modal').modal('hide');
    $('[id *= "ModalWindow"]').remove();
}

function closeAfterOperationPartialClick(btn)
{
    ModalWnd.find('.modal').modal('hide');
    $('[id *= "ModalWindow"]').remove();
    location.reload();
}

function saveClick(btn)
{
    var dataForm = $(btn).parents('.modal').find('form');
    var dataFromForm = dataForm.serialize();
    var actionUrl = dataForm.attr('action');

    $.post(actionUrl, dataFromForm).done(function (e)
    {
        ModalWnd.find('.modal').modal('hide');
        ModalWnd.html(e);

        if (ModalWnd.find('form').attr('id') != null || ModalWnd.find('form').attr('id') != undefined) {
            var isValid = ModalWnd.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                $(ModalWnd).find('.input-validation-error').addClass('is-valid');
                ModalWnd.find('.modal').modal('hide');
            }
            $(ModalWnd).find('.input-validation-error').addClass('is-invalid');
            ModalWnd.find('.modal').modal('show');
        }
        else {
            ModalWnd.find('.modal').modal('show');
        }
    })
}

function removeClick(btn)
{
    var dataForm = $(btn).parents('.modal').find('form');
    var dataFromForm = dataForm.serialize();
    var actionUrl = dataForm.attr('action');

    $.post(actionUrl, dataFromForm).done(function (e)
    {
        ModalWnd.find('.modal').modal('hide');
        ModalWnd.html(e);
        ModalWnd.find('.modal').modal('show');
    })
}

