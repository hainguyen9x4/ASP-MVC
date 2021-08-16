var arr = [
    {
        id:1,
        name:'hai',
        age:13,
        email:'123@gmail'
    },
    {
        id:2,
        name:'hai2',
        age:13,
        email:'123@gmail'
    },
    {
        id:3,
        name:'hai3',
        age:13,
        email:'123@gmail'
    },
    {
        id:4,
        name:'hai4',
        age:15,
        email:'123@gmail'
    },
];
var s = arr.find((item,i)=>{
            return item.id==1;
            });
console.log(s);
var s = arr.filter((item,i)=>{
    return item.age==13;
    });
console.log(s);
var s = arr.some((item,i)=>{
    return item.id==4;
    });
console.log(s);
var s = arr.every((item,i)=>{
    return item.id==4;
    });
console.log(s);
console.log("------------map()----------------");
    arr.map((item,i)=>{
        item.grade=7
        //item.id+=1
    })
    console.log(arr);
console.log("------------map2()----------------");
  var arr2=  arr.map((item,i)=>{
        item.grade=7,
        item.id=item.id+1
        return item;
    })
    console.log(arr2);
    console.log("------------reduce()----------------");
    console.log(arr);
    var idSum=  arr.reduce(function(value,item,i){ 
        console.log(item.id); 
        return value+item.id;
      },0)
      console.log(idSum);
      console.log("------------reduce-flat array from depth array()----------------");
      var depthArray = [1,2,3,[4,5,6],[7,8,9],[0]]
      var flatArr=  depthArray.reduce(function(flatarray,item,i){ 
          return flatarray.concat(item);
        },[])
        console.log(flatArr);
        console.log("------------reduce-----------------");
        var courses = [
            {
                topic:'Front-end',
                course:
                [
                    {
                     title:'html',
                        id:1
                    },
                    {
                        title:'css',
                        id:2
                    },
                    {
                        title:'JS',
                        id:3
                    },
                ]
                
            },
            {
                topic:'Back-end',
                course:
                [
                    {
                        title:'C#',
                        id:1,
                    },
                    {
                        title:'NodeJs',
                        id:2,
                    },
                    {
                        title:'Java',
                        id:3,
                    }
                ]   
            }
        ]
        var khoaHoc=  courses.reduce(function(course,item,i){ 
            return course.concat(item.course);
          },[])
          console.log(khoaHoc);      
          console.log("------------forEach-----------------");
