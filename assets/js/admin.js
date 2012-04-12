$(function() {

    $("#list table").tablesorter({
        sortList: [[0, 0]],
        headers: {
            6: { sorter: false }
        }
    });
    showMsg("测试show message");
})