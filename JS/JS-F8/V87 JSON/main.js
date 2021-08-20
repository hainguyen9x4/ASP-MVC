//var json ='1'
// var json='true'
 //var json = '["1","2","3","4","a"]'
 var json = '{"name":"Nguyen","age":13,"mail":"bac@gmail.com"}'
 var json2 = '{"name":"Nguyen","age":13,"mail":"bac@gmail.com","object1":{"addr":"1"}}'// object trong object
 var object = {
     name:"nguyen",
     age:13,
     object1:{
         addr:"HN",
         gender:"male"
     }
 }
 console.log(JSON.stringify(object));
console.log("json: "+json);

console.log(typeof JSON.parse(json2));
var ob = JSON.parse(json2);
if(ob){
    console.log(ob.name);
    console.log(ob.object1.addr);
}

 console.log("isArray: "+Array.isArray(JSON.parse(json)))
