﻿<%@ Page Language="C#" MasterPageFile="MasterPageTeacher.master" AutoEventWireup="true" CodeFile="TInfo.aspx.cs" Inherits="Teacher_TInfo" Title="无标题页" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
            <div id="edit">
          	    <form class="form-horizontal" id="tea_edit_form" method="post">
          		    <fieldset>
          		        <legend>基本资料</legend>
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

</asp:Content>

