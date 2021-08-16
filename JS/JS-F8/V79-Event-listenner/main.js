var btn = document.getElementById('btn01');

function task1(){
    console.log("task1");
}
function task2(){
    console.log("task2");
}
function task3(){
    console.log("task3");
}
btn.addEventListener('click',task1);
btn.addEventListener('click',task2);
btn.addEventListener('click',task3);
setTimeout(function(){
    btn.removeEventListener('click',task3);
},3000)