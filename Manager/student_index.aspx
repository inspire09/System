<%@ Page Language="C#" MasterPageFile="MasterPageManager.master" AutoEventWireup="true" CodeFile="student_index.aspx.cs" Inherits="Manager_student_index" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <ul class="breadcrumb">
			<li>
			    <a href="#">Home</a> <span class="divider">/</span>
			</li>
			<li class="active">学生信息</li>
		</ul>
		<ul class="nav nav-tabs">
			<li id="stu_info_tab" class="active"><a href="#list" data-toggle="tab">学生信息</a></li>
			<li id="stu_add_tab" ><a href="#add" data-toggle="tab">新增</a></li>
		</ul>
		<div class="tab-content">
			<div class="tab-pane fade active in" id="list">
				<form class="form-search" id="stu_select_form" method="post" action="student_index.aspx">
					<select id="SelectName" class="span2">
				        <option value="学号">学号</option>
				        <option value="姓名">姓名</option>
				        <option value="学院">学院</option>
				        <option value="专业">专业</option>
				        <option value="班级">班级</option>
				    </select>
					<input  id="InputValue" type="text" class="input-medium search-query span3" />
					<button type="submit" class="btn btn-primary"><i class="icon-search icon-white"></i> 查询</button>
				</form>
				<table id="stu_info_table" class="table table-striped">
					<thead>
					    <tr>
							<th>学号</th>
							<th>姓名</th>
							<th>性别</th>
							<th>学院</th>
							<th>专业</th>
							<th>班级</th>
							<th class="th_options"></th>
						</tr>
					</thead>
					<tbody id="stu_info_tbody">     
				    </tbody>
			    </table>
				<!-- 分页 -->
				<div class="pagination">
					<ul>
						<li class="disabled"><a href="#">« 上一页</a></li>
						<li class="active"><a href="#">1</a></li>
						<li><a href="#">2</a></li>
						<li><a href="#">3</a></li>
						<li><a href="#">4</a></li>
						<li><a href="#">下一页 »</a></li>
					</ul>
				</div>
			</div>
			<div class="tab-pane fade" id="add">
				<form id="stu_add_form" class="form-horizontal" method="post">
	          		<fieldset>
	          			<div class="control-group">
	          				<label class="control-label" for="username">学号:</label>
	          				<div class="controls">
	          					<input type="text" class="input-xlarge" id="sno_input" />
				            </div>
	          			</div>
	          			<div class="control-group">
	          				<label class="control-label" for="username">姓名:</label>
	          				<div class="controls">
				              <input type="text" class="input-xlarge" id="sname_input" />
				            </div>
	          			</div>
				        <div class="form-actions">
				            <button type="submit" class="btn btn-primary">新增</button>
				            <button class="btn">取消</button>
				            <div id="resu"></div>
				        </div>
	          		</fieldset>
	          	</form>
			</div>
		</div>
				
		    
</asp:Content>

