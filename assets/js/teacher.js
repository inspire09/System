
/**************  Tutor.aspx  **************/

$(function() {
    
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
                    str = str + "</td></tr>";
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

})