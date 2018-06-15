//Finds the largest palindrome that is a product of two numbers with the same amount of digits as the specified factor length
function findlargestPalindrome(factorLength) {
  //Determine the largest factor possible based on the specified factor length
  let largestFactorPossible = "";
  for (var f = factorLength; f > 0; f--) {
    largestFactorPossible += 9;
  }
  largestFactorPossible = parseInt(largestFactorPossible);

  //   Starting at the largest possible value and working down, check if the value is a palindrome
  let maxValueToCheck = largestFactorPossible * largestFactorPossible;
  for (var i = maxValueToCheck; i > 0; i--) {
    //Check if the current value is a palindrome
    if (checkForPalindrome(i)) {
            //If a palindrome, check if it has two factors of factorLength that equal the palindrome and if so, print and exit
            var factorFound = checkForFactors(i, factorLength, largestFactorPossible);
      if (factorFound ) {
        console.log(
          i + " is the largest palindrome found with two factors " + factorLength + " digits long. \n" + i + " is divisible by " + factorFound + " and " + i / factorFound
        );
        return;
      }
    }
  }
}

//Convert to a string and reverse the characters to check for a plaindrome
function checkForPalindrome(number) {
  let nString = number.toString();
  let nString2 = "";
  //reverse
  for (var j = 0; j < nString.length; j++) {
    nString2 += nString[nString.length - j - 1];
  }
  if (nString === nString2) return true;
  return false;
}

//Check if the provided number has two factors that are the same length as the specified factor length
function checkForFactors(number, factorLength, largestFactorPossible) {
    //how low of a number to check
  let smallestFactor = "1";
  for (factorLength; factorLength > 1; factorLength--) {
    smallestFactor += 0;
  }
//look for factor
  for (var j = largestFactorPossible; j >= parseInt(smallestFactor); j--) {
      //look for corresponding factor of the same length
    if (number % j == 0) {
      let factor = (number / j).toString().length;
      if (factor == smallestFactor.length) return j;
    }
  }
  return false;
}
findlargestPalindrome(3);
