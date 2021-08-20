var users=[
    {
        id:1,
        name:"Nguyen Ánh",
    },
    {
        id:2,
        name:"Nguyen Chien",
    },
    {
        id:3,
        name:"Nguyen Chuc",
    },
]
var comments=[
    {
        id:1,
        id_user:1,
        content:"Tôi tên là Anh",
    },
    {
        id:2,
        id_user:2,
        content:"Tôi tên là Chiến",
    },
    {
        id:3,
        id_user:3,
        content:"Tôi tên là Chúc",
    }
]

//
var promise = new Promise(function(resolve, reject){
    setTimeout(function(){ },500)//lay data comments

    comments?resolve(comments):reject('Error comments lack');
})
promise.then(function(comments){
    setTimeout(function(){},500)//lay data users
    return new Promise(function(resolve, reject){
        users?resolve({
            users: users,
            comments:comments,
        }):reject('Error users lack');
    })
})
.then(function(data){
     var  arr = data.comments.reduce(function(html,comment,i){
        var user = data.users.find(function(u){
            return u.id == comment.id_user;
        })
        return html+=`<li> Name: ${user.name}-Comment: ${comment.content}</li>`
        // return acc.concat([{
        //     user:user.name,
        //     comment:comment.content,
        // }])
    },'')
    // var html=''
    // arr.forEach(element => {
    //     html+=`<li> Name: ${element.user}-Comment: ${element.comment}</li>`
    // });
document.getElementById('comment-block').innerHTML=arr;

})
.catch(function(err){
    console.log(err);
})