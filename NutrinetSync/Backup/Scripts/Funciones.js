//function onSelect(args) {
//    //Obtiene el peso, talla y fecha
//    var Peso = $("#txtPeso").val();
//    var Talla = $("#txtTalla").val();

//    //Obtiene el texto actual
//    var Texto = $("#txtHistoria").val();

//    //Agrega la nueva fecha
//    Texto = "Fecha Consulta: " + args.value + " \n" + " \n" + "Peso: " + Peso + "   " + "Talla: " + Talla + " \n" + " \n" + Texto;

//    //Agrega el texto final
//    $("#txtHistoria").val(Texto);
//}

function onChange(args) {
    //Obtiene la fecha
    var FechaObtenida = args.value;
    var FechaText = String(FechaObtenida);

    //Agrega la fecha a txtFecha
    $("#txtFecha").val(FechaText);
}

function AgregaDatos() {
    //Obtiene el peso, talla y fecha
    var Peso = $("#txtPeso").val();
    var Talla = $("#txtTalla").val();
    var Fecha = $("#txtFecha").val();

    //Obtiene el texto actual
    var Texto = $("#txtHistoria").val();

    //Obtencion del IMC
    var IMC = Peso / Math.pow(Talla, 2);

    IMC = IMC.toFixed(2);

    //Agrega la nueva fecha
    Texto = "Fecha de Consulta: " + Fecha + " \n" + " \n" +
        "Peso: " + Peso + "   " + "Talla: " + Talla + " \n" +
        "Índice de Masa Corporal: " + IMC + " \n" + " \n" +
        Texto;

    //Agrega el texto final
    $("#txtHistoria").val(Texto);
}