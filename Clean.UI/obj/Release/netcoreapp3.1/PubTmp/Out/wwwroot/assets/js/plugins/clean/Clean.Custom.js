//========= custom validation in hajj system ===========
function validateEmail() {
    var emailTextBox = document.getElementById("uxsemail");

    var email = emailTextBox.value;

    var emailRegEx = /^(([^<>()[\]\\.,;:\s@@\"]+(\.[^<>()[\]\\.,;:\s@@\"]+)*)|(\".+\"))@@((\[[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    emailTextBox.style.backgroundColor = "white";

    if (emailRegEx.test(email)) {
        emailTextBox.style.color = "black";

    }

    else {
        emailTextBox.style.color = "red";

    }

}
//======= print to excell =========
function ReportToExcel() {
    var url = "/ReportsToExcel/Report";
    window.open(url, "Report", "");
}
function Print() {
    var url = "/Candidate/Prints/Printform";
    window.open(url, "Printform", "");
}

//========== charts ===========
$("#uxGraphType").change(function () {
    var str = "";
    $("#uxGraphType option:selected").each(function () {
        str += $(this).text() + "";
    });
    var i = 0, strLength = str.length;
    for (i; i < strLength; i++) {
        str = str.replace(" ", "_");
    }
    $('#GraphDIV').html(' <div class="chart-container " ><div class="chart has-fixed-height has-minimum-width" id="' + str + '" chart-type="' + str + '"></div></div>');
    console.log('<div class="chart-container " ><div class="chart has-fixed-height has-minimum-width" id="' + str + '" chart-type="' + str + '"></div></div>')
}).change();
//===========jobs==========
$('#uxijobtilteid').change(function () {
    if ($(this).val() == "1") {
        $('#organ').show();

    }
    else
        $('#organ').hide();
});

$('#uxijobtilteid').change(function () {
    if ($(this).val() == "3") {
        $('#free').show();

    }
    else
        $('#free').hide();
});
// for qouta type

