window.onload = function () { // FUNCION PARA CREAR AUTOMATICAMENTE LA FECHA 
    var date = new Date();

    var Mes = String(date.getMonth() + 1).padStart(2, '0');
    var Dia = String(date.getDate()).padStart(2, '0');
    var Anio = date.getFullYear();
    var hora = date.getHours()
    var minuto = date.getMinutes()
    var segundo = date.getSeconds() 
    document.getElementById("TOTAL").setAttribute("value", "0,000");    

    document.getElementById("FECHA_VENTA").value = Anio + "-" + Mes + "-" + Dia + " " + hora + ":" + minuto + ":" + segundo;

};

function Registrar(IdModal) {

    if (validarDetalleVenta()) {
        $(IdModal).modal('show')
    } else {
        alert("No se ha selecionado ningun producto");
    }
}

function validarDetalleVenta() {
    var total = document.getElementById("TOTAL");
    if (parseInt(total.value) == 0) {
        return false
    } else {
        return true;
    }
}



function CreateTrProductos(PRODUCTO) { // FUNCION PARA CREAR LAS TABLAS DE LOS PRODUCTOS AL Dar Click

    /*Creacion de los elelentos*/
    var TrProducto = document.createElement("tr");

    var TdCantidad = document.createElement("td");
    var InputCantidad = document.createElement("input");

    var TdNombre = document.createElement("td");
    var TdPrecio = document.createElement("td");
    var TdTotal = document.createElement("td");
    var TdOpciones = document.createElement("td");
    var TdEliminar = document.createElement("td");
   
    var BtnEliminar = document.createElement("button");
    var IconEliminar = document.createElement("i");
    var BtnObservacion = document.createElement("button");
    var IconObservacion = document.createElement("i");
    

    /*Asignacion de los Append Child*/
    TdCantidad.appendChild(InputCantidad);
    TdOpciones.appendChild(BtnObservacion);
    BtnEliminar.appendChild(IconEliminar); 
    TdEliminar.appendChild(BtnEliminar);
    BtnObservacion.appendChild(IconObservacion); 

    TrProducto.appendChild(TdCantidad);
    TrProducto.appendChild(TdNombre);
    TrProducto.appendChild(TdPrecio);
    TrProducto.appendChild(TdTotal);
    TrProducto.appendChild(TdOpciones);
    TrProducto.appendChild(TdEliminar); 

    /*Asignando IneerHTMLS*/
    TdNombre.innerHTML = PRODUCTO.NOMBRE_PRODUCTO;
    TdPrecio.innerHTML = PRODUCTO.PRECIO;//OJO
    TdTotal.innerHTML = PRODUCTO.PRECIO; //OJO


    /*Asignando atributos */

    setAttributes(TrProducto, { "id": "PRODUCTO-" + num })

    setAttributes(InputCantidad, { "value": "1", "id": "CANTIDAD-" + num, "oninput": "OnlyNumbers(" + num + ")", "onpaste": "return false", "type": "number", "class": "cantInput" });
    setAttributes(TdCantidad,{"class": "Cant" })
    setAttributes(TdNombre, { "class": "Descripcion" });
    setAttributes(TdPrecio, { "class": "Precio" });
    setAttributes(TdTotal, { "class": "Total", "id": "TOTAL-" + num });
    setAttributes(TdOpciones, { "class": "Op" })
    setAttributes(TdEliminar, { "class": "Eliminar" })

    setAttributes(BtnEliminar, { "type": "button", "onclick": "RemovePrToList(" + num + ")" ,"class":"btnIcon"});
    setAttributes(BtnObservacion, { "type": "button", "data-toggle": "modal", "data-target": "#ObservacionModal", "onclick": "IndiceProducto(" + num + ")", "class": "btnIcon" }); 

    setAttributes(IconEliminar, { "class": "fas fa-minus-square" });
    setAttributes(IconObservacion, { "class": "fas fa-eye"});

    createHidddenInputs(PRODUCTO); 
    return TrProducto;
}

function IndiceProducto(Indice) {
    var Selecionada = document.getElementById("DETALLE_VENTA[" + Indice + "].ID_OBSERVACION");
    GetObservaciones(ObservacionesURL, Selecionada.value, Indice); 
}


