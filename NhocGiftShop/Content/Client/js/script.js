function scrollFunction() {
    var mybutton = document.getElementById("btTop");
    if (document.body.scrollTop > 200 || document.documentElement.scrollTop > 200) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;

}
window.onscroll = function () { scrollFunction() };
function displayErrorEmail(valueName, errorName) {
    var value = document.getElementById(valueName).value;
    var error = document.getElementById(errorName);
    if (value == "") {
        error.style.display = "block";
    } else {
        error.style.display = "none";
    }
}
function errorRepass() {
    var repass = document.getElementById("valueRepass").value;
    var pass = document.getElementById("valuePwd").value;
    var error = document.getElementById("warningRepass");
    if (repass != pass) {
        error.style.display = "block";
    } else {
        error.style.display = "none";
    }
}

$(document).ready(function () {
    $('#size span').click(function (event) {
            $('#size span').removeClass('active');
            $target = $(event.target);
            $target.addClass('active');
    });
    $('#color a').on('click', function (event) {
        event.preventDefault();
        $('#color a').removeClass('active');
        $(this).addClass('active');
        var colorPro = $('#color a.active').attr("data-color");
        var idP = $('#color a.active').attr("data-idPro");
        $.post("/Client/SelectSizeByColor/", { color: colorPro, idPro: idP }).done(function (data) {
            var dt = jQuery.parseJSON(data);
            $("#size>p").html("");
            dt.forEach(function (i) {
                var newitemSize = document.createElement("a");
                $(newitemSize).attr({
                    //'rel': 'nofollow',
                    'data-idPF': i.idPF,
                    'data-size': i.size,
                    'class': ''
                });
                $(newitemSize).html(i.size);
                if (i.size == "Free size") {
                    $(newitemSize).addClass("active");
                }
                $("#size>p").append($(newitemSize));

                $(newitemSize).click(function (e) {
                    if ($('#color').children('a.active').length != 0) {
                        var sizePro = $(this).attr("data-size");
                        var idpf = $(this).attr("data-idPF");
                        $('#size a').removeClass('active');
                        $(this).addClass('active');                   
                        $.post("/Client/SelectPriceBySize/", { size: sizePro, idPF: idpf }).done(function (data) {
                            var dt = jQuery.parseJSON(data);
                            $('#fPrice').attr('data-price', dt);
                            $('#fPrice').html(dt + " vnđ");
                        });
                    }

                });
            });
        });
    });
    $('#addToCart').hover(function (event) {
        if (($('#color').children('a.active').length == 0 && $('#size').children('a.active').length == 0)) {
            $('#addToCart').css("cursor", "not-allowed");
        }
        else if ($('#size a').hasClass('active') == false) {
            $('#addToCart').css("cursor", "not-allowed");
        }
        else {
            $('#addToCart').css("cursor", "pointer");
            $('#addToCart').attr("data-status", "1")
        }
    });
    $('#addToCart').click(function (event) {
        if ($(this).attr("data-status") == "0") {
            event.preventDefault();
        } else {
            var cart = {
                idPF: parseInt($('#size a.active').attr('data-idPF')),
                price: parseInt($('#fPrice').attr('data-price')),
                quantity: parseInt($('#quantity').val()),
                amount: 0,
                colorName: $('#color a.active').attr('data-colorName'),
                size: $('#size a.active').text(),
                namePro: $('#proViewName span').text()
            };
            $.post("/Client/AddToCart/", { cv: cart }).done(function (data) {
               
                var dt = jQuery.parseJSON(data);
                var ql = 0;
                for (var i = 0; i < dt.length; i++) {
                    ql += dt[i].quantity;
                }
                $('#numberCart').html(ql);
                alert('Đã thêm vào giỏ hàng của bạn');
            });
        }

    });
    $('#size a').click(function (e) {
        if ($('#color').children('a.active').length == 0) {
            e.preventDefault();
        }
    });
    $('#size a').hover(function (e) {
        if ($('#color').children('a.active').length == 0) {
            $('#size a').css("cursor", "not-allowed");
        }
    });
    $('#btnInfo').click(function (e) {
        $('#detailInfo>div').css("display", "none");
        $('#contentInfo').css("display", "block");
        $('#menuInfo>div').css("color", "black");
        $('#btnInfo').css("color", "darkblue");
    });
    $('#btnHistoryOrd').click(function (e) {
        $('#detailInfo>div').css("display", "none");
        $('#contentOrd').css("display", "block");
        $('#menuInfo>div').css("color", "black");
        $('#btnHistoryOrd').css("color", "red");
    });
    $('#btnChangePwd').click(function (e) {
        $('#detailInfo>div').css("display", "none");
        $('#changePwd').css("display", "block");
        $('#menuInfo>div').css("color", "black");
        $('#btnChangePwd').css("color", "brown");
    });
    $('.btnPwd').click(function (e) {
        if ($('#valuePwd').val() != $('#valueRepass').val()) {
            e.preventDefault();
        }
    });
});


