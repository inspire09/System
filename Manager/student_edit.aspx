<%@ Page Title="" Language="C#" MasterPageFile="MasterPageManager.master" AutoEventWireup="true" CodeFile="student_edit.aspx.cs" Inherits="Manager_student_edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
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
			<li id="stu_show_tab" class="<%= showLi %>" ><a href="#stu_info_show" data-toggle="tab">查看</a></li>
			<li id="stu_edit_tab" class="<%= editLi %>" ><a href="#edit" data-toggle="tab">编辑</a></li>
			<li class="<%= delLi %>" ><a href="#del" data-toggle="tab">删除</a></li>
		</ul>
		<div class="tab-content">
			<div class="<%= showClass %>" id="stu_info_show">
				<div class="span10">
					<table class="table table-bordered table-striped">
						<tbody>
				          <tr>
				          	<td class="span3">学号</td>
				          	<td id="stu_sno_td"></td>
				          </tr>
				          <tr>
				          	<td>姓名</td>
				          	<td id="stu_sname_td"></td>
				          </tr>
				          <tr>
				          	<td>性别</td>
				          	<td id="stu_sex_td"></td>
				          </tr>
				          <tr>
				          	<td>学院</td>
				          	<td id="stu_institute_td"></td>
				          </tr>
				          <tr>
				          	<td>专业</td>
				          	<td id="stu_major_td"></td>
				          </tr>
				          <tr>
				          	<td>班级</td>
				          	<td id="stu_sclass_td"></td>
				          </tr>
				          <tr>
				          	<td>联系电话</td>
				          	<td id="stu_tel_td"></td>
				          </tr>
				          <tr>
				          	<td>Email</td>
				          	<td id="stu_email_td"><a href="#"></a></td>
				          </tr>
				          <tr>
				          	<td>英语等级</td>
				          	<td id="stu_eng_td"></td>
				          </tr>
				          <tr>
				          	<td>获得荣誉</td>
				          	<td id="stu_honour_td"></td>
				          </tr>
				          <tr>
				          	<td>个人评价</td>
				          	<td id="stu_intro_td"></td>
				          </tr>
				          <tr>
				          	<td>其他说明</td>
				          	<td id="stu_remark_td"></td>
				          </tr>
				        </tbody>
					</table>
				</div>
			</div>
			<div class="<%= editClass %>" id="edit">
          	    <form class="form-horizontal" id="stu_edit_form" method="post">
          		    <fieldset>
          			    <div class="control-group">
          				    <label class="control-label" for="username">学号:</label>
          				    <div class="controls">
          					    <input type="text" class="input-xlarge" validation="{required:true}" id="stu_sno_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">姓名:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" validation="{required:true}" id="stu_sname_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
	          			    <label class="control-label" for="select01">性别:</label>
	          			    <div class="controls">
			                    <select id="stu_sex_select" name="sex" class="span1">
			                        <option value="男">男</option>
			                        <option value="女">女</option>
			                    </select>
			                </div>
		                </div>
		                <div class="control-group">
          				    <label class="control-label" for="username">学院:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" validation="{required:true}" id="stu_institute_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">专业:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" name="major" id="stu_major_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">班级:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" name="sclass" id="stu_sclass_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">联系电话:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" name="tel" id="stu_tel_input" />
			               </div>
          		    	</div>
          		    	<div class="control-group">
          			    	<label class="control-label" for="username">Email:</label>
          		    		<div class="controls">
			                    <input type="text" class="input-xlarge" validation="{email:true}" name="email" id="stu_email_input" />
			               </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">英语等级:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" name="eng" id="stu_eng_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
			                <label class="control-label" for="textarea">获得荣誉:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" name="honour" id="stu_honour_textarea" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
			                <label class="control-label" for="textarea">个人评价:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" name="intro" id="stu_intro_textarea" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
			                <label class="control-label" for="textarea">其他说明:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" name="remark" id="stu_remark_textarea" rows="3"></textarea>
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
          		<div class="alert alert-block alert-error fade in span10">
		            <h4 class="alert-heading">删除</h4>
		            <p>是否确定删除？</p>
		            <p>
		            	<a class="btn btn-danger" href="#" id="stu_del_btn">确定</a>
		            	<a class="btn" href="#">取消</a>
		            </p>
		        </div>
          	</div>
        </div>
    

</asp:Content>