function createHidddenInputs(PRODUCTO) { // Funcion Para crear los input type Hidden 
    var DIV_DVENTAS = document.getElementById("DETALLE_VENTA_DIV");
    var HiddenIndex = document.createElement("input");
    var HiddenID_PRODUCTO = document.createElement("input");
    var HiddenID_OSERVACION = document.createElement("input");
    var HiddenPRECIO = document.createElement("input");
    var HiddenCANTIDAD = document.createElement("input");

    setAttributes(HiddenIndex, { "name": "DETALLE_VENTA.Index", "type": "hidden", "value": num, "id": "DETALLE_VENTA.Index[" + num + "]" });

    setAttributes(HiddenID_PRODUCTO, { "name": "DETALLE_VENTA[" + num + "].ID_PRODUCTO", "id": "DETALLE_VENTA[" + num + "].ID_PRODUCTO", "type": "hidden", "value": PRODUCTO.ID_PRODUCTO });

    setAttributes(HiddenID_OSERVACION, { "name": "DETALLE_VENTA[" + num + "].ID_OBSERVACION", "id": "DETALLE_VENTA[" + num + "].ID_OBSERVACION", "type": "hidden", "value": 1 });

    setAttributes(HiddenPRECIO, { "name": "DETALLE_VENTA[" + num + "].PRECIO_UPRODUCT", "id": "DETALLE_VENTA[" + num + "].PRECIO_UPRODUCT", "type": "hidden", "value": ChangePunto(PRODUCTO.PRECIO.toFixed(3)) });

    setAttributes(HiddenCANTIDAD, { "name": "DETALLE_VENTA[" + num + "].CANTIDAD", "id": "DETALLE_VENTA[" + num + "].CANTIDAD", "type": "hidden", "value":1});

    DIV_DVENTAS.appendChild(HiddenIndex);
    DIV_DVENTAS.appendChild(HiddenID_PRODUCTO);
    DIV_DVENTAS.appendChild(HiddenID_OSERVACION);
    DIV_DVENTAS.appendChild(HiddenPRECIO);
    DIV_DVENTAS.appendChild(HiddenCANTIDAD); 

    num++;
}

function setAttributes(el, attrs) {
    for (var key in attrs) {
        el.setAttribute(key, attrs[key]);
    }
}


/**
 * /
 * @param {any} i CCANTIDAD DE TODOS LOS INPUT YA GENERADOS 
 * @param {any} ID_PRODUCTO VALOR DEL ID DEL PRODUCTO
 */

function FindInputCreated(i, ID_PRODUCTO) {
    var Input = null;

    for (let j = 0; j < i; j++) {
        Input = document.getElementById("DETALLE_VENTA[" + j + "].ID_PRODUCTO");
        if (Input != null) {
            if (Input.value == ID_PRODUCTO)
                return j; 
        }          
    }
    return -1; 
}

function OnlyNumbers(i) {
    UpdateValues(i);
}

function UpdateValues(i) {
    var HiddenCANTIDAD = document.getElementById("DETALLE_VENTA[" + i + "].CANTIDAD");
    var HiddenPRECIO = document.getElementById("DETALLE_VENTA[" + i + "].PRECIO_UPRODUCT")
    var VisibleCantidad = document.getElementById("CANTIDAD-" + i);
    var TotalUVisible = document.getElementById("TOTAL-" + i);



    var TotalUValor = new Decimal(ChangeComa(HiddenPRECIO.value)); // Se cambia por coma


    setAttributes(HiddenCANTIDAD, { "value": parseInt(HiddenCANTIDAD.value) + 1 });
    setAttributes(VisibleCantidad, { "value": parseInt(HiddenCANTIDAD.value) });

    if (VisibleCantidad.value == '' || VisibleCantidad.value<=0)
        VisibleCantidad.value = 1; 

    TotalUVisible.innerHTML = TotalUValor.mul(VisibleCantidad.value); 

    TOTAL.setAttribute("value", ChangePunto(CalcularTotal(num).toFixed(3))); 
}

function RemovePrToList(i) {


    document.getElementById("DETALLE_VENTA.Index[" + i + "]").remove();

    document.getElementById("DETALLE_VENTA[" + i + "].ID_PRODUCTO").remove();

    document.getElementById("DETALLE_VENTA[" + i + "].ID_OBSERVACION").remove();

    document.getElementById("DETALLE_VENTA[" + i + "].PRECIO_UPRODUCT").remove();

    document.getElementById("DETALLE_VENTA[" + i + "].CANTIDAD").remove();

    document.getElementById("PRODUCTO-" + i).remove(); 

    TOTAL.setAttribute("value", ChangePunto(CalcularTotal(num).toFixed(3)));
}

function ChangeComa(valor) {
    var valorModificado = valor.toString(); 
    return valorModificado.replace("," , ".")
}

function ChangePunto(valor) {
    var valorModificado = valor.toString();
    return valorModificado.replace(".", ",")
}



function CalcularTotal(i) {
    var TOTAL = 0; 
    var TotalUValor = null; 
    var TotalValores = [];
    for (let j = 0; j < i; j++) {
        var TotalUnitario = document.getElementById("TOTAL-" + j);
        if (TotalUnitario != null) {
            TotalUValor = new Decimal(TotalUnitario.innerHTML);
            TotalValores.push(TotalUValor); 
        } 
    }

    TotalValores.forEach(e => {
        TOTAL = e.add(TOTAL); 
    });
    return TOTAL; 
}