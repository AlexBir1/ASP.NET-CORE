

$('#SearchButton').click(function () {
    $.ajax({
        type: "GET",
        success: function (data) {
            $('.container').find('.card').hide();
            $('.container').find('.card:contains(' + $('#SearchQuery').val() + ')').show();
        }
    });
})


$(document).on('click', '.btn-outline-danger', function (e) {

    var delConfPartial = $(this).data('delconfpart');
    var delUrl = $(this).attr('formaction');
    var cid = $(this).parents('.col-lg-4').attr('id');
    var mdiv = $(this).parents('#MainDiv');

    mdiv.append('<div id="ModalHere"></div>');
    var ModalDeleteElement = mdiv.find('#ModalHere');

    $.get(delConfPartial).done(function (data) {
        ModalDeleteElement.html(data);
        ModalDeleteElement.find('.modal').modal('show');
    })

    ModalDeleteElement.on('click', '#CancelDeleteBtn', function (e) {
        ModalDeleteElement.find('.modal').modal("hide");
        mdiv.find('#ModalHere').remove();
    })

    ModalDeleteElement.on('click', '#ConfirmDeleteBtn', function (e) {
        ModalDeleteElement.off('click', '#ConfirmDeleteBtn');
        $.ajax({
            url: delUrl,
            type: 'GET',
            complete: function (ev) {
                $(document).find('#' + cid.toString()).remove();
                ModalDeleteElement.find('.modal').modal('hide');

                mdiv.find('#ModalHere').remove();
            }
        })
    })
})

