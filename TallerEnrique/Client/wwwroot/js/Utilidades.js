function pruebaPuntoNetStatic() {
    DotNet.invokeMethodAsync("TallerEnrique.Client", "ObtenerCurrentCount")
        .then(resultado => {
            console.log("conteo desde javascript " + resultado);
        });
}

function pruebaPuntoNETInstancia(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}