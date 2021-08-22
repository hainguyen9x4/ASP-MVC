"use strict";

// fullName ="hainguye";
// console.log(fullName)
// function func(){
//     "use strict";
//      age =13;//not define
//     console.log(fullName);
//     subFunc=function(){
//         console.log('the subFunction')
//     }
// }
// func()
// subFunc();//not define
// strict mode khong the gan lai  cho property un-re-writable cua object
const obj ={
    fullName :"Nguyen van A",// khai bao như này là writable =true, có thể sửa value
    age:13
}
obj.fullName ="Nguyen Van B";
console.log(obj)

const obj2 = Object.freeze({// tao ra 1 object voi các thuộc tính chỉ đọc
    fullName:"Nguyen Anh",
    age:21
})
obj2.fullName ="NGyen avn Đ"//Cannot assign to read only property in strict mode
console.log(obj2);
//Các tạo object tường minh:
const obj3 = Object.setPrototypeOf('fullName',{
    value : "Nguyen CHi doc",
    writable :false
})
obj3.fullName = "NGuyen Tuan Sơn"//Cannot assign to read only property 
