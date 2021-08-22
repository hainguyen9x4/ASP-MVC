(function myFunc(name){
console.log('Hello: '+ name);
})("VanNguyen")


var app= (function(){
    var car=[];
    return {
        add(name){
            car.push(name)
        },
        edit(i,name){
            car[i]=name
        },
        delete(i){
            car.slice(i,1)
        },
        get(i){
            return car[i]
        },
        getAll(){
            return car;
        }
    }
})()

app.add("VinFast");
app.add("BMW");
app.add("Mazda");
console.log(app.getAll())


var obj = {
    car:[],
    add(name){
        car.push(name)
    }
}
obj.car.push("1","2","3")
console.log(obj.car)

{
    {
        {
            
            console.log("Age:"+age)
            var age =12;
        }
    }
}