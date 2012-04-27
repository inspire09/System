<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/MasterPageManager.master" AutoEventWireup="true" CodeFile="teacher_edit.aspx.cs" Inherits="Manager_teacher_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <ul class="breadcrumb">
			<li>
			    <a href="#">Home</a> <span class="divider">/</span>
			</li>
			<li>
				<a href="teacher_index.aspx">教师信息</a> <span class="divider">/</span>
			</li>
			<li class="active">编辑</li>
		</ul>
        <ul class="nav nav-tabs">
			<li id="tea_show_tab" class="<%= showLi %>" ><a href="#tea_info_show" data-toggle="tab">查看</a></li>
			<li id="tea_edit_tab" class="<%= editLi %>" ><a href="#edit" data-toggle="tab">编辑</a></li>
			<li class="<%= delLi %>" ><a href="#del" data-toggle="tab">删除</a></li>
		</ul>
		<div class="tab-content">
			<div class="<%= showClass %>" id="tea_info_show">
				<div class="span10">
					<table class="table table-bordered table-striped">
						<tbody>
				          <tr>
				          	<td class="span3">员工号</td>
				          	<td id="tea_tno_td"></td>
				          </tr>
				          <tr>
				          	<td>姓名</td>
				          	<td id="tea_tname_td"></td>
				          </tr>
				          <tr>
				          	<td>性别</td>
				          	<td id="tea_sex_td"></td>
				          </tr>
				          <tr>
				          	<td>教研室</td>
				          	<td id="tea_room_td"></td>
				          </tr>
				          <tr>
				          	<td>联系电话</td>
				          	<td id="tea_tel_td"></td>
				          </tr>
				          <tr>
				          	<td>Email</td>
				          	<td id="tea_email_td"></td>
				          </tr>
				          <tr>
				          	<td>职称</td>
				          	<td id="tea_title_td"></td>
				          </tr>
				          <tr>
				          	<td>学历</td>
				          	<td id="tea_education_td"><a href="#"></a></td>
				          </tr>
				          <tr>
				          	<td>主教课程</td>
				          	<td id="tea_course_td"></td>
				          </tr>
				          <tr>
				          	<td>研究方向</td>
				          	<td id="tea_research_td"></td>
				          </tr>
				          <tr>
				          	<td>论文情况</td>
				          	<td id="tea_article_td"></td>
				          </tr>
				          <tr>
				          	<td>对学生要求</td>
				          	<td id="tea_demand_td"></td>
				          </tr>
				          <tr>
				          	<td>所在学院</td>
				          	<td id="tea_institute_td"></td>
				          </tr>
				        </tbody>
					</table>
				</div>
				<div align="center">
			        <a class="btn btn-primary" href="teacher_index.aspx">返回</a>
			    </div>
			</div>
			<div class="<%= editClass %>" id="edit">
          	    <form class="form-horizontal" id="tea_edit_form" method="post">
          		    <fieldset>
          			    <div class="control-group">
          				    <label class="control-label" for="username">员工号:</label>
          				    <div class="controls">
          					    <input type="text" class="input-xlarge" validation="{required:true}" id="tea_tno_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">姓名:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" validation="{required:true}" id="tea_tname_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
	          			    <label class="control-label" for="select01">性别:</label>
	          			    <div class="controls">
			                    <select id="tea_sex_select" class="span1">
			                        <option value="男">男</option>
			                        <option value="女">女</option>
			                    </select>
			                </div>
		                </div>
		                <div class="control-group">
          				    <label class="control-label" for="username">教研室:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="tea_room_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">联系电话:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="tea_tel_input" />
			               </div>
          		    	</div>
          		    	<div class="control-group">
          			    	<label class="control-label" for="username">Email:</label>
          		    		<div class="controls">
			                    <input type="text" class="input-xlarge" validation="{email:true}" id="tea_email_input" />
			               </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">职称:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="tea_title_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">学历:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="tea_education_input" />
			                </div>
          			    </div>
          			    
          			    <div class="control-group">
			                <label class="control-label" for="textarea">主教课程:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="tea_course_textarea" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
			                <label class="control-label" for="textarea">研究方向:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="tea_research_textarea" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
			                <label class="control-label" for="textarea">论文情况:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="tea_article_textarea" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
          				    <label class="control-label" for="username">对学生要求:</label>
          				    <div class="controls">
			                    <textarea class="input-xlarge" id="tea_demand_textarea" rows="3"></textarea>
			                </div>
          			    </div>
			            <div class="control-group">
          				    <label class="control-label" for="username">所在学院:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="tea_institute_input" />
			                </div>
          			    </div>
			            <div class="form-actions">
			                <button type="submit" class="btn btn-primary">保存</button>
			                <a class="btn" href="teacher_index.aspx">取消</a>
			            </div>
          		    </fieldset>
          	    </form>
          	</div>
          	<div class="<%= delClass %>" id="del" align="center">
          		<div class="alert alert-block alert-error fade in span10">
		            <h4 class="alert-heading">删除</h4>
		            <p>是否确定删除？</p>
		            <p>
		            	<a class="btn btn-danger" href="#" id="tea_del_btn">确定</a>
		            	<a class="btn" href="teacher_index.aspx">取消</a>
		            </p>
		        </div>
          	</div>
        </div>

</asp:Content>

