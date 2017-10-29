var key = aesjs.utils.hex.toBytes(atob(String(location).substring(String(location).lastIndexOf('#') + 1)));
var aes = new aesjs.ModeOfOperation.ctr(key, new aesjs.Counter(23));
$("#title").text(aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes(encryptedTitle))));
document.title = 'SharpPaste - ' + $("#title").text();
$("#body").text(aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes(encryptedBody))));
$.getScript("/js/lib/prism.js",
    function() {
        $("#codeblock").removeAttr('hidden');
        var clipboard = new Clipboard("#clipboard-btn");
        clipboard.on('success',
            function(e) {
                e.clearSelection();
            });
    });
