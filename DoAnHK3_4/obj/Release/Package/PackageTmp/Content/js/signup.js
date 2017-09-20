$(document).ready(function(){
    $("#nic-signin").click(function(){

        //Variable declaration and assignment
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        var nic_email = $("#nic_email").val();
        var nic_password = $("#nic_password").val();

        //alert("test");

        if( nic_email == "" ) //Validation against empty field for email address
        {
                $("#response_brought_nic").html('<div class="err red_a"><strong>Error</strong> Message! - Please enter your email in the required field to proceed.</div>');
                $("#nic_email").focus();
        }
        else if(reg.test(nic_email) == false) //Validation for working email address
        {
                $("#response_brought_nic").html('<div class="err red_a"><strong>Error</strong> Message! - Sorry, your email address is invalid. Please enter a valid email address to proceed. </div>');
                $("#nic_email").focus();
        }
        else if( nic_password == "" ) //Validation against empty field for Password
        {
                $("#response_brought_nic").html('<div class="err red_a"><strong>Error</strong> Message! - Please enter your password in the required field to proceed.</div>');
                $("#nic_password").focus();
        }
        else
        {
                var dataString = '&nic_email=' + nic_email +  '&nic_password=' + nic_password + '&submitted=2';
                //document.write(dataString); die;
                $.ajax({
                        type: "POST",
                        url: "signin-process.php",
                        data: dataString,
                        beforeSend: function()
                        {
                                //Show loading image
                                $("#response_brought_nic").html('<div class="succ green_a"><strong>Loading...</strong>Please Wait!</div>');

                        },
                        success: function(response)
                        {
                                //Check to see if the message is sent or not
                                var response_brought_nic = response.indexOf('Congrats');
                                if( response_brought_nic != -1 )
                                {
                                        //Clear all form fields on success
                                        $("#e_email").val('');
                                        $("#e_email").val('');
                                        $("#e_password").val('');

                                        //Display success message if the message is sent
                                        $("#response_brought_nic").html(response);

                                        //Remove the success message also after a while of displaying the message to the user
                                        setTimeout(function() {
                                                $("#response_brought_nic").html('');
                                        },10000);
                                }
                                else
                                {
                                        //Display error message is the message is not sent
                                         $("#response_brought_nic").html(response);
                                }
                        }
                });
        }

   });

});
