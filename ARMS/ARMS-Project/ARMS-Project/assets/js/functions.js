$(document).ready(function() {
	
	// hide stuff	
	$('.viewWindow').hide();
	$('a.viewSave').hide();
	$('#secondary').hide();
	$('#viewAddFiles').hide();
	$('.viewActions').hide();
	
	// close pop up
	$('a.close').click(function() {
		$(this).parent().hide();
		$('#mask').hide();
	});
	
	// open view antibody popup
	$('a.view').click(function(e) {
		e.preventDefault();
		var id = '#view-' + $(this).attr("href");
		
		var maskHeight = $(document).height();
		var maskWidth = $(window).width();
		$('#mask').css({'width':maskWidth,'height':maskHeight});
		
		$('#mask').fadeIn(500);
		
		//Get the window height and width
	    var winH = $(window).height();
	    var winW = $(window).width();
	           
	    //Set the popup window to center
	    $(id).css('top',  (winH-$(id).height())/2);
	    $(id).css('left', (winW-$(id).width())/2);
		
		$(id).fadeIn(500);
		
	});
	
	// handles antibody edit 
	$('a.viewEdit').click(function(e) {
		e.preventDefault();
		var form = "#" + $(this).parent().find('form').attr('id');
		$(form + " :input").each(function(){
			$(this).attr('disabled', false)
		});
		$(this).hide();
		$(this).parent().find('a.viewSave').show();
		$('#viewAddFiles').show();
		$('.viewActions').show();
	});
	
	// handles antibody save
	$('a.viewSave').click(function(e) {
		e.preventDefault();
		alert('Are you sure you want to save the edits?');
		var form = "#" + $(this).parent().find('form').attr('id');
		$(form + " :input").each(function(){
			$(this).attr('disabled', true)
		});
		$(this).hide();
		$(this).parent().find('a.viewEdit').show();
		$('#viewAddFiles').hide();
		$('.viewActions').hide();
	});
	
	// handles antibody select menu
	$('#antibodySelect').change(function() {
		var id = $(this).find(":selected").val();
		$('#' + id).show();
		if (id=='primary') {
			$('#secondary').hide();
		} else {
			$('#primary').hide();
		}
	});
	
	// adds file input
	$('.addFile').click(function(e) {
		e.preventDefault();
		$(this).parent().prepend('<li><input type="file" /></li>');
	});

});