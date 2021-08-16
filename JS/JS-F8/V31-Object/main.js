

var grade ='grade'
var student ={
    name: 'Chien',
    'age-2':21,
    mail: '123@gmail.com',
    [grade] : 3,
    getName : function(){
        return this.name;
    },
    setName:function(str){
        this.name = str;
    }
}
student.gender = 'male';
console.log(student['name']);
console.log(student['age-2']);

//delete student.gender
console.log(student);

student.setName('hai')
console.log(student.getName())
console.log('----------------------------------');
var date = new Date();
console.log(`${date.getDay}/${date.getMonth}/${date.getFullYear}`);