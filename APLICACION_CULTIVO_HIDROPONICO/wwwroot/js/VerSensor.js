var enlace = document.getElementById('AgregarUnidadMedidaSensor');
var ventanaEmergente = document.getElementById('FormularioOculto');
var botonCerrar = document.getElementById('CerrarFormularioOculto');

enlace.addEventListener('click', function (event) {
    event.preventDefault();
    ventanaEmergente.style.display = 'flex';
    ventanaEmergente.style.flexDirection = 'column';
    ventanaEmergente.style.alignItems = 'center';
    ventanaEmergente.style.justifyContent = 'center';
});

botonCerrar.addEventListener('click', function (event) {
    event.preventDefault();
    ventanaEmergente.style.display = 'none';
});