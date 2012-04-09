<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/MasterPageManager.master" AutoEventWireup="true" CodeFile="student_edit.aspx.cs" Inherits="Manager_student_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../assets/js/jquery.js" type="text/javascript"></script>
        <script type="text/javascript">
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
            });

            $(function() {
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

               
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <div id="content" class="span10">
        <ul class="breadcrumb">
			<li>
			    <a href="#">Home</a> <span class="divider">/</span>
			</li>
			<li>
				<a href="student_index.aspx">学生信息</a> <span class="divider">/</span>
			</li>
			<li class="active">编辑</li>
		</ul>
        <ul class="nav nav-tabs">
			<li class="<%= showLi %>" ><a href="#show" data-toggle="tab">查看</a></li>
			<li class="<%= editLi %>" ><a href="#edit" data-toggle="tab">编辑</a></li>
			<li class="<%= delLi %>" ><a href="#del" data-toggle="tab">删除</a></li>
		</ul>
		<div class="tab-content">
			<div class="<%= showClass %>" id="show">
				<div class="">
					<table class="table table-bordered table-striped">
						<tbody>
				          <tr>
				          	<td class="span3">学号</td>
				          	<td id="sno">30501229</td>
				          </tr>
				          <tr>
				          	<td>姓名</td>
				          	<td id="sname"></td>
				          </tr>
				          <tr>
				          	<td>性别</td>
				          	<td id="sex">男</td>
				          </tr>
				          <tr>
				          	<td>学院</td>
				          	<td id="institute">计算机0505</td>
				          </tr>
				          <tr>
				          	<td>专业</td>
				          	<td id="major">计算机0505</td>
				          </tr>
				          <tr>
				          	<td>班级</td>
				          	<td id="sclass">计算机0505</td>
				          </tr>
				          <tr>
				          	<td>联系电话</td>
				          	<td id="tel">13616551237</td>
				          </tr>
				          <tr>
				          	<td>Email</td>
				          	<td id="email"><a href="#">sunrisela@gmail.com</a></td>
				          </tr>
				          <tr>
				          	<td>英语等级</td>
				          	<td id="englishLevel">yiqikan.tv</td>
				          </tr>
				          <tr>
				          	<td>获得荣誉</td>
				          	<td id="honour"></td>
				          </tr>
				          <tr>
				          	<td>个人评价</td>
				          	<td id="intro"></td>
				          </tr>
				          <tr>
				          	<td>其他说明</td>
				          	<td id="remark"></td>
				          </tr>
				        </tbody>
					</table>
				</div>
			</div>
			<div class="<%= editClass %>" id="edit">
          	    <form class="form-horizontal" id="form_edit" action="student_edit.aspx">
          		    <fieldset>
          			    <div class="control-group">
          				    <label class="control-label" for="username">学号:</label>
          				    <div class="controls">
          					    <input type="text" class="input-xlarge" id="InputSno" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">姓名:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="InputSname" />
			                </div>
          			    </div>
          			    <div class="control-group">
	          			    <label class="control-label" for="select01">性别:</label>
	          			    <div class="controls">
			                    <select id="SelectSex" name="gender" class="span1">
			                        <option value="男">男</option>
			                        <option value="女">女</option>
			                    </select>
			                </div>
		                </div>
		                <div class="control-group">
          				    <label class="control-label" for="username">学院:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="InputInstitute" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">专业:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="InputMajor" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">班级:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="InputSclass" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">联系电话:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="InputTel" />
			               </div>
          		    	</div>
          		    	<div class="control-group">
          			    	<label class="control-label" for="username">Email:</label>
          		    		<div class="controls">
			                    <input type="text" class="input-xlarge" id="InputEmail" />
			               </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">英语等级:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="InputEng" />
			                </div>
          			    </div>
          			    <div class="control-group">
			                <label class="control-label" for="textarea">获得荣誉:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="TextareaHonour" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
			                <label class="control-label" for="textarea">个人评价:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="TextareaIntro" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
			                <label class="control-label" for="textarea">其他说明:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="TextareaRemark" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="form-actions">
			                <button type="submit" class="btn btn-primary" id="SubmitSave">保存</button>
			                <button class="btn">取消</button>
			            </div>
          		    </fieldset>
          	    </form>
          	</div>
          	<div class="<%= delClass %>" id="del">
          		<div class="alert alert-block alert-error fade in">
		            <h4 class="alert-heading">删除</h4>
		            <p>是否确定删除？</p>
		            <p>
		            	<a class="btn btn-danger" href="#" id="BtnDel">确定</a>
		            	<a class="btn" href="#">取消</a>
		            </p>
		        </div>
          	</div>
        </div>
    </div><!--/span-->
    

</asp:Content>

