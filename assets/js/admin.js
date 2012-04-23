


/************* student_index *****************/
$(function() {

    /*$('#stu_add_form').validate({
    submitHandler: function(form) {	// 验证成功后会执行该方法
    $(form).ajaxSubmit({
    success: function(result) {
    $("#sno_input").val("");
    $("#sname_input").val("");
    alert("新增用户成功");
    }
    });
    }
    });*/
    $('#stu_add_form').validate({
        submitHandler: function(form) {	// 验证成功后会执行该方法
            $(form).ajaxSubmit(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "student_index.aspx/student_insert",
                    data: "{sno:'" + $("#sno_input").val() + "',sname:'" + $("#sname_input").val() + "'}",
                    dataType: "json",
                    success: function(result) {
                        $("#sno_input").val("");
                        $("#sname_input").val("");
                        alert("新增用户成功");
                    }
                });
            });
        }
    });
    
    $("#stu_add_tab").click(function() {
        $("#SelectName").val("学号");
        $("#InputValue").val("");
    });

    //$("table").tablesorter();

    var options = function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "student_index.aspx/student_select",
            data: "{selectName:'" + $("#SelectName").val() + "',selectValue:'" + $("#InputValue").val() + "'}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                var str = "";
                $(data).each(function(i) {
                    str = str + "<tr><td>" + data[i].sno + "</td>";
                    str = str + "<td>" + data[i].sname + "</td>";
                    str = str + "<td>" + data[i].sex + "</td>";
                    str = str + "<td>" + data[i].institute + "</td>";
                    str = str + "<td>" + data[i].major + "</td>";
                    str = str + "<td>" + data[i].sclass + "</td>";
                    str = str + "<td class='options'><ul class='inline'>";
                    str = str + "<li><a href='student_edit.aspx?sno=" + data[i].sno + "&operat=show'>查看</a></li>";
                    str = str + "<li><a href='student_edit.aspx?sno=" + data[i].sno + "&operat=edit'>编辑</a></li>";
                    str = str + "<li><a href='student_edit.aspx?sno=" + data[i].sno + "&operat=del'>删除</a></li>";
                    str = str + "</ul></td></tr>";
                });
                $("#stu_info_tbody").html(str);
                //$("table").trigger("update");
                //var sorting = [[0, 0]];
                //$("table").trigger("sorton", [sorting]);
            }
        });
    };
    $("#stu_info_table").ajaxSubmit(options);
    $("#stu_info_tab").click(options);
    $('#stu_select_form').submit(function() {
        $(this).ajaxSubmit(options);
        return false;
    });

})

/************* student_edit *****************/
$(function() {
    var options = function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "student_edit.aspx/student_info",
            data: "{}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                $("#stu_sno_td").text(data.sno);
                $("#stu_sname_td").text(data.sname);
                $("#stu_sex_td").text(data.sex);
                $("#stu_institute_td").text(data.institute);
                $("#stu_major_td").text(data.major);
                $("#stu_sclass_td").text(data.sclass);
                $("#stu_tel_td").text(data.tel);
                $("#stu_email_td").text(data.email);
                $("#stu_eng_td").text(data.englishLevel);
                $("#stu_honour_td").text(data.honour);
                $("#stu_intro_td").text(data.intro);
                $("#stu_remark_td").text(data.remark);

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
    };
    $("#stu_info_show").ajaxSubmit(options);
    $("#stu_edit_tab").click(options);
    $("#stu_show_tab").click(options);

    $('#stu_edit_form').validate({
        submitHandler: function(form) {	// 验证成功后会执行该方法
            $(form).ajaxSubmit(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "student_edit.aspx/student_edit",
                    data: "{sname:'" + $("#stu_sname_input").val() + "',sex:'" + $("#stu_sex_select").val()
                     + "',institute:'" + $("#stu_institute_input").val() + "',major:'" + $("#stu_major_input").val() + "',sclass:'" + $("#stu_sclass_input").val()
                      + "',tel:'" + $("#stu_tel_input").val() + "',email:'" + $("#stu_email_input").val() + "',eng:'" + $("#stu_eng_input").val()
                       + "',honour:'" + $("#stu_honour_textarea").val() + "',intro:'" + $("#stu_intro_textarea").val() + "',remark:'" + $("#stu_remark_textarea").val() + "'}",
                    dataType: "json",
                    success: function(result) {
                        alert(result.d);
                    }
                });
            });
        }
    });

    $('#stu_del_btn').click(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "student_edit.aspx/student_del",
            data: "{}",
            dataType: "json",
            success: function(result) {
                alert(result.d);
            }
        });
    });
    
});