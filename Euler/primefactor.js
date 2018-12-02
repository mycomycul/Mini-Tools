factor(600851475143);
function factor(number) {
    if (validateInput(number)) {
        var resultText = "Prime Factors are: ";
        //Find Factors
        for (var x = 2; x <= number / 2; x += 1) {
            if (x % 2 != 0) {
                var prime = false;
                if (number % x == 0) {
                    prime = checkforprime(x);

                    //If it is a prime factor
                    if (prime == true)
                        resultText += x + ",";
                }
            }
        }

        resultText = resultText.slice(0, -1);
        console.log(resultText);
        // document.getElementById('result').innerHTML = resultText;
    }
    else return;
}

function checkforprime(int) {
    for (var y = 2; y <= int / 2; y++) {
        if (int % y == 0) {
            return false;
        }
    }
    //no factor of the number was found so it's prime
    // document.getElementById('result').innerHTML = "Current Number: " + int;
    console.log("Current Number: " + int);

    return true;
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