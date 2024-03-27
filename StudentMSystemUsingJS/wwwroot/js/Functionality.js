

document.addEventListener('DOMContentLoaded', function () {
    setGenderSelection();
});

function setGenderSelection() {
    var genderDropdown = document.getElementById('gender');
    var selectedGender = genderDropdown.getAttribute('data-selected');

    for (var i = 0; i < genderDropdown.options.length; i++) {
        if (genderDropdown.options[i].value === selectedGender) {
            genderDropdown.options[i].selected = true;
            break;
        }
    }
}

function cancelEdit() {
    // Redirect back to the index page when cancel is clicked
    window.location.href = '/Index';
} 
document.getElementById('dateOfBirth').addEventListener('input', function () {
    var dob = new Date(this.value);
    var today = new Date();
    var age = today.getFullYear() - dob.getFullYear();
   
    if (today.getMonth() < dob.getMonth() || (today.getMonth() === dob.getMonth() && today.getDate() < dob.getDate())) {
        age--;
    }
    document.getElementById('age').value = age;
});
document.getElementById('age').addEventListener('input', function () {
    var age = parseInt(this.value);
    if (!isNaN(age) && age >= 0) {
        var today = new Date();
        var birthYear = today.getFullYear() - age;
        var birthMonth = today.getMonth() + 1; 
        var birthDay = today.getDate();
        document.getElementById('dateOfBirth').value = birthYear + '-' +
            (birthMonth < 10 ? '0' : '') + birthMonth + '-' +
            (birthDay < 10 ? '0' : '') + birthDay;
    }
});

function deleteStudent() {

    var confirmDelete = confirm("Are you sure you want to delete this student?");

    if (confirmDelete) {

        document.getElementById("DeleteFlag").value = "true";

        document.querySelector('form').submit();
    }
}