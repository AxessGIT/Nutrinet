function onChange(args) {
    //Obtiene el dato 
    var Obtenido = args.value;
    var Text = String(Obtenido);

    //Obtiene el nombre del modelo
    var NombreModelo = args.model.name;
    var Nombre = "";

    //Si se obtuvo undefined en NombreModelo, se revisa si tiene dateFormat, y si lo tiene, entonces se le dara el nombre de Fecha
    if (!NombreModelo && args.model.dateFormat === "yyyy/MM/dd") {
        Nombre = "fecha";
    }
    else {
        Nombre = NombreModelo.substring(9, 14);
    }

    //Nombre con mayuscula en la primera letra
    var output = Nombre.substring(0, 1).toUpperCase() + Nombre.substring(1);

    //Convierte el nombre en un nombre de txt
    var txt = "txt" + output;

    //Agrega el dato a su correspondiente txt
    $(("#" + txt)).val(Text);
}