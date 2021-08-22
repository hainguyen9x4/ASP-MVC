var urlComment ="http://localhost:3000/comments";
var urlUser ="http://localhost:3000/users";

var pComments= fetch(urlComment).then (res=>{
    if(res.status != 200) return Promise.reject(urlComment+":"+res.status)
    return res.json()
})
.catch(err=>console.log("Error: "+err))

var pUsers= fetch(urlUser).then (res=>{
    if(res.status != 200) return Promise.reject(urlUser+":"+res.status)
    return res.json()
})
.catch(err=>console.log("Error: "+err))

Promise.all([pComments,pUsers])// tat ca cac promise phai resolve thi moi vao .then cua.all
.then(function([result1,result2]){
    console.log(result1);
    console.log(result2);
})



// var url ="http://localhost:3000/comments";
// fetch(url)
// .then(function(response){
//     return response.json()
// })
// .then(function(comments){
//     let urlApi = "http://localhost:3000/users";
//     fetch(urlApi)
//     .then(function(response){
//         return response.json();
//     })
//     .then(function(users){
//         let html= comments.reduce(function(acc,comment,i){
//             return acc+=`<li>Name:${users.find(function(user){
//                 return user.id==comment.id_user
//             }).name}-</br>Comment:${comment.content}</li>`;
//         },'')
//         document.getElementById('comment-block').innerHTML = html;
//     })
// })
// .catch(function(err){
//     console.log(err);
// })

// function start(){
//     getComments(function(comments){
//        //console.log(comments);
//        getUsers(function(users){
//         //console.log(users);
//         let html= comments.reduce(function(acc,comment,i){
//             var user = users.find(function(user){
//                 return user.id==comment.id_user
//             })
//             return acc+=`<li class="class-${user.id}">Name:${user.name}-</br>Comment:${comment.content}</li>
//             <button onclick="onDelete(${user.id})">Delete</button>
//             <button onclick="onEdit(${user.id})">Edit</button>`;
//         },'')
//         document.getElementById('comment-block').innerHTML = html;        
//     })
//     })

//     console.log();
// }
// start();

// function getComments(callback){
//     fetch("http://localhost:3000/comments")
//     .then(function(response){
//         if(response.status != 200){
//             return Promise.reject(response.status)
//         }
//         return response.json()
//     })
//     .then(callback)
//     .catch(function(err){
//         console.log('Error: '+err);
//     })
// }
// function getUsers(callback){
//     fetch("http://localhost:3000/users")
//     .then(function(response){
//         if(response.status != 200){
//             return Promise.reject(response.status)
//         }
//         return response.json();
//     })
//     .then(callback)
//     .catch(function(err){
//         console.log(err);
//     })
// }
// document.querySelector('#btnCreate').onclick= function(){
//     // create 2 object comment and user
//     var user = {
//         name:document.querySelector('input[name="name"]').value,
//         email:document.querySelector('input[name="email"]').value,
//     }
//     //console.log(user);
//     fetch("http://localhost:3000/users",{
//         method:'POST',
//         headers:{
//             'Content-Type':'application/json'
//         },
//         body:JSON.stringify(user)
//     })
//     .then(response => response.json())
//     .then(function(user){
//         //console.log(user);
//         var comment = {
//             content:document.querySelector('input[name="content"]').value,
//             id_user:user.id,
//         }
//         fetch("http://localhost:3000/comments",
//         {
//             method:'POST',
//             headers:{
//                 'Content-Type':'application/json'
//             },
//             body:JSON.stringify(comment)
//         })
//         .then(response=>response.json())
//         .then(function(comment){
//             //update comment UI
//             var html2 = `<li class="class-${user.id}">Name:${user.name}-</br>Comment:${comment.content}</li>
//             <button onclick="onDelete(${user.id})">Delete</button>
//             <button onclick="onEdit(${user.id})">Edit</button>`
//             document.getElementById('comment-block').innerHTML+=html2;
//             //console.log(comment);
//         })

//     })
// }
