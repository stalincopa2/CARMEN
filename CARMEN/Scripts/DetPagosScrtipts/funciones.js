

let numDetPagos = 0; 
let MontoTotal = 0;
let DivDetPagos = document.getElementById("DetPagos");
let els = document.getElementsByClassName("MetPago");



const BtnCobrarModal = document.getElementById("BtnCobrarModal");
const BtnCancelModal = document.getElementById("BtnCancelModal"); 

BtnCobrarModal.addEventListener('click', function (e) {

    e.preventDefault();
    try {
        var MontoDecimal = new Decimal(ChangeComa(MontoTotal));
        var TotalDecimal = new Decimal(ChangeComa(TOTAL.value));

        if (MontoDecimal.greaterThanOrEqualTo(TotalDecimal)) {
            document.formulario.submit();
        } else {
            alert("Los pagos deben ser iguales o  superiores al Total");
            return false;
        }

    } catch {
        alert("No ");

    }

});

BtnCancelModal.addEventListener('click', function () {
    var CambioModal = document.getElementById("CambioModal");
    DivDetPagos.innerHTML = ""; 
    MontoTotal = 0; 
    CambioModal.setAttribute("value", 0);
    numDetPagos = 0; 
});

function Cobrar(IdModal) {
    
    if (validarDetalleVenta()) {
        PassValuesToModal(IdModal); 
    } else {
        alert("No se ha selecionado ningun producto");
    }
}

function PassValuesToModal(IdModal) {

    var TotalModal = document.getElementById("TotalModal");

    EnablededButtonsMetPago(); 
    TotalModal.setAttribute("value", ChangeComa(TOTAL.value));

    $(IdModal).modal('show')
    
} 

function validarDetalleVenta() {
    var total = TOTAL;
    console.log(total.value); 
    if (parseInt(total.value) == 0) {
        return false
    } else {
        return true; 
    }
}

function AddMetodosPago(input) {

    var MontoDecimal = new Decimal(ChangeComa(MontoTotal));
    var TotalDecimal = new Decimal(ChangeComa(TOTAL.value)); 

    if (!ValidarMontos()) {
        alert("Primero se debe ingresar un valor, superior a 0");
    } else {
        if (MontoDecimal.greaterThanOrEqualTo(TotalDecimal)) {
            console.log(MontoTotal)
            console.log(TOTAL.value)
            alert("Nose puede agregar mas metodos de pago");
        } else {
            console.log(MontoTotal)
            DivDetPagos.appendChild(ReturnDivsCreated(input));
            DisabledButton(input);
        }

    }
}



function ReturnDivsCreated(input) {
    var DivFormGroup = document.createElement("div");
    var DivLabel = document.createElement("div");
    var Label = document.createElement("label");
    var DivInput = document.createElement("div");
    var HiddenIndex = document.createElement("input");
    var HiddenID_Metodo = document.createElement("input");
    var HiddenMONTO = document.createElement("input"); 
    var InputMonto = document.createElement("Input");

    setAttributes(DivFormGroup, { "class": "row form-group" });
    setAttributes(DivLabel, { "class": "col col-md-3" });
    setAttributes(Label, { "class": "form-control-label" });



    setAttributes(DivInput, { "class": "col-12 col-md-9" });
    setAttributes(HiddenIndex, { "name": "DET_PAGO.Index", "type": "hidden", "value": numDetPagos, "id": "DET_PAGO.Index[" + numDetPagos + "]" });
    setAttributes(HiddenID_Metodo, { "name": "DET_PAGO[" + numDetPagos + "].ID_METODO", "type": "hidden", "value": input.value, "id": "DET_PAGO[" + numDetPagos + "].ID_METODO" });
    setAttributes(HiddenMONTO, { "name": "DET_PAGO[" + numDetPagos + "].MONTO", "type": "Hidden", "value": "0,000", "id": "DET_PAGO[" + numDetPagos + "].MONTO" });
    setAttributes(InputMonto, { "type": "number", "value": 0, "oninput": "calcularCambio(" + numDetPagos+")", "class": "form-control Monto" }); 

    Label.innerHTML = input.innerHTML;


    DivLabel.appendChild(Label);
    DivInput.appendChild(HiddenIndex);
    DivInput.appendChild(HiddenID_Metodo);
    DivInput.appendChild(HiddenMONTO); 

    DivInput.appendChild(InputMonto);
    DivFormGroup.appendChild(DivLabel);
    DivFormGroup.appendChild(DivInput);
    numDetPagos++; 
    return DivFormGroup; 
}

function calcularCambio(i) {
    var HiddenMONTO = document.getElementById("DET_PAGO[" + i + "].MONTO");
    var ID_ESTVENTA = document.getElementById("ID_ESTVENTA");

    var TotalModal = document.getElementById("TotalModal");
    var TotalValor = 0; 

    var els = document.getElementsByClassName("form-control Monto");

    Array.prototype.forEach.call(els, function (el) {
        el.setAttribute("value", el.value);
        
        if (isNaN(el.value)) {
            el.setAttribute("value", 0);          
        }
        HiddenMONTO.setAttribute("value", ChangePunto(el.value));

        TotalValor = parseFloat(TotalValor) +  parseFloat(el.value);
    });

    MontoTotal = TotalValor;  // Solucion temporal para saber siempre el valor total actual 
    console.log(TotalValor); 
    var cambio = TotalValor - TotalModal.value;

    (cambio < 0) ? CambioModal.setAttribute("value", 0.000) : CambioModal.setAttribute("value", cambio.toFixed(3));

    (TotalValor >= TotalModal.value) ? ID_ESTVENTA.setAttribute("value", 2) : ID_ESTVENTA.setAttribute("value", 1); 
}

function DisabledButton(input) {
    input.removeAttribute("enabled", "");
    input.setAttribute("disabled", "");
}


function DisabledButtonsMetPago() {

    Array.prototype.forEach.call(els, function (el) {
        el.removeAttribute("enabled", "");
        el.setAttribute("disabled", "");
    });
}

function EnablededButtonsMetPago() {
    Array.prototype.forEach.call(els, function (el) {
        el.removeAttribute("disabled", "");
        el.setAttribute("enabled", "");
    });
}


/*Solucion poco elegante y escalable, se puede mejorar */

function ValidarMontos() {
    var validado = true; 

    if (numDetPagos > 0) {
        for (let i = 0; i < numDetPagos; i++) {
            var MontoValue = document.getElementById("DET_PAGO[" + i + "].MONTO").value;
            if (parseInt(MontoValue) == 0) {
                validado = false;
                i = numDetPagos + 1; 
            }

        }
    }
    return validado;  
}