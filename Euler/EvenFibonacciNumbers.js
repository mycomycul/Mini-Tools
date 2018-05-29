      
            //Method 1
            var MaxNumber = 4000000
            var sum = 0;
            var numberSet2 = [0,1]
            for(var i = 2; ((numberSet2[i-2]+numberSet2[i-1]) < MaxNumber); i++){
                numberSet2[i] = numberSet2[i-1] + numberSet2[i-2];
                
            }
            for(var j = 0; j < numberSet2.length; j++){
                if(numberSet2[j] % 2 == 0){
                    console.log(numberSet2[j]);
                    sum += numberSet2[j]
                }
            }
            console.log(sum);
            

        