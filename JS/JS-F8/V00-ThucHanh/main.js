
console.log('----------------------------------');

var s = sum();

console.log(sum(1,2,3,4,5))
function sum(){//declaration function
    var temp=0;
    for(var param of arguments){
        temp+=param;
    }
    return temp;
}


//sumArray(1,2);
var sumArray =function(){//expression function
    var temp=0;
    for(var param of arguments){
        temp+=param;
    }
    return temp;
}
//console.log(sumArray(1,2,3,4,5))
var sumArr2 = (a,b)=> {

    return a+b; 
}
console.log(sumArr2(1,2))