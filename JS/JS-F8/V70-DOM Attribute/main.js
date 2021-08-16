var element = document.querySelector('a');
console.log(element);
element.href = 'link';
element.title ='title'
element.setAttribute('class','class01')
element.setAttribute('id','link01')
element.setAttribute('data-id','dat01')
console.log(element.getAttribute('data-id'))