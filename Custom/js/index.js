/* Graphics */
particlesJS.load("particles-js", '/js/particlesjs-config.json');
/* Paste Encryption and Sending */
$("#addpaste").click(function () {
    if ($.trim($("#body").val())) {
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
