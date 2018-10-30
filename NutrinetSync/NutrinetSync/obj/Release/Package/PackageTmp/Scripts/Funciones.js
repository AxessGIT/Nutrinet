
//function onChangeDate(args) {
//    //Obtiene la fecha
//    var FechaObtenida = args.value;
//    var FechaText = String(FechaObtenida);

//    //Agrega la fecha a txtFecha
//    $("#txtFecha").val(FechaText);
//}

//function onChangePeso(args) {
//    //Obtiene el peso
//    var PesoObtenido = args.value;
//    var PesoText = String(PesoObtenido);

//    //Agrega la fecha a txtFecha
//    $("#txtPeso").val(PesoText);
//}

//function onChangeTalla(args) {
//    //Obtiene el peso
//    var TallaObtenida = args.value;
//    var TallaText = String(TallaObtenida);

//    //Agrega la fecha a txtFecha
//    $("#txtTalla").val(TallaText);
//}



function AgregaDatos() {
    //Obtiene el peso, talla, fecha, sexo y edad
    var Peso = $("#txtPeso").val();
    var Talla = $("#txtTalla").val();
    var Fecha = $("#txtFecha").val();
    var Sexo = $("#txtSexo").val();
    var Edad = $("#txtEdad").val();

    //Revisa que ninguna variable este vacia
    if (Peso === "" || Talla === "") {
        alert("Revise su Información Antes de Agregar los Datos.");
        return;
    }

    //Variables para el calculo de Gasto Energetico Basal
    var GEB = 0;

    //Obtiene el texto actual
    var Texto = $("#txtHistoria").val();

    //Obtencion del IMC y redondeo a dos decimales
    var IMC = Peso / Math.pow(Talla, 2);
    IMC = (Math.round(IMC * 100.0)) / 100.0;

    //Calcula el Gasto Energetico Basal y redondeo a sin ningun decimal
    if (Sexo === "M") {
        GEB = (10 * Peso) + (6.25 * Talla) - (5 * Edad) + 5;
    }
    else {
        GEB = (10 * Peso) + (6.25 * Talla) - (5 * Edad) - 161;
    }
    GEB = Math.round(GEB);   

    //Agrega la nueva fecha
    Texto = "Fecha de Consulta: " + Fecha + " \n" + " \n" +
        "Peso: " + Peso + "   " + "Talla: " + Talla + " \n" +
        "Índice de Masa Corporal: " + IMC + " \n" +
        "Gasto Energético Basal: " + GEB + " \n" + " \n" +
        Texto;

    //Agrega el texto final
    $("#txtHistoria").val(Texto);
}