/*AJAX PRODUCTO BY CATEGORIA */
$(document).ready(function () {
    $(document).on('click', '.cargeList', function (e) {
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
            dVentaList = Object.create(data);

            let productList = "";
            var imgsrc = $('#imgIcon').attr('src');

            Object.values(data).forEach(element => {
                productList +=
                    "<tr  onclick=\"AddProductsToList(this)\" id=\"" + element.ID_PRODUCTO + "\"><td>" + element.COD_PRODUCTO + "</td>" +
                    "<td>" + element.NOMBRE_PRODUCTO + "</td>" +
                    "<td>" + element.PRECIO + "</td>";
                    if (element.FOTO_PRODUCTO == "NA") {
                        productList += "<td> <img  width=\"35\"  src=\"" + imgsrc + "\" > </td> </tr>";
                    } else {
                        productList += "<td> <img  width=\"35\"  src=\"/Content/ImgProducts/" + element.FOTO_PRODUCTO + "\" > </td> </tr>";
                    }
               
               }
            );
            document.getElementById("productosList").innerHTML = productList;
        })
    });
});


