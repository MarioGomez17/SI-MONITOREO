var enlaceMedida = document.getElementById('AgregarUnidadMedidaPlanta');
var ventanaEmergenteMedida = document.getElementById('FormularioOcultoMedida');
var botonCerrarMedida = document.getElementById('CerrarFormularioOcultoMedida');

var enlaceTiempo = document.getElementById('AgregarUnidadTiempoPlanta');
var ventanaEmergenteTiempo = document.getElementById('FormularioOcultoTiempo');
var botonCerrarMedidaTiempo = document.getElementById('CerrarFormularioOcultoTiempo');

enlaceMedida.addEventListener('click', function (event) {
    event.preventDefault();
    ventanaEmergenteMedida.style.display = 'flex';
    ventanaEmergenteMedida.style.flexDirection = 'column';
    ventanaEmergenteMedida.style.alignItems = 'center';
    ventanaEmergenteMedida.style.justifyContent = 'center';
});

botonCerrarMedida.addEventListener('click', function (event) {
    event.preventDefault();
    ventanaEmergenteMedida.style.display = 'none';
});

enlaceTiempo.addEventListener('click', function (event) {
    event.preventDefault();
    ventanaEmergenteTiempo.style.display = 'flex';
    ventanaEmergenteTiempo.style.flexDirection = 'column';
    ventanaEmergenteTiempo.style.alignItems = 'center';
    ventanaEmergenteTiempo.style.justifyContent = 'center';
});

botonCerrarMedidaTiempo.addEventListener('click', function (event) {
    event.preventDefault();
    ventanaEmergenteTiempo.style.display = 'none';
});