function getScrollTop() {
	return f_scrollTop();
}

function f_scrollTop() {
	return f_filterResults($(window) ? $(window).scrollTop() : 0,
			document.documentElement ? document.documentElement.scrollTop : 0,
			document.body ? document.body.scrollTop : 0);
}
function f_filterResults(n_win, n_docel, n_body) {
	var n_result = n_win ? n_win : 0;
	if (n_docel && (!n_result || (n_result > n_docel)))
		n_result = n_docel;
	return n_body && (!n_result || (n_result > n_body)) ? n_body : n_result;
}

function setScrollTop() {
	$(window) ? $(window).scrollTop(0) : 0;
	document.documentElement ? document.documentElement.scrollTop = 0 : 0;
	document.body ? document.body.scrollTop = 0 : 0;
}

function goTopEx() {
	$node = $('#goTopBtn');
	if (getScrollTop() > 0) {
		$node.show();
	} else {
		$node.hide();
	}

	$(window).scroll(function() {
		if (getScrollTop() > 0) {
			$node.show();
		} else {
			$node.hide();
		}
	});

	$node.click(function() {
		setScrollTop();
	});
}

function drawRatio() {
	$('.suite_item').each(function(i, node) {
		drawSuiteRatio(node)
	});
}

$(".see_all").click(function(){
	$("#see_all").show();
    $("#see_fail").hide();
    $("#see_block").hide();
    $("#see_na").hide();
    updateToggles();
    return false;
});

$(".see_failed").click(function(){
	$("#see_all").hide();
    $("#see_fail").show();
    $("#see_block").hide();
    $("#see_na").hide();
    updateToggles();
    return false;
});

$(".see_blocked").click(function(){
	$("#see_all").hide();
    $("#see_fail").hide();
    $("#see_block").show();
    $("#see_na").hide();
    updateToggles();
    return false;
});

$(".see_na").click(function(){
	$("#see_all").hide();
    $("#see_fail").hide();
    $("#see_block").hide();
    $("#see_na").show();
    updateToggles();
    return false;
});

$("a.test_case_popup").click(function(){
	var $this = $(this);
	Popup.show($this.attr('id'));
    return false;
});

$(".see_capabilities").click(function(){
	if ($('#capability_table').css('display') == 'none') {
		$("#capability_table").show();
	}else{
		$("#capability_table").hide();
	}
    return false;
});

function drawSuiteRatio(node) {
	arrTitle = new Array("Passed", "Failed", "Blocked", "Not Executed");
	var $node = $(node);
	var $total = $node.find('.total');
	var $pass = $node.find('.pass');
	var $fail = $node.find('.fail');
	var $block = $node.find('.block');
	var $na = $node.find('.na');
	var $div = $node.find('.RatioGraphic');

	var total_int = parseInt($total.text());
	var pass_int = parseInt($pass.text());
	var fail_int = parseInt($fail.text());
	var block_int = parseInt($block.text());
	var na_int = parseInt($na.text());

	var pass_rate = pass_int * 100 / total_int;
	var fail_rate = fail_int * 100 / total_int;
	var block_rate = block_int * 100 / total_int;
	var na_rate = na_int * 100 / total_int;

	var areaWidth = 380;

	var pass_width = areaWidth * pass_rate / 100;
	var fail_width = areaWidth * fail_rate / 100;
	var block_width = areaWidth * block_rate / 100;
	var na_width = areaWidth * na_rate / 100;
	
	pass_rate = pass_rate.toFixed(2);
	fail_rate = fail_rate.toFixed(2);
	block_rate = block_rate.toFixed(2);
	na_rate = na_rate.toFixed(2);

	var pass_style = "padding:3px 0px 0px 0px;font-size:9pt;height:17px;text-align:center;color:white;font-weight:bold;background:url(&quot;./style/blue.jpg&quot;);"
	var fail_style = "padding:3px 0px 0px 0px;font-size:9pt;height:17px;text-align:center;color:white;font-weight:bold;background:url(&quot;./style/red.jpg&quot;);"
	var block_style = "padding:3px 0px 0px 0px;font-size:9pt;height:17px;text-align:center;color:white;font-weight:bold;background:url(&quot;./style/orange.jpg&quot;);"
	var na_style = "padding:3px 0px 0px 0px;font-size:9pt;height:17px;text-align:center;color:white;font-weight:bold;background:url(&quot;./style/gray.jpg&quot;);"

	var html = "<table width=\"380.68\" align=\"center\"><tbody><tr>";
	if (pass_width > 0){
	    html += "<td width=\""
			+ pass_width
			+ "\" style=\""
			+ pass_style
			+ "\" title=\"Passed :"
			+ pass_rate
			+ "%\">";
	    if (pass_width > 20){
	    	html += pass_rate + "%"
	    }
	    html +=  "</td>";
	}
	if (fail_width > 0){
		html += "<td width=\""
			+ fail_width
			+ "\" style=\""
			+ fail_style
			+ "\" title=\"Failed :"
			+ fail_rate
			+ "%\">";
	    if (fail_width > 20){
	    	html += fail_rate + "%"
	    }
	    html +=  "</td>";
	}
	if (block_width > 0){
		html += "<td width=\""
			+ block_width
			+ "\" style=\""
			+ block_style
			+ "\" title=\"Blocked :"
			+ block_rate
			+ "%\">";
	    if (block_width > 20){
	    	html += block_rate + "%"
	    }
	    html +=  "</td>";
	}
	if (na_width > 0){
		html += "<td width=\""
			+ na_width
			+ "\" style=\""
			+ na_style
			+ "\" title=\"Blocked :"
			+ na_rate
			+ "%\">";
	    if (na_width > 20){
	    	html += na_rate + "%"
	    }
	    html +=  "</td>";
	}
	html += "</tr></tbody></table>";
	$div.html(html);
}
