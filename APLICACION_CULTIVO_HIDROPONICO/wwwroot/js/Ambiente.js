var IntervaloRefresco;

function ObtenerDatos() {
    $.ajax({
        url: "/Ambiente/ActualizarVariables",
        type: "GET",
        dataType: "json",
        success: function (mensajes) {
            $("#Temperatura").text(mensajes[0]);
            $("#Humedad").text(mensajes[1]);
            $("#Conductividad").text(mensajes[2]);
            console.log("Guarde");
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
}

function IniciarRefresco(TazaRefresco) {
    IntervaloRefresco = setInterval(ObtenerDatos, TazaRefresco * 1000);
}

function DetenerRefresco() {
    clearInterval(IntervaloRefresco);
}

function updateRefreshRate() {
    var NuevaTazaRefresco = Math.abs(parseInt(document.getElementById("InputIntervalo").value));
    DetenerRefresco();
    IniciarRefresco(NuevaTazaRefresco);
    console.log(NuevaTazaRefresco);

}

var TazaRefrescoInicial = Math.abs(parseInt(document.getElementById("InputIntervalo").value));
IniciarRefresco(TazaRefrescoInicial);
