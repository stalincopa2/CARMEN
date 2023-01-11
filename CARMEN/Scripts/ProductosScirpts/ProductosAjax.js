/*AJAX PRODUCTO BY CATEGORIA */
$(document).ready(function () {
    $(document).on('click', '.btnCargarLista', function (e) {
        e.preventDefault();
        var id = $(this).val();
        var data = { ID_CATEGORIA: id };
        $.ajax({ // cabecera de mi metodo ajax
            url: urlProuctosByCategoria,
            type: "GET",
            dataType: 'json',
            data: data,
            befonreSend: function () {
                console.log("Accion terminada");
            }
        }).done(function (data) {

            if (data== false) {
                productList.innerHTML = "No se han asignado productos a esta categoría";
            } else {
                dVentaList = Object.create(data);
                let productList = document.getElementById("productosList");
                productList.innerHTML = "";
                Object.values(data).forEach(element => {
                    productList.appendChild(CreateElements(element));
                }
                );
            }
        })
    });
});

function CreateElements(PRODUCTO) {


    let imgsrc = $('#imgIcon').attr('src');

    if (PRODUCTO.FOTO_PRODUCTO != "NA") {
        imgsrc = "/Content/ImgProducts/" + PRODUCTO.FOTO_PRODUCTO;
    }

    let divCard = document.createElement("div");
    let divTextos = document.createElement("div");
    let divImagen = document.createElement("div");
    let divNombre = document.createElement("div");
    let Imagen = document.createElement("img");

    setAttributes(divCard, { "class": "card", "id": PRODUCTO.ID_PRODUCTO, "onclick": "AddProductsToList(this)" })
    setAttributes(divTextos, { "class": "textos" })
    setAttributes(divImagen, { "class": "ImageProduct" })
    setAttributes(divNombre, { "class": "NameProduct" })
    setAttributes(Imagen, { "src": imgsrc, "width": "50" })


    divNombre.innerHTML = PRODUCTO.NOMBRE_PRODUCTO;


    divImagen.appendChild(Imagen);

    divTextos.appendChild(divImagen);
    divTextos.appendChild(divNombre);
    divCard.appendChild(divTextos); 


    return divCard; 
}


