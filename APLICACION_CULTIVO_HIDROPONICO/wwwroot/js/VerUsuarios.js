let items = document.querySelectorAll('.Contenedor .Carrusel .Objeto');
let next = document.getElementById('UsuarioPosterior');
let prev = document.getElementById('UsuarioPrevio');



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
