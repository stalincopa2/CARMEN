/*AJAX DET_PAGOS BY VENTAS */


function GetDetPagosByVenta(URL, idVenta) {
   
    var data = { id:idVenta };
    $.ajax({ // cabecera de mi metodo ajax
        url: URL,
        type: "GET",
        dataType: 'json',
        data: data,
        befonreSend: function () {
            console.log("Accion terminada");
        }
    }).done(function (data) {
        document.getElementById("Abonos").innerHTML = "";
        var input = document.getElementById("PendienteModal");

        if (data == false) {
            document.getElementById("Abonos").innerHTML = "Esta venta no presenta registros de pagos";
            input.setAttribute("value", 0);
        } else {
            var TotalModal = document.getElementById("TotalModal");
            var PendienteModal = document.getElementById("PendienteModal"); 
            var TotalAbono = CalcularAbonoTotal(data);
            var Pendiete = TotalModal.value - TotalAbono;

            console.log(Pendiete);
            PendienteModal.setAttribute("value", Pendiete.toFixed(2)); 
            //Object.values(data).forEach(element => {
            //  /*  CreateBoxInformatio(element);*/
            //});
        }

        //var Contenedor = document.getElementById("ObservacionesContent");
        //Contenedor.innerHTML = "";
        //CreateOptions(Contenedor, data, Selecionada, Indice);
    });
}

function CalcularAbonoTotal(e) {
    var TOTALABONO = 0;
    Object.values(e).forEach(element => {
        TOTALABONO += element.MONTO; 
    });
    return TOTALABONO; 
}
//function CreateBoxInformatio(e) {
//    let BoxInformacion = document.getElementById("Abonos");
//    var dlTag = document.createElement("dl"); 
//    var dtTag = document.createElement("dt");
//    var ddTag = document.createElement("dd"); 

//    dtTag.innerHTML = SearchDetPagoById(e.ID_METODO);
//    ddTag.innerHTML = e.MONTO;

//    dlTag.appendChild(dtTag);
//    dlTag.appendChild(ddTag); 
//    BoxInformacion.appendChild(dlTag); 
//}

/*Buscar el Nombre del metodo: solucion temporarl (por bagancia)*/
function SearchDetPagoById(id) {
    var METODO_PAGO = document.getElementById("MetPago-"+id);
    return METODO_PAGO.innerHTML; 
}
