


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
                        window.location.href = "student_index.aspx";
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
                window.location.href = "student_index.aspx";
            }
        });
    });

});

/************* teacher_index *****************/
$(function() {

    $('#tea_add_form').validate({
        submitHandler: function(form) {	// 验证成功后会执行该方法
            $(form).ajaxSubmit(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "teacher_index.aspx/teacher_insert",
                    data: "{tno:'" + $("#tno_input").val() + "',tname:'" + $("#tname_input").val() + "'}",
                    dataType: "json",
                    success: function(result) {
                        $("#tno_input").val("");
                        $("#tname_input").val("");
                        alert("新增用户成功");
                    }
                });
            });
        }
    });

    $("#tea_add_tab").click(function() {
        $("#SelectName").val("员工号");
        $("#InputValue").val("");
    });

    //$("table").tablesorter();

    var tea_index = function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "teacher_index.aspx/teacher_select",
            data: "{selectName:'" + $("#SelectName").val() + "',selectValue:'" + $("#InputValue").val() + "'}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                var str = "";
                $(data).each(function(i) {
                    str = str + "<tr><td>" + data[i].tno + "</td>";
                    str = str + "<td>" + data[i].tname + "</td>";
                    str = str + "<td>" + data[i].sex + "</td>";
                    str = str + "<td>" + data[i].room + "</td>";
                    str = str + "<td>" + data[i].title + "</td>";
                    str = str + "<td>" + data[i].institute + "</td>";
                    str = str + "<td class='options'><ul class='inline'>";
                    str = str + "<li><a href='teacher_edit.aspx?tno=" + data[i].tno + "&operat=show'>查看</a></li>";
                    str = str + "<li><a href='teacher_edit.aspx?tno=" + data[i].tno + "&operat=edit'>编辑</a></li>";
                    str = str + "<li><a href='teacher_edit.aspx?tno=" + data[i].tno + "&operat=del'>删除</a></li>";
                    str = str + "</ul></td></tr>";
                });
                $("#tea_info_tbody").html(str);
                //$("table").trigger("update");
                //var sorting = [[0, 0]];
                //$("table").trigger("sorton", [sorting]);
            }
        });
    };
    $("#tea_info_table").ajaxSubmit(tea_index);
    $("#tea_info_tab").click(tea_index);
    $('#tea_select_form').submit(function() {
        $(this).ajaxSubmit(tea_index);
        return false;
    });

})


/************* teacher_edit *****************/
$(function() {
    var tea_show = function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "teacher_edit.aspx/teacher_info",
            data: "{}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                $("#tea_tno_td").text(data.tno);
                $("#tea_tname_td").text(data.tname);
                $("#tea_sex_td").text(data.sex);
                $("#tea_room_td").text(data.room);
                $("#tea_tel_td").text(data.tel);
                $("#tea_email_td").text(data.email);
                $("#tea_title_td").text(data.title);
                $("#tea_education_td").text(data.education);
                $("#tea_course_td").text(data.course);
                $("#tea_research_td").text(data.research);
                $("#tea_article_td").text(data.article);
                $("#tea_demand_td").text(data.demand);
                $("#tea_institute_td").text(data.institute);

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
    };
    $("#tea_info_show").ajaxSubmit(tea_show);
    $("#tea_edit_tab").click(tea_show);
    $("#tea_show_tab").click(tea_show);

    $('#tea_edit_form').validate({
        submitHandler: function(form) {	// 验证成功后会执行该方法
            $(form).ajaxSubmit(function() {
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: "teacher_edit.aspx/teacher_edit",
                    data: "{tname:'" + $("#tea_tname_input").val() + "',sex:'" + $("#tea_sex_select").val()
                     + "',room:'" + $("#tea_room_input").val() + "',tel:'" + $("#tea_tel_input").val()
                     + "',email:'" + $("#tea_email_input").val() + "',title:'" + $("#tea_title_input").val() 
                      + "',education:'" + $("#tea_education_input").val() + "',course:'" + $("#tea_course_textarea").val()
                       + "',research:'" + $("#tea_research_textarea").val() + "',article:'" + $("#tea_article_textarea").val()
                       + "',demand:'" + $("#tea_demand_textarea").val() + "',institute:'" + $("#tea_institute_input").val() + "'}",
                    dataType: "json",
                    success: function(result) {
                        alert(result.d);
                        window.location.href = "teacher_index.aspx";
                    }
                });
            });
        }
    });

    $('#tea_del_btn').click(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "teacher_edit.aspx/teacher_del",
            data: "{}",
            dataType: "json",
            success: function(result) {
                alert(result.d);
                window.location.href = "teacher_index.aspx";
            }
        });
    });

});