function fileValidation() {
    var fileInput = document.getElementById('FILE_PRODUCTO');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png)$/i;
    if (!allowedExtensions.exec(filePath)) {
        alert('Solo se admiten imagenes en formato .jpg .jpeg y .png');
        fileInput.value = '';
        return false;
    } else {
        return validarImagen();
    }
}

function validarImagen() {

    var fileInput = document.getElementById('FILE_PRODUCTO');
    var fileSize = $('#FILE_PRODUCTO')[0].files[0].size;
    var siezekiloByte = parseInt(fileSize * 0.001);

    if (siezekiloByte > $('#FILE_PRODUCTO').attr('size')) {
        alert("Imagen muy pesada");
        fileInput.value = '';
        return false;
    } else if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementById(
                'imagePreview').innerHTML =
                '<img src="' + e.target.result
                + '" width="100" height ="100"/>';
            fileInput.setAttribute("name", "FILE_PRODUCTO"); 
        };
        reader.readAsDataURL(fileInput.files[0]);
        return true;
    }
}
