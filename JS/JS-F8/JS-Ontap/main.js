var ob1 ={
    name:"Anh",
    age:13
}
var ob2={
    name:"Anh",
    age:13
}
console.log(ob1===ob2)
//try-catch
try{
throw 'ob1'

}catch(e){

    console.log("Error: "+e);

}
//******************Array
console.log('-----------Array---------')
//some
//every
//find
//filter
//push /pop
//shift/unshift
//join
//reverse
//slice
//splice
//includes
//map
//reduce: render htmtl 
//sort
//
var arr =[7,9,1,4,8,6,2,5]
console.log(arr.sort(function(a,b){
    return a<b?1:(a>b?-1:0)
}))
//
var arr2 =arr.map(function(e,i,ori){
    //console.log(ori)
    //console.log(e)
    return e/2;
})
console.log(arr2)
var arr3 = arr.slice(0)// return a new array, with values are copy of arr
//var arr3=arr;// same array cause point to one addresss
arr[0]=33
console.log(arr)
console.log(arr3)
//**********************Khai bao object */
console.log('-----------Object create----------')
// cách 1=> phải tạo 1 object mới sau đó sd
var myValidate = function(){
    this.mess = 'Validata message';
    this.myFunc = function(){
        console.log('My Func')
    }

}
var myOb = new myValidate();

console.log(myOb.mess)
myOb.myFunc()
//Cách 2=> phải tạo 1 object mới sau đó sd
this.myValidate = function(){
    this.mess = 'Validata message';
    this.myFunc = function(){
        console.log('My Func')
    }
}
//cach 3=> tạo ra object luôn và sd
var myObj = {

}
//
console.log('-----------function create----------')
//Decleration function
myFunc('Nguyen Anh')
function myFunc(mes){
    console.log(mes);
    this.mess ="my message"// globle var
}
console.log(typeof this.myFunc)
console.log(this.mess)
// expression func
var myF = function(mes){
    console.log(mes);

}
//arrow funtion
var myfu = ()=>{

}
//innertext/textcontent 
console.log('-----------------innertext -------------')
var content = document.querySelector('#form-block');
console.log(content.innerText)
console.log('-----------------textcontent -------------')
console.log(content.textContent)
//innerHTML/outerHTML
console.log('-----------------innerHTML -------------')
console.log(content.innerHTML)
// nội dung html code bên trong giữa 2 thẻ đóng.mở
console.log('-----------------outerHTML -------------')
console.log(content.outerHTML)
// nội dung html bên trong giữa 2 thẻ đóng.mở và cả thẻ đóng.mở
//
console.log("------------------Data type--------------")

var n =undefined;
console.log('undefined:'+typeof n)
var n =null;
console.log('null:'+typeof n)
var n =[];
console.log('[]:'+typeof n)
var n ={};
console.log('{}:'+typeof n)

console.log("------------------scope--------------")
var a=12;
if(a==12){
    //const x=47;
    //let x=47;
    var x=47;
}
console.log("x=: "+x)// x-> global variable
const age =43;
console.log("age:"+window.age)
{
    var n=12;
    let m=13;
    const l=14
    console.log(m)
console.log(l)
}

console.log(n)
console.log('-----code problem-----------')
function func2(){
    for(var i = 0; i < 3; i++){
      setTimeout(()=> console.log('i:'+i),2000);
  }
  
  }
  //func2()
  //
let xx= {}, y = {name:"Ronny"},z = {name:"John"};

xx[y] = {name:"Vivek"};
xx[z] = {name:"Akki"};

console.log(xx[y]);
console.log(xx);
//

function bigFunc(){
    let newArray = new Array(700).fill('♥');
    let func = function(element){
        return newArray[element];
    }
    return func;
  }
  var getE= bigFunc();
  console.log(getE(5)); // Array is created
  console.log(getE(4)); // Array is created again
  //36. writ sort binary search for sorted array
  var array1 = [1,2,3,4,5,6,7,8,9]
Array.prototype.binarySearch = function(a){
console.log(this);
let first = 0
let last = this.length-1
while(last >= first){
    let mid = Math.floor((first+last)/2)
    if(this[mid]==a) return mid
    else if(this[mid]>a){
        last = mid-1;
    }else{//this.mid<a
        first = mid+1;
    }
}
return -1;
}
