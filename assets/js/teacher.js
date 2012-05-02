


$(function() {

    /**************  TInfo.aspx  **************/

    $("#tea_edit_form").ajaxSubmit(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "TInfo.aspx/teacher_info",
            data: "{}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                $("#tea_tno_input").val(data.tno);
                $("#tea_tname_input").val(data.tname);
                $("#tea_sex_select").val(data.sex);
                $("#tea_room_input").val(data.room);
                $("#tea_tel_input").val(data.tel);
                $("#tea_email_input").val(data.email);
                $("#tea_title_input").val(data.title);
                $("#tea_education_input").val(data.education);
                $("#tea_course_textarea").val(data.course);
                $("#tea_research_textarea").val(data.research);
                $("#tea_article_textarea").val(data.article);
                $("#tea_demand_textarea").val(data.demand);
                $("#tea_institute_input").val(data.institute);
            }
        });
    });

    $('#tea_edit_form').validate({
        submitHandler: function(form) {	// 验证成功后会执行该方法
            $(form).ajaxSubmit(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "TInfo.aspx/teacher_edit",
                    data: "{tname:'" + $("#tea_tname_input").val() + "',sex:'" + $("#tea_sex_select").val()
                     + "',room:'" + $("#tea_room_input").val() + "',tel:'" + $("#tea_tel_input").val()
                     + "',email:'" + $("#tea_email_input").val() + "',title:'" + $("#tea_title_input").val()
                      + "',education:'" + $("#tea_education_input").val() + "',course:'" + $("#tea_course_textarea").val()
                       + "',research:'" + $("#tea_research_textarea").val() + "',article:'" + $("#tea_article_textarea").val()
                       + "',demand:'" + $("#tea_demand_textarea").val() + "',institute:'" + $("#tea_institute_input").val() + "'}",
                    dataType: "json",
                    success: function(result) {
                        alert(result.d);
                        //window.location.href = "teacher_index.aspx";
                    }
                });
            });
        }
    });
    /**************  Tutor.aspx  **************/

    //已选学生数，可选学生数
    $("#stu_count").ajaxSubmit(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "Tutor.aspx/student_count",
            data: "{}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                $('#total').text(data.total);
                $('#count').text(data.count);
            }
        })
    });

    //$("table").tablesorter();

    //PageLoad  table
    var options = function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "Tutor.aspx/student_select",
            data: "{selectName:'" + $("#SelectName").val() + "',selectValue:'" + $("#InputValue").val() + "'}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                var str = "";
                $(data).each(function(i) {
                    var content = "班级:" + data[i].sclass + "<br/>联系电话:" + data[i].tel + "<br/>电子邮箱:" + data[i].email;
                    content = content + "<br/>英语等级:" + data[i].eng + "<br/>荣誉:" + data[i].honour;
                    content = content + "<br/>自我评价:" + data[i].intro + "<br/>备注:" + data[i].remark;
                    str = str + "<tr><td id='sno'>" + data[i].sno + "</td>";
                    str = str + "<td>" + data[i].sname + "</td>";
                    str = str + "<td>" + data[i].sex + "</td>";
                    str = str + "<td>" + data[i].institute + "</td>";
                    str = str + "<td>" + data[i].major + "</td>";
                    str = str + "<td><a href='#' rel='popover' title='详细资料' data-content='" + content + "'>详细资料</a></td>";
                    str = str + "<td class='options'><button class='btn btn-primary" + data[i].disabled + "'>选定</button>";
                    str = str + "<button class='btn'>取消</button>";
                    str = str + "</td></tr>";
                });
                $("#stu_info_tbody").html(str);
                // 初始化：详细资料 浮出框
                $('a[rel="popover"]').popover();
                //$("table").trigger("update");
                //var sorting = [[0, 0]];
                //$("table").trigger("sorton", [sorting]);
            }
        });
    };
    $("#stu_info_table").ajaxSubmit(options);
    $('#stu_select_form').submit(function() {
        $(this).ajaxSubmit(options);
        return false;
    });

    //‘选定’按钮，选学生
    $("#stu_info_table button[class='btn btn-primary']").live('click', function() {
        var self = $(this);
        var $sno = self.closest("tr").find("td[id='sno']");
        if (parseInt($('#count').text()) === parseInt($('#total').text())) {
            alert("人数已满！");
            return false;
        }
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "Tutor.aspx/tutor_insert",
            data: "{sno:'" + $sno.text() + "'}",
            dataType: "json",
            success: function(result) {
                self.attr('class', 'btn btn-primary disabled');
                var count = parseInt($('#count').text()) + parseInt(1);
                $('#count').text(count);
            }
        })
    })

    //‘删除/取消’按钮，取消已选学生
    $("#stu_info_table button[class='btn']").live('click', function() {
        var self = $(this);
        var $sno = self.closest("tr").find("td[id='sno']");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "Tutor.aspx/tutor_delete",
            data: "{sno:'" + $sno.text() + "'}",
            dataType: "json",
            success: function(result) {
                var count = parseInt($('#count').text()) - parseInt(1);
                $('#count').text(count);
                var $disabled = self.closest("tr").find(".btn-primary");
                $disabled.attr('class', 'btn btn-primary');
            }
        })
    })

})

