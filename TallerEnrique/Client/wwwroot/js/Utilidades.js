function pruebaPuntoNetStatic() {
    DotNet.invokeMethodAsync("TallerEnrique.Client", "ObtenerCurrentCount")
        .then(resultado => {
            console.log("conteo desde javascript " + resultado);
        });
}

function pruebaPuntoNETInstancia(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}

function timerInactivo(dotnetHelpers) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 300000);
    }

    function logout() {
        dotnetHelpers.invokeMethodAsync("Logout");
    }
}