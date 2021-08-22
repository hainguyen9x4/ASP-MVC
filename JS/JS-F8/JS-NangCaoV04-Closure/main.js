function logger(prefix){
    function log(mes){
        console.log(`[${prefix}]`+mes)
    }
    return log;
}

var myLogInfor= logger('Infor');
myLogInfor('Enter the email');
var myLogError= logger('Error');
myLogError('Have error!!!');
// Save local setting in client: theme of web page

console.log("---------localStorage---------")
var key ="setting";
function createStorage(key){
var store = JSON.parse(localStorage.getItem(key))??{}

function save(){
    localStorage.setItem(key,JSON.stringify(store));
}
return{
    get(key){
        return store[key];
    },
    set(key,value){
        store[key]=value;
        save();
    },
    remove(key){
        delete store[key];// xoa 1 key-value trong object
        save();
    }
}
}
var settingInfo = createStorage('setting01');
console.log(settingInfo.get('name'));
settingInfo.set('name','Javascript');
console.log(settingInfo.get('age'));
settingInfo.set('age','13');
settingInfo.remove('name');

