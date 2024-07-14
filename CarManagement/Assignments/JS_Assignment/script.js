// Assignment 1 (BMI Calculator)

let buttonBMI = document.getElementById("btn_calculate");

buttonBMI.addEventListener('click', () => {
    const height = parseInt(document.getElementById("height").value);
    const weight = parseInt(document.getElementById("weight").value);
    const output = document.getElementById("output");
    let height_status = false, weight_status = false;

    if (isNaN(height) || height <= 0) {
        document.getElementById("height_error").innerHTML = "Please enter a valid height value";
    }
    else {
        document.getElementById("height_error").innerHTML = '';
        height_status = true;
    }

    if (isNaN(weight) || weight <= 0) {
        document.getElementById("weight_error").innerHTML = "Please enter a valid weight value";
    }
    else {
        document.getElementById("weight_error").innerHTML = '';
        weight_status = true;
    }

    if (height_status && weight_status) {
        const bmi = (weight / ((height * height) / 10000)).toFixed(2);

        if (bmi < 18.6) { output.innerHTML = `<b>Result</b>: ${bmi}, Underweight`; }
        else if (bmi >= 25 && bmi <= 29.9) { output.innerHTML = `<b>Result</b>: ${bmi}, Overweight`; }
        else if (bmi >= 30) { output.innerHTML = `<b>Result</b>: ${bmi}, Obese`; }
        else {
            alert('The form has errors');
            output.innerHTML = '';
        }
    }
});


// Assignment 2 (jQuery)

$(document).ready(function () {
    $("#leftBtn").click(function () {
        $("#square").animate({
            left: "200px",
            borderRadius: "0"
        }, 500).css({
            "background-color": "green"
        });
    });

    $("#bottomBtn").click(function () {
        $("#square").animate({
            top: "600px",
            borderRadius: "0"
        }, 500).css({
            "background-color": "yellow"
        });
    });

    $("#rightBtn").click(function () {
        $("#square").animate({
            left: "800px",
            borderRadius: "50%",
        }, 500).css({
            "background-color": "orange"
        });
    });

    $("#topBtn").click(function () {
        $("#square").animate({
            top: "200px",
            borderRadius: "50%"
        }, 500).css({
            "background-color": "red"
        });
    });
});

// Assignment 3 (Currency calculator)

let buttonCurrency = document.getElementById("currency_calculate");

buttonCurrency.addEventListener('click', () => {
    const dollars = parseInt(document.getElementById("dollars").value);
    const currency_output = document.getElementById("currency_output");

    let dollar_status = false;

    if (isNaN(dollars) || dollars <= 0) {
        document.getElementById("dollar_error").innerHTML = "Please enter a valid number";
    }
    else {
        document.getElementById("dollar_error").innerHTML = '';
        dollar_status = true;
    }

    if (dollar_status) {
        const indianRupees = dollars * (83.34).toFixed(2);;
        currency_output.innerHTML = `<b>Result</b>: ₹${indianRupees}`;
    }
    else {
        alert('The form has errors');
        output.innerHTML = '';
    }
});



