$(document).ready(function () {
    $(".logInButton").click(function () {
        var logInDetails = {
            UserName: $('#UserName').val(),
            Password: $('#Password').val()
        };
        if(logInDetails.UserName != "" && logInDetails.Password != "")
        {
            $.ajax({
                type: "POST",
                url: "LogIn/AttemptLogIn",
                data: logInDetails,
                dataType: "json",
                success: function (data) {
                    //if username or password hasnot been filled in but has somehow made it to the controller
                    if(data == 0)
                    {
                        $('#logInError').text("Im sorry we have encountered an error please re-enter your information and try again.")
                    }
                    //If Username dose not exist
                    if(data == 1)
                    {
                        $('#logInError').text("The username you supplied please check and try again.")
                    }
                    //If password dose not match user name
                    if (data == 2) {
                        $('#logInError').text("The password you supplied is incorect please check and try again.")
                    }
                    //If successfull
                    if (data == 3) {
                        //load index page
                    }
            },
                error: function (data, staus, error) { alert("Im sorry we have encountered a " + error + ". Please try again") }
            });
        }
        else
        {
            $('#logInError').text("Username or Password has been left blank, please try again.")
        }
    });
});