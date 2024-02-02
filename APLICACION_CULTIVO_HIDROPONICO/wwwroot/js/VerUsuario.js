const passwordOriginal = document.getElementById('ContrasenaUsuario');
const password1Input = document.getElementById('ContrasenaNuevaUsuario');
const password2Input = document.getElementById('ConfContrasenaNuevaUsuario');
const submitButton = document.getElementById('BtnGuardarContrasenaUsuario');

passwordOriginal.addEventListener('input', validatePasswords);
password1Input.addEventListener('input', validatePasswords);
password2Input.addEventListener('input', validatePasswords);

function validatePasswords() {
    const password = passwordOriginal.value;
    const password1 = password1Input.value;
    const password2 = password2Input.value;
    if (password1 === password2 && password1.length >= 8 && password.length >= 8) {
        submitButton.disabled = false;
    } else {
        submitButton.disabled = true;
    }
}
