<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/MasterPageTeacher.master" AutoEventWireup="true" CodeFile="Tutor.aspx.cs" Inherits="Teacher_choose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
				<form class="form-search" id="stu_select_form" method="post">
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
				<div id="stu_count">
				    <p>
				        已选学生数：<span id="count" class='badge badge-warning'></span>  
                    </p>
                    <p>
                        可选学生数：<span id="total" class='badge badge-success'></span>
                    </p>
                </div>
				<table id="stu_info_table" class="table table-striped">
					<thead>
					    <tr>
							<th>学号</th>
							<th>姓名</th>
							<th>性别</th>
							<th>学院</th>
							<th>专业</th>
							<th class="th_options"></th>
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
    
</asp:Content>

