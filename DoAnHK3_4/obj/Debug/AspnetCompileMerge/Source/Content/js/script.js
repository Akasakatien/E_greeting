$(function(){
	$(".span3").slice(0,9).show();
	$("#1168").on('click',function (e) {
		e.preventDefault();
		
		$(".span3:hidden").slice(0,6).slideDown();
		if ($(".span3:hidden").length == 0){
			$("#load").fadeOut('slow');
		}
		$('html,body').animate({
			scrollTop: $(this).offset().top
		}, 1500);
	});
});