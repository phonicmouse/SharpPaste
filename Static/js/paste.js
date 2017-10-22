var key = aesjs.utils.hex.toBytes(atob(String(location).substring(String(location).lastIndexOf('#') + 1)));
var aes = new aesjs.ModeOfOperation.ctr(key, new aesjs.Counter(23));
$.getJSON(window.location.protocol + "/json" + window.location.pathname, function (data) {
    $("#title").text(aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes(data.Title))));
    document.title = 'SharpPaste - ' + $("#title").text();
    $("#body").text(aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes(data.Body))));
    $("#body").addClass('language-' + aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes(data.Language))));
});