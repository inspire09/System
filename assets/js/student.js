/************* student_index *****************/
$(function() {
    $('#form_add').ajaxForm(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "student_index.aspx/student_insert",
            data: "{sno:'" + $("#InputSno").val() + "',sname:'" + $("#InputSname").val() + "'}",
            dataType: "json",
            success: function(result) {
                $("#InputSno").val("");
                $("#InputSname").val("");
                alert("新增用户成功");
            }
        });
    });
});

$(function() {
    $("#li_add").click(function() {
        $("#SelectName").val("学号");
        $("#InputValue").val("");
    });
});

$(function() {
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
                $("#tbody").html(str);
                
            }
        });
    };
    $("#table_info").ajaxSubmit(options);
    $("#li_list").click(options);
    $('#form_select').submit(function() {
        $(this).ajaxSubmit(options);
        return false;
    });
});


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
                $("#sno").text(data.sno);
                $("#sname").text(data.sname);
                $("#sex").text(data.sex);
                $("#institute").text(data.institute);
                $("#major").text(data.major);
                $("#sclass").text(data.sclass);
                $("#tel").text(data.tel);
                $("#email").text(data.email);
                $("#englishLevel").text(data.englishLevel);
                $("#honour").text(data.honour);
                $("#intro").text(data.intro);
                $("#remark").text(data.remark);
            }
        });
    };
    $("#show").ajaxSubmit(options);
    $("#li_show").click(options);
});

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
                $("#InputSno").val(data.sno);
                $("#InputSname").val(data.sname);
                $("#SelectSex").val(data.sex);
                $("#InputInstitute").val(data.institute);
                $("#InputMajor").val(data.major);
                $("#InputSclass").val(data.sclass);
                $("#InputTel").val(data.tel);
                $("#InputEmail").val(data.email);
                $("#InputEng").val(data.englishLevel);
                $("#TextareaHonour").val(data.honour);
                $("#TextareaIntro").val(data.intro);
                $("#TextareaRemark").val(data.remark);
            }
        });
    };
    $("#edit").ajaxSubmit(options);
    $("#li_edit").click(options);
});

$(function() {
    var options = function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "student_edit.aspx/student_edit",
            data: "{sname:'" + $("#InputSname").val() + "',sex:'" + $("#SelectSex").val()
                     + "',institute:'" + $("#InputInstitute").val() + "',major:'" + $("#InputMajor").val() + "',sclass:'" + $("#InputSclass").val()
                      + "',tel:'" + $("#InputTel").val() + "',email:'" + $("#InputEmail").val() + "',eng:'" + $("#InputEng").val()
                       + "',honour:'" + $("#TextareaHonour").val() + "',intro:'" + $("#TextareaIntro").val() + "',remark:'" + $("#TextareaRemark").val() + "'}",
            dataType: "json",
            success: function(result) {
                alert(result.d);
            }
        });
    };
    $('#form_edit').submit(function() {
        $(this).ajaxSubmit(options);
        return false;
    });
});

$(function() {
    $('#BtnDel').click(function() {
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