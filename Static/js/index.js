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
                encryptedPaste.Title = aesjs.utils.hex.fromBytes(aes.encrypt(aesjs.utils.utf8.toBytes(title)));
                encryptedPaste.Body = aesjs.utils.hex.fromBytes(aes.encrypt(aesjs.utils.utf8.toBytes(body)));
                encryptedPaste.Language = $("#languageSelection option:selected").val();
                encryptedPaste.UploadedBy = "WEB";
                var data = JSON.stringify(encryptedPaste);
                console.log("JSON:", data);
                $.post("/upload", data, function (res) {
                    var jsonRes = JSON.parse(res);
                    if (jsonRes.Status == "success") {
                        window.location = location.origin + "/" + jsonRes.LongId + "#" + btoa(aesjs.utils.hex.fromBytes(key));
                    } else if (jsonRes.Status == "error") {
                        window.alert(jsonRes.ErrMsg);
                    } else {
                        window.alert("Unhandled error!");
                    }
                });
            }
        });
    } else {
        $("#pasteerrormodal").modal("show");
    }
});
