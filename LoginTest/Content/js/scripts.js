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

$(function () {
    $(".forLM").slice(0, 4).css('display', 'inline-block');
    if ($(".forLM:hidden").length == 0) {
        $("#loadMore").css('display', 'none');
    }
    $("#loadMore").on('click', function (e) {
        e.preventDefault();
        $(".forLM:hidden").slice(0, 4).css('display', 'inline-block');
        if ($(".forLM:hidden").length == 0) {
            $("#loadMore").fadeOut('slow');
        }
        $('html,body').animate({
            scrollTop: $(this).offset().top
        }, 1500);
    });
});


$('a[href=#top]').click(function () {
    $('body,html').animate({
        scrollTop: 0
    }, 600);
    return false;
});

$(window).scroll(function () {
    if ($(this).scrollTop() > 50) {
        $('.totop a').fadeIn();
    } else {
        $('.totop a').fadeOut();
    }
});

                     
     
  