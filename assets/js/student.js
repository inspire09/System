$(function() {

    // 初始化: 瀑布流布局
    var $container = $('.thumbnails');
    $container.imagesLoaded(function() {
        $container.masonry({
            itemSelector: 'li.span3'
        });
    });

    // 当点击学院tab的时候，触发该事件，
    // reload瀑布流布局，防止因取不到image的width, height, 造成页面混乱
    $('#college_select a[data-toggle="tab"]').on('shown', function(e) {
        $($(this).attr("href")).find('.thumbnails').masonry('reload');
    });

    // 初始化：详细资料 浮出框a[data-toggle="tab"]
    $('a[rel="popover"]').popover();

    $('#college_select a[data-toggle="tab"]').click(function() {
        $("#ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_DropDownListCollege").val($(this).text());
        setTimeout('__doPostBack(\'ctl00$ctl00$ContentPlaceHolder2$ContentPlaceHolder1$DropDownListCollege\',\'\')', 0)
    });

    // 事件绑定：选定按钮
    $('.thumbnail .confirm .btn-group li').live('click', function() {
        var self = $(this);
        var choice = self.find('a').data('choice');
        var val = self.closest('.dropdown-menu').find('input').val();

        /* 这里先要判断是否会覆盖已选的志愿,若会，则给予提示 */
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "volunteer.aspx/volunteer_select",
            data: "{priority:'" + choice + "'}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                if (data.msg === "yes") {
                    var rs = confirm('将覆盖第 ' + choice + ' 志愿的导师 ' + data.tname.trim() + ' ，确定吗？');
                    if (rs) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "volunteer.aspx/volunteer_update",
                            data: "{tno:'" + val + "',priority:'" + choice + "'}",
                            dataType: "json",
                            success: function(update) {
                                alert(update.d);
                            }
                        });
                    }
                    // 取消按钮，中断该操作
                    if (!rs) return false;
                }
                else {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "volunteer.aspx/volunteer_insert",
                        data: "{tno:'" + val + "',priority:'" + choice + "'}",
                        dataType: "json",
                        success: function(update) {
                            alert(update.d);
                        }
                    });
                }
            }
        });
        // TODO 发送请求
        //$.post(url, params, function(){});
    });

})