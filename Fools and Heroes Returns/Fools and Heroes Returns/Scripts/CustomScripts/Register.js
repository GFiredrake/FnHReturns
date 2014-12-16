$(document).ready(function () {
    $(".regigisterButton").click(function () {
        if ($('#UserName').val() != "" && $('#FirstName').val() != "" && $('#Surname').val() != "" && $('#Password').val() != "" && $('#ConfirmPassword').val() != "" && $('#Email').val() != "")
        {
            ClearTextColour();
            $('#registerError').text("")
            if ($('#Password').val() == $('#ConfirmPassword').val()) {
                var registrationDetails = {
                    UserName: $('#UserName').val(),
                    FirstName: $('#FirstName').val(),
                    Surname: $('#Surname').val(),
                    Email: $('#Email').val(),
                    Password: $('#Password').val(),
                    ConfirmPassword: $('#ConfirmPassword').val()
                };
                //Ajax call to registerController
                $.ajax({
                    type: "POST",
                    url: "http://localhost:50431/Register/AttemptRegister",
                    data: registrationDetails,
                    dataType: "json",
                    success: function (data) {
                        alert("so you wanna registers")
                    },
                    error: function (data, staus, error) { alert("Im sorry we have encountered a " + error + ". Please try again") }
                });
            }
            else {
                ClearTextColour();
                $('#PasswordArea').css("color", "red");
                $('#ConfirmPasswordArea').css("color", "red");
                $('#registerError').text("The passwords do not match, please re enter and try again")
            }
        }
        else {
            ClearTextColour();
            $('#registerError').text("Yo must compleate all fields to register")
            if($('#UserName').val() == "")
            {
                $('#UserNameArea').css("color", "red");
            }
            if ($('#FirstName').val() == "") {
                $('#FirstNameArea').css("color", "red");
            }
            if ($('#Surname').val() == "") {
                $('#SurnameArea').css("color", "red");
            }
            if ($('#Password').val() == "") {
                $('#PasswordArea').css("color", "red");
            }
            if ($('#ConfirmPassword').val() == "") {
                $('#ConfirmPasswordArea').css("color", "red");
            }
            if ($('#Email').val() == "") {
                $('#EmailArea').css("color", "red");
            }
        }
    });

    function ClearTextColour() {
        $('#UserNameArea').css("color", "black");
        $('#FirstNameArea').css("color", "black");
        $('#SurnameArea').css("color", "black");
        $('#PasswordArea').css("color", "black");
        $('#ConfirmPasswordArea').css("color", "black");
        $('#EmailArea').css("color", "black");
    };
});