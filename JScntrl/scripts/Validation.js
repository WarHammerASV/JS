function IntegerValidation(txb) {
    if ((txb.value.startsWith("-"))) {
        txb.value = txb.value.replace(/[^0-9]/ig, "");
        txb.value = "-" + txb.value;
        txb.style.border = "2px solid green"
    }
    else if (txb.value.startsWith("0")) {
        txb.value = "0";
    }
    else {
        txb.value = txb.value.replace(/[^0-9]/ig, "");
        txb.style.border = "2px solid green"
    }
    if (txb.value > 255) {
        txb.value = "255";
    }
       if (txb.value < -255) {
        txb.value = "-255";
    }
}