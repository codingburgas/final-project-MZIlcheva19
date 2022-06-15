function signup(e) {

	let email = document.getElementById('email').value;
	let fullname = document.getElementById('fullname').value;
	let pass = document.getElementById('password').value;
	if(email == ""){
		alert("You should enter an email")
		return false;

	}
	if(pass == ""){
		alert("You should enter a password")
		return false;

	}
	if(fullname == ""){
		alert("You should enter a name")
		return false;

	}

	let userArray =JSON.parse(localStorage.getItem('userArray')) ;

	if (userArray != null) {
		if (userArray.find(user => user.email.toLowerCase() == email.toLowerCase())) {
			alert("There is already an user with this email")
			return false;
		}
	}
	else{
		userArray = [];
	}
	

	let user = {
		email: email,
		fullname: fullname,
		password: pass,
	};

	userArray.push(user);

	let json = JSON.stringify(userArray);
	localStorage.setItem('userArray', json);
	console.log('user added');
	alert('You may now log in')
	window.location.href="../pages/register.html";
}

function loginFunc(e) {
	

	let email = document.getElementById('email').value;
	let password = document.getElementById('password').value;
	let userArray =JSON.parse(localStorage.getItem('userArray'));
	
	
	if(userArray == null){
		alert("Email or password is incorrect")
		return false;
	}
	if(email == "" || password == ""){
		alert("You should enter an email or password")
		return false;

	}
	
	if (userArray.find(user => user.email.toLowerCase() == email.toLowerCase())) {
		let index = userArray.findIndex(user => user.email.toLowerCase() == email.toLowerCase());
		
		if (index != -1 && userArray[index].password == password) {
			let user = userArray[index];
			localStorage.setItem("activeUser", JSON.stringify(user))
			alert("You are logged in")
			window.location.href="../index.html";
			return false;
		}
		

	}

	alert("Email or password is incorrect")

}