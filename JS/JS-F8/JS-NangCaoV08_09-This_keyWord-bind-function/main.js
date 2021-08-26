console.log(this.document)
const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);
var app = (()=>{
    var cars=["CRV"];
    var block = $('#car-block');
    return {
        add(name){
            cars.push(name);
        },
        delete(index){
            cars.splice(index,1)
        },
        render(){
            var html = cars.map(function(car,i){
                return `<li>${car} <span class="delete" data-index="${i}">x</span></li>`
            }).join('');
            block.innerHTML = html;
        },
        handleNewCar(e){
            console.log(e.target)
            var del =e.target.closest(".delete");// closest để xem 1 element có class .delete hay ko
           if(del){
            this.delete(e?.target?.dataset?.['index'])
           }
            console.log(cars)
            this.render()
        },
        init(){
            this.render()
            block.onclick = this.handleNewCar.bind(this)
        }
        
        
    }
})()
app.add("BMW");
app.add("Posche");

app.init();
