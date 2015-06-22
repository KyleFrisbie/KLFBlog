$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-klf-target"));
            $target.replaceWith(data);
        });

        return false;
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-klf-autocomplete")
        };

        $input.autocomplete(options);
    };

    $("form[data-klf-ajax='true']").submit(ajaxFformSubmit);
    $("input[data-klf-autocomplete]").each(createAutocomplete);
});