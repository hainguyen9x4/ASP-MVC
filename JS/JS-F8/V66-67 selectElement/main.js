console.log(document.getElementById('btn01'));
console.log(document.getElementsByClassName('class01'));
console.log('--------------querySelectorAll-------------');
var element = document.querySelectorAll('.class01');
console.log(element);
console.log('--------------querySelector-------------');
var element = document.querySelector('.box .class01:nth-child(2)');
console.log(element);