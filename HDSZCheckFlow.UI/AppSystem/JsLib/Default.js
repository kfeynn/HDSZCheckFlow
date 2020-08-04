

//改变窗口大小时也要设置高度(不然要手动刷新才能更新页面高度)
/*
window.onresize = function() {
    $("#centerDiv").height(document.body.clientHeight - 168); //设置高度
}


window.onbeforeunload = function() {
    var n = window.event.screenX - window.screenLeft;
    var b = n > document.documentElement.scrollWidth - 20;
    //关闭浏览器
    if (b && window.event.clientY < 0 || window.event.altKey) {
        document.getElementById("btnOut").click();
    }
}
*/


function tupian(idt) {

//alert(idt);
    var nametu = "xiaotu" + idt;
    var tp = document.getElementById(nametu);
    tp.src = "../images/ui/ico05.gif"; //图片ico05为蓝色的正方形        document.getElementById(nametu).src = "../images/ui/ico05.gif";        
     //alert(tp.src);

    for (var i = 1; i < 340; i++) {
        var nametu2 = "xiaotu" + i;
        if (i != idt * 1) {
            var tp2 = document.getElementById(nametu2);
            if (tp2 != undefined) {
                tp2.src = "../images/ui/ico06.gif"; //图片ico06为灰色的正方形
            }
        }
    }
}

function list(idstr) {



    var name1 = "subtree" + idstr;
    var name2 = "img" + idstr;
    var objectobj = document.getElementById(name1);   //document.all(name1); // firefox不认 document.all 
    var imgobj = document.getElementById(name2);   //document.all(name2);
    
    //alert(name1);


    if (objectobj.style.display == "none") {
        for (i = 1; i < 10; i++) {
            var name3 = "img" + i;
            var name = "subtree" + i;
            var o = document.getElementById(name); //document.all(name);
            if (o != undefined) {
                o.style.display = "none";
                var image = document.getElementById(name3); //document.all(name3);
                //alert(image);
                image.src = "../images/ui/ico04.gif";
            }
        }
        objectobj.style.display = "";
        imgobj.src = "../images/ui/ico03.gif";
    }
    else {
        objectobj.style.display = "none";
        imgobj.src = "../images/ui/ico04.gif";
    }
}
