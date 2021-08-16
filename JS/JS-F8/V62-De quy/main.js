//Gia thua cua so n
function giaiThua(n){
    if(n>1){
        return n*giaiThua(n-1);
    }
    if(n==0 || n==1)
    return 1;

}
console.log(giaiThua(3));