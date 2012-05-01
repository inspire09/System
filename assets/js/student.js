$(function() {


    /**************  SInfo.aspx  **************/

    $("#stu_edit_form").ajaxSubmit(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "SInfo.aspx/student_info",
            data: "{}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                $("#stu_sno_input").val(data.sno);
                $("#stu_sname_input").val(data.sname);
                $("#stu_sex_select").val(data.sex);
                $("#stu_institute_input").val(data.institute);
                $("#stu_major_input").val(data.major);
                $("#stu_sclass_input").val(data.sclass);
                $("#stu_tel_input").val(data.tel);
                $("#stu_email_input").val(data.email);
                $("#stu_eng_input").val(data.englishLevel);
                $("#stu_honour_textarea").val(data.honour);
                $("#stu_intro_textarea").val(data.intro);
                $("#stu_remark_textarea").val(data.remark);
            }
        });
    });

    $('#stu_edit_form').validate({
        submitHandler: function(form) {	// 验证成功后会执行该方法
            $(form).ajaxSubmit(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "SInfo.aspx/student_edit",
                    data: "{sname:'" + $("#stu_sname_input").val() + "',sex:'" + $("#stu_sex_select").val()
                     + "',institute:'" + $("#stu_institute_input").val() + "',major:'" + $("#stu_major_input").val() + "',sclass:'" + $("#stu_sclass_input").val()
                      + "',tel:'" + $("#stu_tel_input").val() + "',email:'" + $("#stu_email_input").val() + "',eng:'" + $("#stu_eng_input").val()
                       + "',honour:'" + $("#stu_honour_textarea").val() + "',intro:'" + $("#stu_intro_textarea").val() + "',remark:'" + $("#stu_remark_textarea").val() + "'}",
                    dataType: "json",
                    success: function(result) {
                        alert(result.d);
                        //window.location.href = "student_index.aspx";
                    }
                });
            });
        }
    });

    /**************  volunteer.aspx  **************/

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
                    var num = parseInt(choice) + parseInt(1);
                    var rs = confirm('将覆盖第 ' + num + ' 志愿的导师 ' + data.tname.trim() + ' ，确定吗？');
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
        //$.post(url, params, function(){});
    });


    /**************  my_vol.aspx  **************/

    $("#myvol_table").ajaxSubmit(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "my_vol.aspx/myvol",
            data: "{}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                var str = "";
                $(data).each(function(i) {
                    var content = "性别:" + data[i].sex + "<br/>教研室:" + data[i].room + "<br/>电子邮箱:" + data[i].email;
                    content = content + "<br/>联系电话:" + data[i].tel + "<br/>职称:" + data[i].title;
                    content = content + "<br/>学历:" + data[i].education + "<br/>主教课程:" + data[i].course;
                    content = content + "<br/>研究方向:" + data[i].research + "<br/>论文情况:" + data[i].article;
                    content = content + "<br/>对学生要求:" + data[i].demand + "<br/>所在学院:" + data[i].institute;
                    var str = "<a href='#' rel='popover' title='详细资料' data-content='" + content + "'>";
                    str = str + data[i].tname + "</a>";
                    $("#tname_" + data[i].priority + "_td").html(str);
                    $("#status_" + data[i].priority + "_td").html(data[i].status);
                    $("#operat_" + data[i].priority + "_td").html("<button name='" + data[i].priority + "' class='btn'>取消</button>");
                });
                // 初始化：详细资料 浮出框
                $('a[rel="popover"]').popover();
            }
        });
    })

    //‘取消’按钮，取消已选导师
    $("#myvol_table button[class='btn']").live('click', function() {
        var self = $(this);
        var num = self.attr("name");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "my_vol.aspx/vol_delete",
            data: "{priority:'" + num + "'}",
            dataType: "json",
            success: function(result) {
                self.closest("tr").find("#tname_" + num + "_td").html("");
                self.closest("tr").find("#status_" + num + "_td").html("");
                self.closest("tr").find("#operat_" + num + "_td").html("<a href='volunteer.aspx'>选择志愿</a>");
            }
        })
    })

    

})