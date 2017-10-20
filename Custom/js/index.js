/* Spinner */
var opts = {
    lines: 17 // The number of lines to draw
    , length: 56 // The length of each line
    , width: 2 // The line thickness
    , radius: 83 // The radius of the inner circle
    , scale: 1 // Scales overall size of the spinner
    , corners: 1 // Corner roundness (0..1)
    , color: '#000' // #rgb or #rrggbb or array of colors
    , opacity: 0 // Opacity of the lines
    , rotate: 0 // The rotation offset
    , direction: 1 // 1: clockwise, -1: counterclockwise
    , speed: 1.6 // Rounds per second
    , trail: 60 // Afterglow percentage
    , fps: 20 // Frames per second when using setTimeout() as a fallback for CSS
    , zIndex: 2e9 // The z-index (defaults to 2000000000)
    , className: 'spinner' // The CSS class to assign to the spinner
    , top: '50%' // Top position relative to parent
    , left: '50%' // Left position relative to parent
    , shadow: false // Whether to render a shadow
    , hwaccel: true // Whether to use hardware acceleration
    , position: 'absolute' // Element positioning
}
var spinnerTarget = document.getElementById("spinner");

/* Paste Encryption and Sending */
$("#addpaste").click(function () {
    if ($.trim($("#body").val())) {
        var spinner = new Spinner(opts).spin(spinnerTarget);
        var title = null;
        if ($.trim($("#title").val())) {
            title = $("#title").val();
        } else {
            title = "Untitled";
        }
        var body = $("#body").val();
        var language = $("#languageSelection option:selected").val();
        var pwLength = 32;
        var saltLength = 32;
        var pw = new buffer.SlowBuffer(generatePassword(pwLength).normalize('NFKC'));
        var salt = new buffer.SlowBuffer(generatePassword(saltLength).normalize('NFKC'));
        var n = 1024, r = 8, p = 1;
        var dkl = 32;
        scrypt(pw, salt, n, r, p, dkl, function (error, progress, key) {
            if (error) {
                console.log("Error: " + error);
            } else if (key) {
                var aes = new aesjs.ModeOfOperation.ctr(key, new aesjs.Counter(23));
                var encryptedPaste = {};
                encryptedPaste.title = aesjs.utils.hex.fromBytes(aes.encrypt(aesjs.utils.utf8.toBytes(title)));
                encryptedPaste.body = aesjs.utils.hex.fromBytes(aes.encrypt(aesjs.utils.utf8.toBytes(body)));
                encryptedPaste.language = aesjs.utils.hex.fromBytes(aes.encrypt(aesjs.utils.utf8.toBytes(language)));
                var data = JSON.stringify(encryptedPaste);
                console.log("JSON:", data);
                $.post("/add", data, function (responseData) {
                    var pasteToken = new String(responseData);
                    window.location = location.origin + "/" + pasteToken + "#" + btoa(aesjs.utils.hex.fromBytes(key));
                });
            }
        });
    } else {
        $("#pasteerrormodal").modal("show");
    }
});
