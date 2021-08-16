document.getElementById('sub-div').onclick=function(e){
console.log('Click sub-div');
};
document.getElementById('box').onclick=function(e){
    console.log('Clicl box DIV');
}
document.getElementById('btn').onclick=function(e){
    e.stopPropagation();
    console.log('Click button');
}

var elements =  document.getElementsByClassName('class01');
console.log(elements);

// for(var item in elements ){
// elements[item].onclick=function(e){
//     console.log(e);
//     e.stopPropagation();
//     console.log('Click class01');
//     };
// }

//-----------------
// for (const iterator of elements) {
//     iterator.onclick=function(e){
//         console.log(e);
//         e.stopPropagation();
//         console.log('Click class01');
//         };
// }