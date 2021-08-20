var p = new Promise(function(resolve, reject){
    resolve({
        name:"hai",
        age:13
    });
})
p.then(function(data){
console.log(data);
})
.catch(function(error){
    console.log(error);
})
.finally(function(){
    console.log("Done-------");
})
//////////////////////////////////////////////////////////
console.log("----------------------------------------");
var promise1 = new Promise(function(resolve, reject){
    resolve(12);
    //reject();
});
promise1
.then(function(data){
    console.log(data);
    return data+"1";
})
.then(function(data){
    console.log(data);
    return new Promise(function(r,j){
        r(data+2);
    })
})
.then(function(data){
    console.log(data);
    return Promise.reject('77')

})
.catch(function(data){
    console.log("error: "+data);
})
.finally(function(){
    console.log("Done all");
})

var a =12;
if(a>0){
    var b=7;
}
console.log(b);