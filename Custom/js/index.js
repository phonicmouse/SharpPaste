$("#addpaste").click(function () {
    if ($.trim($("#body").val())) {
        var paste = {};
        if ($.trim($("#title").val())) {
            paste.title = $("#title").val();
        } else {
            paste.title = "Untitled";
        }
        paste.body = $("#body").val();
        paste.language = $("#languageSelection option:selected").val();
        var data = JSON.stringify(paste);
        console.log("JSON:", data);
        $.post("/add", data, function (responseData) {
            var pasteToken = new String(responseData);
            window.location = location.origin + "/" + pasteToken;
        });
    } else {
        $("#pasteerrormodal").modal("show");
    }
});
