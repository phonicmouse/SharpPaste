var key = aesjs.utils.hex.toBytes(atob(String(location).substring(String(location).lastIndexOf('#') + 1)));
var aes = new aesjs.ModeOfOperation.ctr(key, new aesjs.Counter(23));
$("#title").text(aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes($("#title").text()))));
document.title = 'SharpPaste - ' + $("#title").text();
$("#body").text(aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes($("#body").text()))));
$("#body").addClass('language-' + aesjs.utils.utf8.fromBytes(aes.decrypt(aesjs.utils.hex.toBytes($("#language").text()))));
$("#language").remove();