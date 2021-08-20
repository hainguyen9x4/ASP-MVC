//-----------Var/let/const
console.log('-----------Var/let/const');
if(1){
    var a =12;
    let b=12;
    const c=13;
}
console.log(a);//12
//console.log(b);// error undefine
//console.log(c);// error undefine

/*
-var: can use every when in app, hosting, có thể dùng trước khi khai báo
vì trình thông dịch sẽ đưa khai báo var lên đầu script
-const,let: ko thẻ sd dụng ngoài scope
-const: can not change the value. only assign one time at initialization
*/
//------------Arrow func
console.log('------------Arrow func');
//Là cách viết gọn của expression function
//Khong sử dụng được this-keyword trong arrow func
var f1 = (a,b)=>{
    return a+b;
}
var f1 = (a,b)=> a+b;
var f1 = a => Math.sqrt(a);
var f1 = (a,b,)=>({name:a, age:b})

//------------Template literal, template string
console.log('----------Template literal, template string');
var param1 =12;
var param2 = "NGuyen"
var str = 'hello '+param1+' this is the '+param2;// thông thường
var str = `hello ${param1} this is the ${param2}`;// template string
//-> sử dụng làm biến lưu cho text box
//-----------Classes
console.log('----------Classes');
class Course{
    constructor(id, name, price){
        this.name = name;
        this.price =price;
        this.id =id;
    }
    getPrice(id){//method
        return this.price;
    }
}
var c = new Course(1,"JS",1200);
console.log(c.price);
console.log(c.getPrice(1));
//------------Enhance object literals
console.log('----------Enhance object literals');
var name ='name'
var age = 'age';
var email='email'
var info = {
    [name]:'hainguyen',// key là 1 biến
    [age]:13,
    other:email,//value la 1 bien
    getname: function(){///1 cach viet,ham
    },
    getname2(){}//1 cach viet ham
}
console.log(info);
//------------Defaulr parameter- định nghĩa các giá trị mặc định của tham số
console.log('-----------Defaulr parameter- định nghĩa các giá trị mặc định của tham số');
function writeLog(mes){
    console.log(mes);
}
writeLog('This is log');
function writeLog(mes){
    if(mes){
    mes='Default log';
    }
    console.log(mes);
}
writeLog();//writeLog(undifined);

function writeLog(mes='Default log'){
    console.log(mes);
}
writeLog();
//------------Destructuring- phân rã với object và arry: lấy ra các phần tử trong
console.log('-----------Destructuring- phân rã với object và arry: lấy ra các phần tử trong');
var arr = ['java','php','c++']
var [a,b,c] =arr;// lấy lần lượt các phần tử trong rãy gán vào biến a b c
console.log(a,b,c);
var[d,,e]=arr;
console.log(d,e);
//----------...rest: còn lai
console.log('----------...rest: còn lai');
arr = ['java','php','c++','js',"C#"]
var[a1,a2,...rest] =arr;
console.log(a1,a2);
console.log('rest= '+rest);// rest lay ra cac phan tu con lai
//Destructuring with object
console.log('//Destructuring with object');
var info = {
    [name]:'hainguyen',// key là 1 biến
    [age]:13,
    other:email,//value la 1 bien
    getname: function(){///1 cach viet,ham
        return this.name;
    },
    getname2(){}//1 cach viet ham
}
var {name,age,other:mail,getname,getname2} =info;// other đã đổi tên thành mail sau khi lấy ra
console.log(name,age,mail);
console.log(getname());
// toan tu rest (...)
console.log('toan tu rest (...)');
function writeLog2(...parameter){
    console.log(parameter);// chuyen param vao thanh array
}
writeLog2(1,2,3,4,5,6,7,0);
console.log('__________________');
function writeLog3({name,age,other,...parameter}){
    console.log(name);
    console.log(age);
    console.log(other);
    console.log(parameter);
}
writeLog3(info)//object infor
function writeLog4([a,b,c,...parameter]){
    console.log(a,b,c);
    console.log(parameter);
}
writeLog4([1,2,3,4,5])//arry
//------------Spread(...)- toan giải
console.log('-----------Spread');
//array: noi 2 mang lai voi nhau
var arr1 =[1,2,3,4,5]
var arr2 =[9,0]
var arr3 =[...arr1,...arr2]
console.log(arr3)
//object: ket hop 2 object lai voi nhau
// thuộc tính trùng nhau thì lấy value của thuộc tính của object sau
var object01 ={
    name: 'hai',
    age:13,
    email:'123@gmail.com'
}
var object02 ={
    name: 'hai2',
    age2:132,
    email2:'123@gmail.com2'
}
var object03 = {...object01,...object02};
console.log({...object01,...object02});
// spread a object or array before pass to function
//------------tagged template literal
console.log('----------tagged template literal');
var course = 'Javascript'
var price = '1200'
function highLight([first,...strings],...values){
    return values.reduce(function(acc,curent){
        return [...acc,`<span id="${curent}">${curent}</span>`,strings.shift()]
    },[first]).join('')
}
let html = highLight`Khoa hoc ${course} with ${price} dola`

console.log(html);
console.log('----------test ...');

function func2(...param){
    console.log(param);
}
func2`Khoa hoc ${course} with ${price} dola`