function zoomImg() {
    var lsImg = document.getElementsByClassName("imgItem");
    for (i = 0; i < lsImg.length; i++) {
        lsImg[i].style.left = (i * lsImg[i].offsetWidth) + 10 + "px";
        lsImg[i].onclick = function (event) {
            var currImg = event.target;
            var srcCrrImg = currImg.src;
            var largeImg = document.getElementById("imgLarge");
            largeImg.src = srcCrrImg;
        }
    }
}

function nextImage(item) {
    item.style.left = parseInt(item.style.left) + item.offsetWidth + 10 + "px";
    var largeImg = document.getElementById("imgLarge");
    largeImg.src = item.src;
}
function nextImages() {
    var lsImg = document.getElementsByClassName("imgItem");
    for (i = 0; i < lsImg.length; i++) {
        nextImage(lsImg[i]);
    }
    createImgFirst();
}
function prevImage(item) {
    item.style.left = parseInt(item.style.left) - item.offsetWidth - 10 + "px";
    var largeImg = document.getElementById("imgLarge");
    largeImg.src = item.src;
}
function prevImages() {
    var lsImg = document.getElementsByClassName("imgItem");
    for (i = 0; i < lsImg.length; i++) {
        prevImage(lsImg[i]);
    }
    createImgLast();
}
function createImgFirst() {
    var containImg = document.getElementById("owl-wrapper");
    if (containImg != null) {
        var lastImg = document.getElementById("owl-wrapper").lastElementChild;
        var newImg = document.createElement("img");
        newImg.className = "imgItem";
        newImg.src = lastImg.src;
        newImg.style.left = parseInt(containImg.firstElementChild.style.left) - containImg.firstElementChild.offsetWidth - 10 + "px";
        lastImg.remove();
        containImg.insertBefore(newImg, containImg.firstElementChild);
    }
    
}
function createImgLast() {
    var containImg = document.getElementById("owl-wrapper");
    if (containImg != null) {
        var fisrtImg = document.getElementById("owl-wrapper").firstElementChild;
        var newImg = document.createElement("img");
        newImg.className = "imgItem";
        newImg.src = fisrtImg.src;
        newImg.style.left = parseInt(containImg.lastElementChild.style.left) + containImg.lastElementChild.offsetWidth + 10 + "px";
        fisrtImg.remove();
        containImg.appendChild(newImg);
    }
    
}

var snowMax = 35;
var snowColor = ["#007fff", "#f7f762"];
var snowEntity = "&#x2665;";
var snowSpeed = 0.75;
var snowMinSize = 8;
var snowMaxSize = 24;
var snowRefresh = 50;
var snow = [], pos = [], coords = [], lefr = [], marginBottom, marginRight;
function randomise(range) {
    rand = Math.floor(range * Math.random());
    return rand;
}
function initSnow() {
    var snowSize = snowMaxSize - snowMinSize;
    marginBottom = document.body.scrollHeight - 5;
    marginRight = document.body.clientWidth - 15;
    for (i = 0; i <= snowMax; i++) {
        coords[i] = 0;
        lefr[i] = Math.random() * 15;
        pos[i] = 0.03 + Math.random() / 10;
        snow[i] = document.getElementById("flake" + i);
        snow[i].style.fontFamily = "inherit";
        snow[i].size = randomise(snowSize) + snowMinSize;
        snow[i].style.fontSize = snow[i].size + "px";
        snow[i].style.color = snowColor[randomise(snowColor.length)];
        snow[i].style.zIndex = 1000;
        snow[i].sink = snowSpeed * snow[i].size / 5;
        snow[i].posX = randomise(marginRight - snow[i].size);
        snow[i].posY = randomise(2 * marginBottom - marginBottom - 2 * snow[i].size);
        snow[i].style.left = snow[i].posX + "px";
        snow[i].style.top = snow[i].posY + "px";
    }
    moveSnow();
}
function resize() {
    marginBottom = document.body.scrollHeight - 5;
    marginRight = document.body.clientWidth - 15;
}
function moveSnow() {
    for (i = 0; i <= snowMax; i++) {
        coords[i] += pos[i];
        snow[i].posY += snow[i].sink;
        snow[i].style.left = snow[i].posX + lefr[i] * Math.sin(coords[i]) + "px";
        snow[i].style.top = snow[i].posY + "px";
        if (snow[i].posY >= marginBottom - 2 * snow[i].size || parseInt(snow[i].style.left) > (marginRight - 3 * lefr[i])) {
            snow[i].posX = randomise(marginRight - snow[i].size);
            snow[i].posY = 0;
        }
    }
    setTimeout("moveSnow()", snowRefresh);
}
for (i = 0; i <= snowMax; i++) {
    document.write("<span id='flake" + i + "' style='position:absolute;top:-" + snowMaxSize + "'>" + snowEntity + "</span>");
}
window.onresize = resize;
window.onload = function () {
    zoomImg();
    initSnow();
    window.setInterval(function () { nextImages() }, 5000);

    var next = document.getElementById("btnNext");
    if (next != null) {
        next.addEventListener("click", function () {
            nextImages();
        });
    }

    var prev = document.getElementById("btnPrev");
    if (prev != null) {
        prev.addEventListener("click", function () {
            prevImages();
        });
    }

};


