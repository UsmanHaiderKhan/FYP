console.log("usman");





/*================== Read More Text ==================*/
$(function () {
    var showChar = 150;
    var moretext = " See More";
    var lesstext = "See Less";
    $('.comments-space').each(function () {
        var content = $(this).html();
        if (content.length > showChar) {
            var show_content = content.substr(0, showChar);
            var hide_content = content.substr(showChar, content.length - showChar);
            var html = show_content + '<span class="remaining-contents"><span>' + hide_content +
                '</span><a href="" class="morelinks" >' + moretext + '</a>'
                + '</span>';
            $(this).html(html);
        }
    });

    $(".morelinks").click(function () {

        if ($(this).hasClass("less")) {
            $(this).removeClass("less");
            $(this).html(moretext);
        } else {
            $(this).addClass("less");
            $(this).html(lesstext);
        }
        $(this).parent().prev().toggle();
        $(this).prev().toggle();
        return false;
    });
});

/*===================== Load More Images ======================*/
$(function () {
    $('a').smoothScroll();
});
/*======================= Nav Active Class =======================*/

$(function () {
    $('.nav-link').on('click',
        function () {
            $('.nav-link').removeClass('nav-active');
            $(this).addClass('nav-active');
        });
});
/*======================= Counter Script Function =======================*/


$(document).ready(function () {


});
/*======================= Load Section Function =======================*/


$(function () {
    $(".mi").on('click',
        function () {
            $('.mi').removeClass("nav-tabs-color");
            $(this).addClass("nav-tabs-color");

        });

});
/* ==================== Js Function for the Date Picker ================== */
$(function () {
    $("#datepicker").datepicker();
});
/* ==================== Js Function to give the class on Scroll ================== */
$(function () {
    $(window).scroll(function () {
        var scroll = $(window).scrollTop();
        var w_width = $(window).width();
        if (w_width <= 480) {
            if (scroll >= 350) {
                $("nav").addClass("fixed-top");
            } else {
                $("nav").removeClass("fixed-top");
            }
        }
        else if (scroll >= 100) {
            $("nav").addClass("fixed-top");
        } else {
            $("nav").removeClass("fixed-top");
        }
    });
});

/* ==================== Js Function Provide Active Class on Nav Link================== */
$(document).ready(function () {
    $(".nav-link").click(function () {
        $(this).addClass("active-me");
        $(".nav-link").not(this).removeClass("active-me");
    });


});



/* ==================== Js Function For the Owl Carousel Slider ================== */
$(function () {
    $('.owl-carousel').owlCarousel({
        loop: true,
        //autoplay: true,
        margin: 20,
        dots: false,
        responsiveClass: true,
        item: 1,
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 1,
                nav: true
            },
            1000: {
                items: 1,
                nav: true,
                loop: true
            }
        }
    });
});
/*===================== Load More Images ======================*/
$(document).ready(function () {

    $('.loadMore').loadMoreResults({
        displayedItems: 6,
        showItems: 2

    });

});
