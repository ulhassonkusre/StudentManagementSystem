function validateForm() {
   
    resetErrorLabels();
    
    var isValid = true;

    if (!validateRequiredField('firstName', 'firstNameError') || !validateLength('firstName', 3, 15, 'firstNameError')) {
        isValid = false;
    }

    if (!validateRequiredField('lastName', 'lastNameError') || !validateLength('lastName', 2, 18, 'lastNameError')) {
        isValid = false;
    }

    var genderSelected = document.getElementById('gender').value;
    if (!genderSelected.trim()) {
        var genderErrorLabel = document.getElementById('genderError');
        genderErrorLabel.innerHTML = "This field is required";
        isValid = false;
    }


    if (!validateRequiredField('dateOfBirth', 'dateOfBirthError')) {
        isValid = false;
    } else {
        
        var ageValue = document.getElementById('age').value;
        if (!ageValue.trim()) {
            var ageErrorLabel = document.getElementById('ageError');
            ageErrorLabel.innerHTML = "This field is required";
            dateOfBirthError.innerHTML = "This field is required";            
            isValid = false;
        } else if (isNaN(ageValue) || parseInt(ageValue) < 5) {
            var ageErrorLabel = document.getElementById('ageError');
            ageErrorLabel.innerHTML = "This field is required";
            dateOfBirthError.innerHTML = "This field is required";
            isValid = false;
        }
    }

    if (!validateRequiredField('age', 'ageError') || !validateAge('age', 'ageError')) {
        isValid = false;
    }

 
    return isValid; 
}

function validateRequiredField(fieldId, errorLabelId) {
    var fieldValue = document.getElementById(fieldId).value.trim();
    var errorLabel = document.getElementById(errorLabelId);
    if (!fieldValue.trim()) {
        errorLabel.innerHTML = "This field is required";
        return false;
    }
    return true;
}

function validateLength(fieldId, minLength, maxLength, errorLabelId) {
    var fieldValue = document.getElementById(fieldId).value.trim();
    var errorLabel = document.getElementById(errorLabelId);
    if (fieldValue.length < minLength || fieldValue.length > maxLength) {
        errorLabel.innerHTML = "The " + fieldId + " should min " + minLength + " characters and max " + maxLength + " characters";
        return false;
    }
    return true;
}

function validateAge(fieldId, errorLabelId) {
    var ageValue = document.getElementById(fieldId).value;
    var errorLabel = document.getElementById(errorLabelId);
    if (ageValue < 5 || ageValue > 99) {
        errorLabel.innerHTML = "Age should between 5 and 99";
        dateOfBirthError.innerHTML = "Age should between 5 and 99";
        return false;
    }
    return true;
}

function resetErrorLabels() {
    var errorLabels = document.getElementsByClassName('error-label');
    for (var i = 0; i < errorLabels.length; i++) {
        errorLabels[i].innerHTML = "";
    }
}

document.getElementById('firstName').addEventListener('input', function () {
    document.getElementById('firstNameError').innerHTML = "";
});

document.getElementById('lastName').addEventListener('input', function () {
    document.getElementById('lastNameError').innerHTML = "";
});
document.getElementById('gender').addEventListener('input', function () {
    document.getElementById('genderError').innerHTML = "";
});

document.getElementById('age').addEventListener('input', function () {
    document.getElementById('ageError').innerHTML = "";
});

document.getElementById('age').addEventListener('input', function () {
    document.getElementById('dateOfBirthError').innerHTML = "";
});




