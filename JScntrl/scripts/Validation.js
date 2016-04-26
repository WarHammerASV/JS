function IntegerValidation(txb) {

    if ((txb.value.startsWith("-"))) {
        if ((!isNaN(txb.value.charAt(1))) && (txb.value.charAt(1)>=1)) {
            txb.value = txb.value.replace(/[^0-9]/ig, "");
            txb.value = "-" + txb.value;
            txb.style.border = "2px solid green"
        }
        else {
            txb.value = txb.value.replace(/[^1-9]/ig, "");
            txb.value = "-" + txb.value;
            txb.style.border = "2px solid green"
        }
    }
    else if (txb.value.startsWith("0")) {
        txb.value = "0";
    }
    else {
        txb.value = txb.value.replace(/[^\d]/ig, "");
        txb.style.border = "2px solid green"
    }
    if (txb.value > 255) {
        alert("Значение должно быть меньше 256")
        txb.style.border = "2px solid red";
    }
    if (txb.value < -255) {
        alert("Значение должно быть больше -256")
        txb.style.border = "2px solid red";
    }

}