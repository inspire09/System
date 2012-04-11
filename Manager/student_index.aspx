<%@ Page Language="C#" MasterPageFile="MasterPageManager.master" AutoEventWireup="true" CodeFile="student_index.aspx.cs" Inherits="Manager_student_index" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <ul class="breadcrumb">
			<li>
			    <a href="#">Home</a> <span class="divider">/</span>
			</li>
			<li class="active">学生信息</li>
		</ul>
		<ul class="nav nav-tabs">
			<li class="active"><a href="#list" data-toggle="tab">List</a></li>
			<li><a href="#add" data-toggle="tab">新增</a></li>
		</ul>
		<div class="tab-content">
			<div class="tab-pane fade active in" id="list">
				<form class="form-search">
					<select id="gender" name="gender" class="span2">
				        <option value="0">编号</option>
				        <option value="1">姓名</option>
				    </select>
					<input type="text" class="input-medium search-query span3" />
					<button type="submit" class="btn btn-primary"><i class="icon-search icon-white"></i> 查询</button>
				</form>
				<table class="table table-striped">
					<thead>
					    <tr>
							<th>ID</th>
							<th>学号</th>
							<th>姓名</th>
							<th>班级</th>
							<th>电话</th>
							<th class="th_options"></th>
						</tr>
					</thead>
					<tbody>
				        <tr>
				            <td>1</td>
				            <td>Mark</td>
				            <td>Otto</td>
				            <td>@mdo</td>
				            <td>13616551237</td>
				            <td class="options">
				            	<ul class="inline">
							        <li><a href="student_edit.aspx?sno=1001&operat=show">查看</a></li>
							        <li><a href="student_edit.aspx?sno=1001&operat=edit">编辑</a></li>
							        <li><a href="student_edit.aspx?sno=1001&operat=del">删除</a></li>
							    </ul>
				            </td>
				        </tr>
				        <tr>
				            <td>2</td>
				            <td>Jacob</td>
				            <td>Thornton</td>
				            <td>@fat</td>
				            <td>13967442009</td>
				            <td class="options">
				            	<ul class="inline">
							        <li><a href="#">查看</a></li>
							        <li><a href="student_edit.html">编辑</a></li>
							        <li><a href="#">删除</a></li>
							    </ul>
				            </td>
				        </tr>
				        <tr>
				            <td>3</td>
				            <td>Larry</td>
				            <td>the Bird</td>
				            <td>@twitter</td>
				            <td>13506628933</td>
				            <td class="options">
				            	<ul class="inline">
							          <li><a href="#">查看</a></li>
							          <li><a href="student_edit.html">编辑</a></li>
							          <li><a href="#">删除</a></li>
							    </ul>
				            </td>
				        </tr>
				    </tbody>
			    </table>
				<!-- 分页 -->
				<div class="pagination">
					<ul>
							    <li class="disabled"><a href="#">« 上一页</a></li>
							    <li class="active">
							      <a href="#">1</a>
							    </li>
							    <li><a href="#">2</a></li>
							    <li><a href="#">3</a></li>
							    <li><a href="#">4</a></li>
							    <li><a href="#">下一页 »</a></li>
					</ul>
				</div>
			</div>
			<div class="tab-pane fade" id="add">
				<form id="form_Add" class="form-horizontal" method="post" action="student_index.aspx">
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

