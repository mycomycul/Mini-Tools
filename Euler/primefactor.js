factor(6008514751431234);
function factor(number) {
    if (validateInput(number)) {
        var resultText = "Prime Factors are: ";
        p = 2;
        while(number >= p*p){
            if(number%p == 0){
                number = number/p;
                resultText += p + ","
            }
            else{
                p++;
            }
        }
        resultText += number;

        console.log(resultText);
        // document.getElementById('result').innerHTML = resultText;
    }
    else return;
}


function validateInput(number) {
    number = parseInt(number)
    if (isNaN(number)) {
        // document.getElementById('result').innerHTML = "Please enter an integer";
        console.log("Please enter an integer");

        return false;
    }
    else return true;
}