/**************  MyTutor.aspx  **************/

$(function() {
    $("#mytutor_table").ajaxSubmit(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "MyTutor.aspx/mytutor",
            data: "{}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                var str = "";
                $(data).each(function(i) {
                    var content = "班级:" + data[i].sclass + "<br/>联系电话:" + data[i].tel + "<br/>电子邮箱:" + data[i].email;
                    content = content + "<br/>英语等级:" + data[i].eng + "<br/>荣誉:" + data[i].honour;
                    content = content + "<br/>自我评价:" + data[i].intro + "<br/>备注:" + data[i].remark;
                    str = str + "<tr><td id='sno'>" + data[i].sno + "</td>";
                    str = str + "<td>" + data[i].sname + "</td>";
                    str = str + "<td>" + data[i].sex + "</td>";
                    str = str + "<td>" + data[i].institute + "</td>";
                    str = str + "<td>" + data[i].major + "</td>";
                    str = str + "<td><a href='#' rel='popover' title='详细资料' data-content='" + content + "'>详细资料</a></td>";
                    str = str + "<td class='options'><button class='btn'>删除</button>";
                    str = str + "<a href='write.aspx?receiverID=" + data[i].sno + "' class='btn btn-success'>私信</a></td></tr>";
                });
                $("#mytutor_tbody").html(str);
                // 初始化：详细资料 浮出框
                $('a[rel="popover"]').popover();
            }
        });
    })
    //‘删除/取消’按钮，取消已选学生
    $("#mytutor_table button[class='btn']").live('click', function() {
        var self = $(this);
        var $sno = self.closest("tr").find("td[id='sno']");
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "Tutor.aspx/tutor_delete",
            data: "{sno:'" + $sno.text() + "'}",
            dataType: "json",
            success: function(result) {
                var count = parseInt($('#count').text()) - parseInt(1);
                $('#count').text(count);
                self.closest("tr").remove();
            }
        })
    })



    /**************  SAvatar.aspx  **************/

    /*  照片裁剪 */
    // 照片大小
    var avatar_width = 225,
        avatar_height = 300;
    // Create variables (in this scope) to hold the API and image size
    var jcrop_api, boundx, boundy;

    var updateJcropAPI = function(api) {
        // Use the API to get the real image size
        api = api || this;
        var bounds = api.getBounds();
        boundx = bounds[0];
        boundy = bounds[1];
        // Store the API in the jcrop_api variable
        jcrop_api = api;
        console.log("updateJcropAPI. boundx: " + boundx + ", boundy: " + boundy);
    };
    // 裁剪后的效果图预览
    var updatePreview = function(c) {
        if (parseInt(c.w) > 0) {
            console.log("updatePreview callback. boundx: " + boundx + ", boundy: " + boundy);
            var rx = avatar_width / c.w;
            var ry = avatar_height / c.h;

            $('.avatar_preview img').css({
                width: Math.round(rx * boundx) + 'px',
                height: Math.round(ry * boundy) + 'px',
                marginLeft: '-' + Math.round(rx * c.x) + 'px',
                marginTop: '-' + Math.round(ry * c.y) + 'px'
            });
        }
    };

    var $crop_container = $('#my_avatar');

    // 渲染被裁剪的(上传)图片
    var regCropAvatar = function() {
        $('#my_avatar img').Jcrop({
            minSize: [10, 10], 	// 裁剪的最小宽度、高度
            maxSize: [avatar_width, avatar_height], // 裁剪的最大宽度、高度
            setSelect: [150, 50, avatar_width, avatar_height], // 设置 默认选中区域的左上角、右下角坐标
            bgColor: 'white',
            bgOpacity: .3,
            onSelect: updatePreview,
            onChange: updatePreview,
            onRelease: function() { },
            aspectRatio: 0.75	// 等比缩放
        }, updateJcropAPI);
    };

    var changeImage = function(img) {
        jcrop_api.setImage(img.src, function() { // change image callback
            $('.avatar_preview').children().replaceWith($.clone(img));
            updateJcropAPI(this);
            this.animateTo([0, 0, avatar_width, avatar_height]);
        });
    }

    /* 照片上传前预览 */
    var $input_file = $('form#upload_image_form input:file');
    $input_file.bind('change', function(e) {
        e = e.originalEvent;
        e.preventDefault();
        window.loadImage(
			(e.dataTransfer || e.target).files[0], changeImage,
			{
			    maxWidth: $crop_container.width(),
			    maxHeight: $crop_container.height()
			}
		);
    });

    // 默认照片/原照片 裁剪渲染
    regCropAvatar();

    // 保存头像按钮事件
    $('#upload_image_form').submit(function() {

        if (!$.trim($('#image_file', $(this)).val())) {
            showMsg("error", "请选择一张本地照片");
            return false;
        }

        var img = $('#my_avatar img')[0];
        var scale = Math.min(
            $crop_container.width() / img.naturalWidth,
            $crop_container.height() / img.naturalHeight
        );
        if (scale > 1) scale = 1;   // 若大于1表示原始图片没有缩小

        var c = jcrop_api.tellSelect();
        var rx = avatar_width / c.w;
        var ry = avatar_height / c.h;
        var rscalex = parseFloat((scale * rx).toFixed(6));   // 小数点保留6位有效数
        var rscaley = parseFloat((scale * ry).toFixed(6));

        /*$(this).ajaxSubmit({
            //scalex: rscalex,            // 原始图片缩放的实际倍数,因为是等比缩放，所以x,y的缩放倍数是一样的
            //scaley: rscaley,
            //x: Math.round(rx * c.x),    // 选中区域的左上角X坐标, 请以该数据为依据
            //y: Math.round(ry * c.y)     // 选中区域的左上角Y坐标, 请以该数据为依据
            //},
            success: function(response) { // callback
                alert('success');
            }
        });*/
        $(this).ajaxSubmit(function() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "SAvatar.aspx/upload_avatar",
                data: "{origin_width:'" + img.naturalWidth + "',origin_height:'" + img.naturalHeight
                    + "',to_width:'" + avatar_width + "',to_height:'" + avatar_height
                    + "',scalex:'" + rscalex + "',scaley:'" + rscaley
                    + "',x:'" + Math.round(rx * c.x) + "',y:'" + Math.round(ry * c.y) + "'}",
                dataType: "json",
                success: function(result) {
                    alert('success');
                }
            });
        });
        

        return false;
    });

    /**************  write.aspx  **************/
    
    $('#tea_write_form').validate({
        submitHandler: function(form) {	// 验证成功后会执行该方法
            $(form).ajaxSubmit(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "write.aspx/write",
                    data: "{receiver:'" + $("#tea_receiver_input").val() + "',topic:'" + $("#tea_topic_input").val()
                        + "',content:'" + $("#tea_content_textarea").val() + "'}",
                    dataType: "json",
                    success: function(result) {
                        alert(result.d);
                        window.location.href = "TDefault.aspx";
                    }
                });
            });
        }
    });

})