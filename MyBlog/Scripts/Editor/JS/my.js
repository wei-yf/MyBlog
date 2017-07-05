
function del(id,yeshu) {
    //$.get('blog/del', { "id": id }, function () { });
    $('#ajax-test').load('blog/del', { "id": id,"yeshu":yeshu }, function ()
    { });
}
function edit(id) {
    
}
function page(yeshu) {
    $('#ajax-test').load('blog/page', { "yeshu": yeshu },function() { } );
}

function pageSelect() {
    var sel = document.getElementById("pid");
    page(sel.selectedIndex + 1);
}