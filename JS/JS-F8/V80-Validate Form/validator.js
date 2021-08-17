
var selectorRules ={};// 

function Validator(option) {
/*
Validate the input element
*/
    function validateInput(elementInput,rule,elementMsg){
        var mes;
        //console.log("mes in validateInput func: "+mes);
        
        var rules = selectorRules[rule.selector];//lấy các rule của 1 slector cụ thể
        for(var i=0 ;i< rules.length;i++){// duyệt qua các rule của selector
            mes = rules[i](elementInput.value);// thực hiện rule và trả về message
            if(mes) break;
        }
        if(mes){
            if(elementMsg){
                elementMsg.innerText = mes;
                elementMsg.classList.add('invalid');
            }
        }
    }

    var elementForm = document.querySelector(option.form);

    if(elementForm){
        option.rules.forEach(function(rule) {
            
            if(Array.isArray(selectorRules[rule.selector])){
                selectorRules[rule.selector].push(rule.test);// lan tiep theo them vao mang
            }else{
                selectorRules[rule.selector] =[rule.test]//lan dau tien chua là mảng, se khoi tao mang
            }
            var inputElement = elementForm.querySelector(rule.selector);
            var elementMsg = inputElement.parentElement.querySelector(option.selectorMesError);
            inputElement.onblur = function(){
                validateInput(inputElement,rule,elementMsg);
            }
            inputElement.oninput = function(){
                elementMsg.innerText = '';
                elementMsg.classList.remove('invalid');                
            }
        });
    }
}
/*
Validate the input element
selector: selecter truyen vao
mesError: custom error, nếu ko truyên thì dùng mặc định là 'This field is required!'
Mỗi thằng sẽ cách verify khác nhau -> có 1 hàm test khác nhau
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
                return value >= 6 && value < 8 ? undefined : mesError||`Length must be ${min}-${max} characters!`
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