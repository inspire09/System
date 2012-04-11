
$(function() {
    $('#form_Add').ajaxForm(function() {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "student_index.aspx/student_insert",
            data: "{sno:'" + $("#InputSno").val() + "',sname:'" + $("#InputSname").val() + "'}",
            dataType: "json",
            success: function(result) {
                alert("新增用户成功");
            }
        });

    });
});

$(function() {
    $('#show').ajaxSubmit(function() {
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
    });

    $('#edit').ajaxSubmit(function() {
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
    });

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
