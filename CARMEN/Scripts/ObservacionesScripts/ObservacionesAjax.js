
function GetObservaciones(URL,Selecionada, Indice) {

    var data = {};
    $.ajax({ // cabecera de mi metodo ajax
        url: URL,
        type: "GET",
        dataType: 'json',
        data: data,
        befonreSend: function () {
            console.log("Accion terminada");
        }
    }).done(function (data) {
        console.log(data);
        var Contenedor = document.getElementById("ObservacionesContent");
        Contenedor.innerHTML = ""; 
        CreateOptions(Contenedor, data, Selecionada, Indice)
    }); 

}

function CreateOptions(Contenedor, Data, Selecionada, Indice) {

    var FooterModalObs = document.getElementById("FooterModalObs"); 
    FooterModalObs.innerHTML = ""; 
    var select = document.createElement("select");
    var ButtonAccept = document.createElement("button");
    var ButtonCancel = document.createElement("button"); 

    Object.values(Data).forEach(element => {
        var option = document.createElement("option");

        if (element.ID_OBSERVACION == Selecionada)
            option.setAttribute("selected", "");

        option.setAttribute("value", element.ID_OBSERVACION);
        option.textContent = element.DET_OBSER;

        select.appendChild(option);
    });

    setAttributes(ButtonAccept, { "class": "btn btn-primary", "data-dismiss": "modal", "onclick": "CambiarValoresProducto(" + Indice + ")" }); 
    setAttributes(ButtonCancel, { "class": "btn btn-danger", "data-dismiss": "modal" });
    setAttributes(select, { "id": "ID_OBSERVACION", "class": "form-control" }); 

    ButtonAccept.innerHTML = "Aceptar";
    ButtonCancel.innerHTML = "Cancelar";
    FooterModalObs.appendChild(ButtonAccept);
    FooterModalObs.appendChild(ButtonCancel); 

    Contenedor.appendChild(select);
}

function CambiarValoresProducto(Indice) {
    var ID_OBSERVACION = document.getElementById("ID_OBSERVACION");

    var PRODUCTO_OBSERVACION = document.getElementById("DETALLE_VENTA[" + Indice + "].ID_OBSERVACION");

    PRODUCTO_OBSERVACION.setAttribute("value", ID_OBSERVACION.value);
}

