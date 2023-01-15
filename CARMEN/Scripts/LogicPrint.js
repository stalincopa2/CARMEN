const CLIENTE = document.getElementById("CLIENTE").innerHTML;
const USUARIO = document.getElementById("USUARIO").innerHTML;
const FECHA = document.getElementById("FECHA").innerHTML;
const SALON = document.getElementById("SALON").innerHTML;
const MESA = document.getElementById("MESA").innerHTML;
const SUBTOTAL1 = document.getElementById("SUBTOTAL1").innerHTML;
const SUBTOTAL2 = document.getElementById("SUBTOTAL2").innerHTML;
const TOTAL = document.getElementById("TOTAL").innerHTML;
const MET_PAGO = document.getElementById("MET_PAGO").innerHTML; 
const CAMBIO = document.getElementById("CAMBIO").innerHTML;



const NROPEDIDO = document.getElementById("NROPEDIDO").innerHTML;
const NROARTICULOS = document.getElementById("NroArticulos").value;
const DETALLEVENTA = TextoDetalleVenta();



function TextoDetalleVenta() {

    var DetVentaString = "";
    for (let i = 0; i < parseInt(NROARTICULOS); i++) {
        var Cantidad = document.getElementById("Cantidad" + i).innerHTML;
        var Descripcion = document.getElementById("Descripcion" + i).innerHTML;
        var PrecioU = document.getElementById("PrecioU" + i).innerHTML;
        var TotalU = document.getElementById("TotalU" + i).innerHTML;

       DetVentaString+= LogicaImpresion(Cantidad, Descripcion, PrecioU, TotalU); 
    }
    console.log(DetVentaString)
    return DetVentaString
}

function LogicaImpresion(Cantidad, Descripcion, PrecioU, TotalU) {

    var Linea = Cantidad + "  " +AgregarEspacios(Descripcion)+"   " + PrecioU + " " + TotalU + "\n";  

    return Linea;
}

function AgregarEspacios(Descripcion) {
    var aux=0;
    var CarPermitidos =20; 
    var Inicio = 0;
    var Final = CarPermitidos; 

    var CantCaracteres = Descripcion.length;
    var LnProducto = "";
    
    aux = CantCaracteres;
    while (aux > CarPermitidos){     
        LnProducto += Descripcion.substr(Inicio, Final) + "\n"+"   ";
        Inicio = Final; 
        Final += CarPermitidos;
        aux -= CarPermitidos; 
        console.log(aux);
    }
  
    var CantEspacios = CarPermitidos - Math.abs(aux);

    LnProducto += Descripcion.substr(Inicio, Final) + ReturnEspaces(CantEspacios);

    return LnProducto; 
}

function ReturnEspaces(n) {
    var espacios=""; 
    for (let i = 0; i < n; i++) {   
        espacios += " "; 
    }
    return espacios; 
}

