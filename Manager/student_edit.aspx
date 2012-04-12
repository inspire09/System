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
			<li id="li_show" class="<%= showLi %>" ><a href="#show" data-toggle="tab">查看</a></li>
			<li id="li_edit" class="<%= editLi %>" ><a href="#edit" data-toggle="tab">编辑</a></li>
			<li class="<%= delLi %>" ><a href="#del" data-toggle="tab">删除</a></li>
		</ul>
		<div class="tab-content">
			<div class="<%= showClass %>" id="show">
				<div class="span10">
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
				          	<td id="institute"></td>
				          </tr>
				          <tr>
				          	<td>专业</td>
				          	<td id="major"></td>
				          </tr>
				          <tr>
				          	<td>班级</td>
				          	<td id="sclass"></td>
				          </tr>
				          <tr>
				          	<td>联系电话</td>
				          	<td id="tel"></td>
				          </tr>
				          <tr>
				          	<td>Email</td>
				          	<td id="email"><a href="#"></a></td>
				          </tr>
				          <tr>
				          	<td>英语等级</td>
				          	<td id="englishLevel"></td>
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
          	    <form class="form-horizontal" id="form_edit" method="post">
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
          		<div class="alert alert-block alert-error fade in span10">
		            <h4 class="alert-heading">删除</h4>
		            <p>是否确定删除？</p>
		            <p>
		            	<a class="btn btn-danger" href="#" id="BtnDel">确定</a>
		            	<a class="btn" href="#">取消</a>
		            </p>
		        </div>
          	</div>
        </div>
    

</asp:Content>

