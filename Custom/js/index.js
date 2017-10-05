$("#confirmdeletepaste").click(function () {
    $("#title").val("");
    $("#body").val("");
    $("#languageSelection").val("none");
});

$("#addpaste").click(function () {
    if ($.trim($("#body").val())) {
        var paste = {};
        if ($.trim($("#title").val())) {
            paste.title = window.btoa($("#title").val());
        } else {
            paste.title = window.btoa("Untitled");
        }
        paste.body = window.btoa($("#body").val());
        paste.language = $("#languageSelection option:selected").val();
        var postUrl = location.origin + "/add";
        var data = JSON.stringify(paste);
        console.log("JSON:", data);
        $.post(postUrl, data, function (responseData) {
            var pasteToken = new String(responseData);
            window.location = location.origin + "/" + pasteToken;
        });
    } else {
        $("#pasteerrormodal").modal("show");
    }
});
