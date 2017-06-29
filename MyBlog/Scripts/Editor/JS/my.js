
function del(id) {
    //$.get('blog/del', { "id": id }, function () { });
    $('#ajax-test').load('blog/del', { "id": id }, function ()
    { });
}
function edit(id) {
    
}