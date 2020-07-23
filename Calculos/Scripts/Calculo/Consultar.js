$("#consutarcal").click(function () {
    var resMaxima = $("#DtoCalculo_RespuestaMaxima").val();
    var resMinima = $("#DtoCalculo_RespuestaMinina").val();
    var usuario = $("#DtoCalculo_Usuario_Nombre").val();
    if (resMaxima < resMinima) {
        alert("La respuesta maxima no debe ser inferior a la respuesta minima")
        return false;
    }
    if (usuario.length > 100) {
        alert("El usuario no debe tener mas de 100 caracters")

    }
  
})


function eliminar(idcalculo) {
    $.ajax({
        type: "POST",
        url: "../Calculo/Eliminar",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            idCalculo: idcalculo
        },
        success: function (d) {

            if (d === true) {
                window.location.reload();
            }
          
        },
        error: function (xhr, textStatus, errorThrown) {
            alert('Error!!');
        }
    });
}