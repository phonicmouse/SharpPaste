function generatePassword(length) {
    var password = '', character;
    while (length > password.length) {
        if (password.indexOf(character = String.fromCharCode(Math.floor(Math.random() * 94) + 33), Math.floor(password.length / 94) * 94) < 0) {
            password += character;
        }
    }
    return password;
}