//"use strict"

console.log('---------------------------------------')
//
var teacher = {
    fullName:"Minh",
    first:"Thu",
}
var student = {
    fullName:"Anh",
    first:"NGuyen",
    getFullName(data1, data2, data3){
        console.log(data1, data2, data3)
        console.log(`Name: ${this.fullName} ${this.first}`)
    }
}
student.getFullName.apply(teacher,['data1_','data2_','data3_'])
student.getFullName.call(teacher,'data1_','data2_','data3_')