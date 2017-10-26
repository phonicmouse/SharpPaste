$.getJSON(window.location.protocol + "/json" + window.location.pathname, function (data) {
    var key = aesjs.utils.hex.toBytes(atob(String(location).substring(String(location).lastIndexOf('#') + 1)));
    var aes = new aesjs.ModeOfOperation.ctr(key, new aesjs.Counter(23));
    $("#title").text(aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes(data.Title))));
    document.title = 'SharpPaste - ' + $("#title").text();
    $("#body").text(aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes(data.Body))));
    $.getScript("/js/lib/prism.js", function () {
        $("#codeblock").removeAttr('hidden');
        new Clipboard("#clipboard-btn");
    });
});