function validateForm() {
    var lname = document.getElementById('lname').value;
	var check=false;
	if (!lname) {
         document.getElementById("lnameErr").innerHTML = "Please Enter Last Name";
		 check=true;
    }
	else {
        document.getElementById("lnameErr").innerHTML = "";
    }
	
	var email = document.getElementById('email').value;
	if (!validateEmail(email)) {
         document.getElementById("emailErr").innerHTML = "Please Enter Valid Email ID";
		 check=true;
    }
	else {
        document.getElementById("emailErr").innerHTML = "";
    }
	
	var line1 = document.getElementById('line1').value;
	if (!line1) {
         document.getElementById("line1Err").innerHTML = "Address Line 1 is Required";
		 check=true;
    }
	else {
        document.getElementById("line1Err").innerHTML = "";
    }
	
	var city = document.getElementById('city').value;
	if (!city) {
         document.getElementById("cityErr").innerHTML = "City is Required";
		 check=true;
    }
	else {
        document.getElementById("cityErr").innerHTML = "";
    }
	
	var postcode = document.getElementById('postcode').value;
	if (!validatePostCode(postcode)) {
         document.getElementById("postCodeErr").innerHTML = "Please Enter a Valid Post Code (Should be 5 digits in length)";
		 check=true;
    }
	else {
        document.getElementById("postCodeErr").innerHTML = "";
    }
	
	var country = document.getElementById('country').value;
	if (country=='-1') {
         document.getElementById("countryErr").innerHTML = "Country is Required";
		 check=true;
    }
	else {
		document.getElementById("countryErr").innerHTML = "";
    }
		
	var phone = document.getElementById('phone').value;
	if (!validatePhone(phone)) {
         document.getElementById("phoneErr").innerHTML = "Please Enter a Valid Phone Number (Should be within 10 to 13 digits in length)";
		 check=true;
    }
	else {
        document.getElementById("phoneErr").innerHTML = "";
    }
	
	/*var products = document.getElementById('productslist').value;
	if (!products) {
         document.getElementById("productErr").innerHTML = "Please Select Products";
		 check=true;
    }
	else {
        document.getElementById("productErr").innerHTML = "";
    }*/
	
	var selects = document.getElementById("productslist");

	var s="";
 
	for (var i = 0; i < selects.options.length; i++) {
		if(selects.options[i].selected){
         s+=(selects.options[i].text)+",";
		}
	}
	if(s){
		document.getElementById("prodList").value = s;
	}
	else{
		document.getElementById("productErr").innerHTML = "Please Select Products";
		check=true;
	}
	if(check){
		return false;
	}
	return true;
}

function clearErrors() {
    document.getElementById("lnameErr").innerHTML = "";
    document.getElementById("emailErr").innerHTML = "";
    document.getElementById("line1Err").innerHTML = "";
    document.getElementById("cityErr").innerHTML = "";
    document.getElementById("postCodeErr").innerHTML = "";
    document.getElementById("countryErr").innerHTML = "";
    document.getElementById("phoneErr").innerHTML = "";
    document.getElementById("productErr").innerHTML = "";
}

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function validatePhone(phone) {
    phone = phone.replace(/[^0-9]/g, '');
	if(phone.length >= 10&&phone.length <= 13) { 
		return true;
	} else {
		return false;
	}
}
function validatePostCode(postCode) {
    postCode = postCode.replace(/[^0-9]/g, '');
	if(postCode.length != 5) { 
		return false;
	} else {
		return true;
	}
}
