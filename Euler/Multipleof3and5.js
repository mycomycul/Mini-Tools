// Multiplesof3and5();
// function Multiplesof3and5(){
    let sum = 0;
    for(var i = 0; i < 1000; i += 5){
        if(i%3 != 0){
            sum += i;   
        }
    }
    for(var j = 0; j < 1000; j += 3){
            sum +=j;
        }
        console.log(sum);
// }