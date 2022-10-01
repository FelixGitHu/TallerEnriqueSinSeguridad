

export function AgregarArticulos() {
    //$("#btnagregar").on("click", function () {
        var total = parseFloat( $("txtprecio").val()) * parseFloat( $("txtcantidad").val())
        $("#tbproducto tbody").append(
            $("#<tr>").append(
                $("<td>").text($("#txtproducto").val()),
                $("<td>").text($("#txtprecio").val()),
                $("<td>").text($("#txtcantidad").val()),
                $("<td>").text($("#txtmarca").val()),
                $("<td>").text(total),

            )
        )
        $("#txtproducto").val("")
        $("#txtprecio").val("")
        $("#txtcantidad").val("")
        $("#txtmarca").val("")
        $("#txtproducto").focus();
    //})
}

export function Mostrar(mensaje) {
    return prompt(mensaje, 'Escribe Algo');
}

$("#btnterminar").on("click", function () {
    var oDetalle_Compra = []
    var total = 0;
    $("#tbProducto > tbody > tr").each(function (i, tr) {
        oDetalle_Compra.push(
            {
                Producto: $(tr).find('td:eq(0)').text(),
                Precio: $(tr).find('td:eq(0)').text(),
                Cantidad: $(tr).find('td:eq(0)').text(),
                total: $(tr).find('td:eq(0)').text()
            }
        )
        Total = Total + parseFloat$(tr).find('td:eq(0)').text()
    })
    var OCompra = {
        oCompra: {
            Compra: $("#txtnumeroCompra").val(),
            Proveedor: $("#txtproveedor").val(),
            Fecha: $("#txtfecha").val(),
            Total: total
        },
        oDCompra : oDetalle_Compra
    }

    jQuery.ajax({
    
        url: '@Url.Action("Index","Home"),
        type: "POST",
        data: JSON.stringify(oCompraVM),
        datatype: "json"
        ContentType: "application/json;charset=utf-8",
        success: function (data) {

            if (data.respuesta) {

                alert("Venta Registrada")
                location.reload
            }
        }
   })
})