//(function() {
//    "use strict";

//    // custom scrollbar

//    $("html").niceScroll({styler:"fb",cursorcolor:"#4a9cfd", cursorwidth: '6', cursorborderradius: '10px', background: '#FFFFFF', spacebarenabled:false, cursorborder: '0',  zindex: '1000'});

//    $(".scrollbar1").niceScroll({styler:"fb",cursorcolor:"#4a9cfd", cursorwidth: '6', cursorborderradius: '0',autohidemode: 'false', background: '#FFFFFF', spacebarenabled:false, cursorborder: '0'});

	
	
//    $(".scrollbar1").getNiceScroll();
//    if ($('body').hasClass('scrollbar1-collapsed')) {
//        $(".scrollbar1").getNiceScroll().hide();
//    }

//})(jQuery);

//(function() {
//    "use strict";

//    // custom scrollbar

//    $("html").niceScroll({styler:"fb",cursorcolor:"#e53238", cursorwidth: '6', cursorborderradius: '10px', background: '#FFFFFF', spacebarenabled:false, cursorborder: '0',  zindex: '1000'});

//    $(".scrollbar1").niceScroll({styler:"fb",cursorcolor:"#e53238", cursorwidth: '6', cursorborderradius: '0',autohidemode: 'false', background: '#FFFFFF', spacebarenabled:false, cursorborder: '0'});

	
	
//    $(".scrollbar1").getNiceScroll();
//    if ($('nav.gn-menu-wrapper').hasClass('scrollbar1-collapsed')) {
//        $(".scrollbar1").getNiceScroll().hide();
//    }

//})(jQuery);

$(document).ready(function () {
   
    $('.sidebarBtn, #bodyoverlay').click(function () {
        $('.sidebar').toggleClass('active');
        $('.sidebarBtn').toggleClass('toggle');
        $('body').css("overflow", "hidden");
    });
    $('.sidebarBtn--1, #bodyoverlay').click(function () {
        $('body').css("overflow", "scroll");
    });
});



function on() {
    document.getElementById("bodyoverlay").style.display = "block";
}

function off() {
    document.getElementById("bodyoverlay").style.display = "none";
}

function textAreaAdjust(o) {
    o.style.height = "1px";
    setTimeout(function () {
        o.style.height = (o.scrollHeight) + "px";
    }, 1);
}



                     
     
  