/*
Validate funtion
-parameter: option is a object:
+ form: id from need validate
+ selectorMesError: class name of message element in each form
(in form has many form-group)
+ rules: [// a array of function
            Validator.isRequired('#fullname'),//validate cho cac trường bắt buộc
            Validator.isRequired('#email'),// e mail cos 2 validate
            Validator.isEmail('#email','Ban phai nhap email'),//email
            Validator.isRequired('#password'),
            Validator.validateLength('#password', 6, 8),// độ dài của trường
            Validator.isRequired('#re-password'),
            Validator.isConfirm('#re-password',function(){// lặp lại 1 trường nào đó
                return document.querySelector('#form-1 #password').value;
            }),
        ],
+ onSubmit: function(data){// function of event submit button, 
                            this is option cause can use the defualt event of form
            console.log(data);
        }

 */
function Validator(option) {
    var selectorRules ={};// 
/*
Validate the input element
-Ko co loi tra ra là true, co lói tra ra la false
*/
    function validateInput(elementInput,rule,elementMsg){
        var mes;
        
        var rules = selectorRules[rule.selector];//lấy các rule của 1 slector cụ thể
        
        for(var i=0 ;i< rules.length;i++){// duyệt qua các rule của selector
            switch (elementInput.type) {
                case 'radio':
                    mes = rules[i](elementForm.querySelector(rule.selector+':checked'));
                    break;
                case 'checkbox':
                    
                    break;           
                default:
                    mes = rules[i](elementInput.value);// thực hiện rule và trả về message
                    break;
            }
            
            if(mes) break;
        }
        if(mes){
            if(elementMsg){
                elementMsg.innerText = mes;
                elementMsg.classList.add('invalid');
                isError = false;
            }
        }else{
            elementMsg.innerText = '';
            elementMsg.classList.add('invalid');           
        }
        return !mes;
    }

    var elementForm = document.querySelector(option.form);

    if(elementForm){
        //xu ly khi nhan nut resgiter
        elementForm.onsubmit = function(e){
            e.preventDefault();
            var isFormValid = true;
            //lap qua từng rule và gọi validate, nếu có lỗi thì báo lỗi và báo form is invalid.
            option.rules.forEach(rule => {
                var inputElement = elementForm.querySelector(rule.selector);
                var elementMsg = inputElement.parentElement.querySelector(option.selectorMesError);
                if(!validateInput(inputElement,rule,elementMsg))
                {
                    isFormValid = false; 
                }
            });
            //neu form valid thi thuc hien lay data form
            if(isFormValid){
                //submit với javaScript
                if(typeof option.onSubmit === 'function'){
                var enableInputs = elementForm.querySelectorAll('[name]:not([disable])');//ko lay thang disable
                //duyet tat ca để đưa vào object là 1 mảng các values
                var formValues = Array.from(enableInputs).reduce(function(values,item){
                    switch(item.type){
                        case 'radio':
                            values[item.name] = elementForm.querySelector('input[name="'+item.name+'"]:checked').value;
                            break;
                        case 'checkbox':
        
                        default:
                            values[item.name]=item.value;
                            break;
                    }
                    
                    return values;
                },{});
                option.onSubmit(formValues);
            }
            //Submit mặc định với onsubmit của form
            else{
                elementForm.onsubmit();
            }
        }
        };
        //Lap qua cac rule để gán event cho mỗi rule
        option.rules.forEach(function(rule) {
            
            //Tạo mảng rule vì 1 selector có thể chạy nhieu rules: rule required, rule là email, chiều dài kí tự
            if(Array.isArray(selectorRules[rule.selector])){
                selectorRules[rule.selector].push(rule.test);// lan tiep theo them vao mang
            }else{
                selectorRules[rule.selector] =[rule.test]//lan dau tien chua là mảng, se khoi tao mang
            }

            var inputElements = elementForm.querySelectorAll(rule.selector);
            Array.from(inputElements).forEach(inputElement => {
                var elementMsg = inputElement.parentElement.querySelector(option.selectorMesError);
                inputElement.onblur = function(){
                    //console.log("inputElement.value: "+inputElement.value);
                    validateInput(inputElement,rule,elementMsg);
                }
                inputElement.oninput = function(){
                    elementMsg.innerText = '';
                    elementMsg.classList.remove('invalid');                
                } 
            });
        });
    }
    /*
    gat parent element of element,
    param: 
    +element: child element 
    +parentName: Name of parent element 
    Return: parent element of element, or null if not exit the parent as parentName
    */
    function getParent(element, parentName){
            while(element.parentElement){
                if(element.parentElement.matches(parentName))
                {
                    return element.parentElement;
                }
                element = element.parentElement;
            }
        }
    }
/*
Validate the input element
selector: selecter truyen vao
mesError: custom error, nếu ko truyên thì dùng mặc định là 'This field is required!'
Mỗi thằng sẽ cách verify khác nhau -> có 1 hàm test khác nhau
+return là 1 object
+hàm test là hàm cụ thể thực hiện verify chi tiết, mỗi trường sẽ có hàm test thực hiện khác nhau
*/
Validator.isRequired = function(selector, mesError){
    return {
        selector: selector,
        test: function(value){
            //console.log('value in test func: '+value);
            return value ? undefined : mesError||'This field is required!'
        }
    };
}
Validator.isEmail = function(selector, mesError){
    return {
        selector: selector,
        test: function(value){
            var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : mesError||'This field is email!'
        }
    };
}
Validator.validateLength = function(selector, min, max, mesError){
        return {
            selector: selector,
            test: function(value){
                return value.length >= 6 && value.length <= 8 ? undefined : mesError||`Length must be ${min}-${max} characters!`
            }
        };
}
Validator.isConfirm = function(selector, getData, mesError){
    return {
        selector: selector,
        test: function(value){
            return value === getData() ? undefined : mesError||'Confirm data is not corrected!';
        }
    };
}
Validator.onCommit = function(selector, getData){
    return {
        selector: selector,
        execute: getData
    };
}