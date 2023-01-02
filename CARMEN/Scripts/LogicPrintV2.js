const btnImprimir = document.querySelector("#btnImprimir")
const CantImpresoras = document.getElementById("CantAreasImpresion").value;
/*const UrlPrint = "@Url.Action("PrintWhitPlugin", "Ticket")";*/

let AreaImpresion = {};

btnImprimir.addEventListener("click", function () {


    if (!VerificarSeleciion()) {
        alert("Selecciona al menos una area de impresión");
    } else {
        IterarImpresoras();
    }

});

function IterarImpresoras() {
    for (let i = 1; i < CantImpresoras; i++) {


        let ImpresoraName = document.getElementById("inline-checkbox" + i);
        if (ImpresoraName.checked) {
            AreaImpresion = {
                ID_AREA: 1,
                ID_SUCURSAL: 1,
                NOMBRE_AREA: "SN",
                IP: ImpresoraName.value,
            }
            PrintAjax(AreaImpresion);
        }
    }

}

function VerificarSeleciion() {
    let selectec = false
    for (let i = 1; i < CantImpresoras; i++) {
        let ImpresoraName = document.getElementById("inline-checkbox" + i);
        if (ImpresoraName.checked) {
            selectec = true;
        }
    }
    return selectec;
}


function PrintAjax(Obj) {

    $.ajax({ // cabecera de mi metodo ajax
        url: UrlPrint,
        type: "GET",
        data: Obj,
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        befonreSend: function () {
            console.log("Accion terminada");
        }
    }).done(function (data) {

        if (data == true) {
            alert("Impresion realizada con exito");
        } else {
            alert("Ha ocurrido un error")
        }
    });
}