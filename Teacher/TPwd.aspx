﻿<%@ Page Language="C#" MasterPageFile="MasterPageTeacher.master" AutoEventWireup="true" CodeFile="TPwd.aspx.cs" Inherits="Teacher_TPassword" Title="无标题页" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

          <div class="row-fluid">
          	<form id="form1" runat="server" class="form-horizontal">
          		<fieldset>
          			<legend>修改密码</legend>
          			<div class="control-group">
          				<label class="control-label" for="username">旧密码:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxOldPwd" runat="server" CssClass="input-xlarge"></asp:TextBox>			              
			            </div>
          			</div>
          			<div class="control-group">
	          			<label class="control-label" for="select01">新密码:</label>
	          			<div class="controls">
			              <asp:TextBox ID="TextBoxNewPwd" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
		            </div>
          			<div class="control-group">
          				<label class="control-label" for="username">确认密码:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxNewPwdAgain" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
          			</div>
			        <div class="form-actions">
                        <asp:Button ID="ButtonUpdate" runat="server" Text="修改" 
                            CssClass="btn btn-primary" onclick="ButtonUpdate_Click" />    
                        <asp:Button ID="ButtonCancel" runat="server" Text="取消" CssClass="btn" />
			        </div>
          		</fieldset>
          	</form>
          </div>

</asp:Content>

