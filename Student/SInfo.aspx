<%@ Page Language="C#" Debug="true" MasterPageFile="MasterPageStudent.master" AutoEventWireup="true" CodeFile="SInfo.aspx.cs" Inherits="Student_SInfo" Title="无标题页" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        
            <div id="edit">
          	    <form class="form-horizontal" id="stu_edit_form" method="post">
          		    <fieldset>
          		        <legend>基本资料</legend>
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
			                    <input type="text" class="input-xlarge" validation="{required:true}" id="stu_major_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">班级:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" validation="{required:true}" id="stu_sclass_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
          				    <label class="control-label" for="username">联系电话:</label>
          				    <div class="controls">
			                    <input type="text" class="input-xlarge" id="stu_tel_input" />
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
			                    <input type="text" class="input-xlarge" id="stu_eng_input" />
			                </div>
          			    </div>
          			    <div class="control-group">
			                <label class="control-label" for="textarea">获得荣誉:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="stu_honour_textarea" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
			                <label class="control-label" for="textarea">个人评价:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="stu_intro_textarea" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="control-group">
			                <label class="control-label" for="textarea">其他说明:</label>
			                <div class="controls">
			                    <textarea class="input-xlarge" id="stu_remark_textarea" rows="3"></textarea>
			                </div>
			            </div>
			            <div class="form-actions">
			                <button type="submit" class="btn btn-primary">保存</button>
			                <a class="btn" href="SDefault.aspx">取消</a>
			            </div>
          		    </fieldset>
          	    </form>
          	</div>
        

</asp:Content>

