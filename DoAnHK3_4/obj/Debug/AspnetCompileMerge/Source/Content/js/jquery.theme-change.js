$(document).ready(function(){
    $("#change_theme").click(function(){

        //Variable declaration and assignment
	var theme01 = $("input[name='theme']:checked").val();
	//var theme02 = $("#theme02").val();
	var Themeid = $("#Themeid").val();
	var bgcolor = $("#bgcolor").val();
	var txtcolor = $("#txtcolor").val();
	var fontstyle= $("#FontStyle").val();
	var theme_bg = '';
	var theme_txt = '';

        //alert(theme01);

	if(theme01 != '')
	{
		if(theme01 == 'selecttheme')
		{
			if(Themeid == 'Theme1')
			{
				theme_bg = '#a71919';
				theme_txt = '#ff0000';
			}
			else if(Themeid == 'Theme2')
			{
				theme_bg = '#e4d522';
				theme_txt = '#b400ff';
			}
			else if(Themeid == 'Theme3')
			{
				theme_bg = '#0c0c0b';
				theme_txt = '#27ff00';
			}
			else
			{
				theme_bg = 'Default';
				theme_txt = 'Default';
			}
		}
		if(theme01 == 'selectcolor')
		{ 
			if(bgcolor != '' && txtcolor != '')
			{
				theme_bg = bgcolor;
				theme_txt = txtcolor;
			}
			else
			{
				theme_bg = 'Default';
				theme_txt = 'Default';
			}
		}
	}



        if(theme_bg != '' && theme_txt != '') 
        {
		var dataString = '&theme_bg=' + theme_bg +  '&theme_txt=' + theme_txt + '&fontstyle=' + fontstyle + '&change_theme=1&theme='+theme01+"&themeid="+Themeid;

                //document.write(dataString); die;
                $.ajax({
                        type: "POST",
                        url: "change_theme.php",
                        data: dataString,
                        beforeSend: function()
                        {
                                //Show loading image
                                $("#change_theme_response").html('<div class="succ green_a"><strong>Changing...</strong>Please Wait!</div>');

                        },
                        success: function(response)
                        {
                                //Check to see if the message is sent or not
                                var change_theme_response = response.indexOf('Congrats');
                                if( change_theme_response != -1 )
                                {
                                        //Clear all form fields on success
                                        $("#theme_bg").val('');

                                        //Display success message if the message is sent
                                        $("#change_theme_response").html(response);

                                        //Remove the success message also after a while of displaying the message to the user
                                        setTimeout(function() {
                                                $("#change_theme_response").html('');
                                        },10000);
                                }
                                else
                                {
                                        //Display error message is the message is not sent
                                         $("#change_theme_response").html(response);
                                }
                        }
                });
        }

   });

});
