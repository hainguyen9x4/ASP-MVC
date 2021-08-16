var btn = document.querySelector('#btn01');
btn.onclick=function(e){
console.log(e);
}

var elements = document.getElementsByClassName('class01');
console.log(elements);
for(var i in elements){
    elements[i].onclick = function(e){
        console.log(e.target);
    }
}