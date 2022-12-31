function ChangeComa(valor) {
    var valorModificado = valor.toString();
    return valorModificado.replace(",", ".")
}

function ChangePunto(valor) {
    var valorModificado = valor.toString();
    return valorModificado.replace(".", ",")
}
function setAttributes(el, attrs) {
    for (var key in attrs) {
        el.setAttribute(key, attrs[key]);
    }
}
