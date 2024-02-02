let items = document.querySelectorAll('.Contenedor .Carrusel .Objeto');
let next = document.getElementById('PlantaPosterior');
let prev = document.getElementById('PlantaPrevia');

var DivPadres = document.querySelectorAll(".ContenidoPrincipal");
var selects = document.querySelectorAll("#SeleccionVariables");
var DivAnterior = new Array(DivPadres.length);

for (var i = 0; i < DivAnterior.length; i++) {
    DivAnterior[i] = null;
}

for (let i = 0; i < selects.length; i++) {
    selects[i].addEventListener('change', function () {
        divs = DivPadres[i].querySelectorAll('div.Valores');
        console.log(divs.length);
        var divSeleccionado = divs[selects[i].value - 1];
        divSeleccionado.style.display = "flex";
        divSeleccionado.style.flexDirection = "column";
        divSeleccionado.style.justifyContent = "space-between";
        divSeleccionado.style.alignItems = "center";
        if (DivAnterior[i] != null) {
            DivAnterior[i].style.display = "none";
        }
        DivAnterior[i] = divSeleccionado;
    });
}

let active = 0;
function loadShow() {
    if (items.length > 0) {
        let stt = 0;
        items[active].style.transform = `none`;
        items[active].style.zIndex = 2;
        items[active].style.filter = 'none';
        items[active].style.opacity = 1;
        for (var i = active + 1; i < items.length; i++) {
            stt++;
            items[i].style.transform = `translateX(${120 * stt}px) scale(${1 - 0.2 * stt}) perspective(16px) rotateY(-1deg)`;
            items[i].style.zIndex = 1;
            items[i].style.filter = 'blur(8px)';
            items[i].style.opacity = stt > 2 ? 0 : 0.2;
        }
        stt = 0;
        for (var i = active - 1; i >= 0; i--) {
            stt++;
            items[i].style.transform = `translateX(${-120 * stt}px) scale(${1 - 0.2 * stt}) perspective(16px) rotateY(1deg)`;
            items[i].style.zIndex = 1;
            items[i].style.filter = 'blur(8px)';
            items[i].style.opacity = stt > 2 ? 0 : 0.2;
        }
    } else {
    }
}
loadShow();
next.onclick = function () {
    active = active + 1 < items.length ? active + 1 : active;
    loadShow();
}
prev.onclick = function () {
    active = active - 1 >= 0 ? active - 1 : active;
    loadShow();
}