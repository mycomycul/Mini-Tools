function sortDigits(num){
    var numArray = [];
    while(num>0){
        numArray.push(num%10);
        num = Math.floor(num/10);
    }

    var n = numArray.length;
    for (var i = 1; i < n; ++i){
        var key = numArray[i];
        var j = i-1;

        while (j >= 0 && numArray[j] > key)
        {
            numArray[j+1] = numArray[j];
            j = j-1;
        }
        numArray[j+1] = key;
    }
    numArray.reverse();
    console.log(numArray.toString());
}
sortDigits(5618976531);
