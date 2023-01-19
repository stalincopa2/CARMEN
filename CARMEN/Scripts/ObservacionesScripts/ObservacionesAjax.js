
function GetObservaciones(URL, Selecionada, Indice) {
    let ModlObsBody = document.getElementById("modalObsBody");

   
    ModlObsBody.innerHTML = ModlObsOriginalBody;

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
        let Contenedor = document.getElementById("ObservacionesContent");

        CreateOptions(Contenedor, data, Selecionada, Indice)
    }); 

}

function AddObservacion() {

    let DivAlert = document.createElement("div");
    let ModalBody = document.getElementById("modalObsBody");
    

    let DET_OBSER = document.getElementById("DET_OBSER").value;

    if (DET_OBSER != "") {

        $.ajax({ // cabecera de mi metodo ajax
            url: AddObsURL,
            type: "POST",
            dataType: 'json',
            data: { DET_OBSER: DET_OBSER },
            befonreSend: function () {
                console.log("Accion terminada");
            }

        }).done(function (data) {
            if (data == "Succes") {
                setAttributes(DivAlert, { "class": "alert alert-success", "role": "alert" });
                DivAlert.innerHTML = "Observación Añadida con éxito";

            } else if(data=="Repeat") {
                setAttributes(DivAlert, { "class": "alert alert-warning", "role": "alert" });
                DivAlert.innerHTML = "No se ha añadido (Observación repetida)";
            }        
        });
    } else {
        setAttributes(DivAlert, { "class": "alert alert-danger", "role": "alert" });
        DivAlert.innerHTML = "Ingresa una observación válida";
    }

    ModalBody.appendChild(DivAlert);

    setTimeout(() => {
        ModalBody.removeChild(DivAlert);
    }, 3000);

}

function CreateOptions(Contenedor, Data, Selecionada, Indice) {

    let FooterModalObs = document.getElementById("FooterModalObs"); 

    let HiddenSeleccionada = document.createElement("input");
    let HiddenIndice = document.createElement("input"); 
    let select = document.createElement("select");
    let ButtonAccept = document.createElement("button");
    let ButtonCancel = document.createElement("button"); 

    Object.values(Data).forEach(element => {
        let option = document.createElement("option");

        if (element.ID_OBSERVACION == Selecionada)
            option.setAttribute("selected", "");

        option.setAttribute("value", element.ID_OBSERVACION);
        option.textContent = element.DET_OBSER;

        select.appendChild(option);
    });


    FooterModalObs.innerHTML = ""; 
    setAttributes(HiddenIndice, { "type": "hidden", "value": Indice, "id": "Indice" }); 
    setAttributes(HiddenSeleccionada, { "type": "hidden", "value": Selecionada, "id": "Selecionada" }); 

    setAttributes(ButtonAccept, { "class": "btn btn-primary", "data-dismiss": "modal", "onclick": "CambiarValoresProducto(" + Indice + ")" }); 
    setAttributes(ButtonCancel, { "class": "btn btn-danger", "data-dismiss": "modal" });
    setAttributes(select, { "id": "ID_OBSERVACION", "class": "form-control" }); 

    ButtonAccept.innerHTML = "Aceptar";
    ButtonCancel.innerHTML = "Cancelar";
    FooterModalObs.appendChild(ButtonAccept);
    FooterModalObs.appendChild(ButtonCancel); 

    Contenedor.appendChild(HiddenIndice);
    Contenedor.appendChild(HiddenSeleccionada); 
    Contenedor.appendChild(select);
}



function CambiarValoresProducto(Indice) {
    var ID_OBSERVACION = document.getElementById("ID_OBSERVACION");

    var PRODUCTO_OBSERVACION = document.getElementById("DETALLE_VENTA[" + Indice + "].ID_OBSERVACION");

    PRODUCTO_OBSERVACION.setAttribute("value", ID_OBSERVACION.value);
}



function ObsModalAdd() {
    let Seleccionada = document.getElementById("Selecionada").value;
    let Indice = document.getElementById("Indice").value;

    let ModalBody = document.getElementById("modalObsBody");
    let FooterModalObs = document.getElementById("FooterModalObs");

    let InputObs = document.createElement("input");
    let ButtonAdd = document.createElement("button");
    let ButtonReturn = document.createElement("button");

    setAttributes(InputObs, { "type": "text", "id": "DET_OBSER", "class": "form-control", "required": "", "placeholder": "Ingrese la observación aquí" })
    setAttributes(ButtonAdd, { "class": "btn btn-info", "onclick": "AddObservacion()" });
    setAttributes(ButtonReturn, { "class": "btn btn-warning", "type": "button", "onclick": "GetObservaciones('" + ObservacionesURL + "'," + Seleccionada + "," + Indice + ")" });

    ModalBody.innerHTML = "";
    ModalBody.appendChild(InputObs);


    FooterModalObs.innerHTML = "";
    ButtonReturn.innerHTML = "Regresar";
    ButtonAdd.innerHTML = "Añadir";
    FooterModalObs.appendChild(ButtonAdd);
    FooterModalObs.appendChild(ButtonReturn);
}
