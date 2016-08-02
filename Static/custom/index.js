$("#confirmdeletepaste").click(function () {
    $("#title").val("");
    $("#body").val("");
});

$("#addpaste").click(function () {
    if ($.trim($("#body").val())) {
        var data = new String();
        if ($.trim($("#title").val())) {
            var paste = {
                title: $("#title").val(),
                body: $("#body").val()
            };
            data = JSON.stringify(paste);
        } else {
            var untitledPaste = {
                title: "Untitled",
                body: $("#body").val()
            }
            data = JSON.stringify(untitledPaste);
        }
        var postUrl = location.origin + "/paste/add";
        $.post(postUrl, data, function (responseData) {
            var pasteToken = new String(responseData);
            window.location = location.origin + "/paste/" + pasteToken;
        });
    } else {
        $("#pasteerrormodal").modal("show");
    }
});
