//"use strict"
//kế thừa - extend
function func01(fullName,age){
    this.fullName = fullName;
    this.age=age;
}
function func02(fullName, age, mail){
    console.log(this)
    func01.call(this, fullName, age)
    this.mail = mail

    return {
        get(){
            //console.log(this)
            return `Name: ${this.fullName}| Age: ${this.age}| Email: ${this.mail}`;
        }
    }
}
var object = func02('AnhNGuyen',13,'Anh@gmail.com')
console.log(object.get.call())
console.log(this.mail)
console.log('---------------------------------------')
//
var teacher = {
    fullName:"Minh",
    first:"Thu"
}
var student = {
    fullName:"Anh",
    first:"NGuyen",
    getFullName(){
        console.log(this)
        console.log(`Name: ${this.fullName} ${this.first}`)
    }
}
student.getFullName.call(student)
student.getFullName.call(teacher)// muon ham de in techer