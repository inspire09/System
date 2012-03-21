<%@ Page Language="C#" Debug="true" MasterPageFile="MasterPageStudent.master" AutoEventWireup="true" CodeFile="SInfo.aspx.cs" Inherits="Student_SInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="span10">
          <div class="row-fluid">
          	<form id="form1" runat="server" class="form-horizontal">
          		<fieldset>
          			<legend>基本资料</legend>
          			<div class="control-group">
          				<label class="control-label" for="username">学号:</label>
          				<div class="controls">
          					<asp:TextBox ID="TextBoxSno" runat="server" CssClass="input-xlarge" 
          					    ReadOnly="True"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">姓名:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxName" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
	          			<label class="control-label" for="select01">性别:</label>
	          			<div class="controls">
			              <asp:DropDownList ID="DropDownListSex" runat="server" CssClass="span1">
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                          </asp:DropDownList>
			            </div>
		            </div>
          			<div class="control-group">
          				<label class="control-label" for="username">学院:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxInstitute" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">专业:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxMajor" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">班级:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxClass" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">联系电话:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxTel" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">Email:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">英语等级:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxEng" runat="server" CssClass="input-xlarge"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
			            <label class="control-label" for="textarea">获得荣誉:</label>
			            <div class="controls">
			              <asp:TextBox ID="TextBoxHonour" runat="server" CssClass="input-xlarge" TextMode="MultiLine"></asp:TextBox>
			              <p class="help-block">In addition to freeform text.</p>
			            </div>
			          </div>
			          <div class="control-group">
			            <label class="control-label" for="textarea">个人评价:</label>
			            <div class="controls">
			              <asp:TextBox ID="TextBoxIntro" runat="server" CssClass="input-xlarge" TextMode="MultiLine"></asp:TextBox>
			            </div>
			          </div>
			          <div class="control-group">
			            <label class="control-label" for="textarea">其他说明:</label>
			            <div class="controls">
			              <asp:TextBox ID="TextBoxRemark" runat="server" CssClass="input-xlarge" TextMode="MultiLine"></asp:TextBox>
			            </div>
			          </div>
			          <div class="form-actions">
			            <asp:Button ID="ButtonSave" runat="server" Text="保存" CssClass="btn btn-primary" 
                              onclick="ButtonSave_Click" />    
                        <asp:Button ID="ButtonCancel" runat="server" Text="取消" CssClass="btn" />
			          </div>
          		</fieldset>
          	</form>
          </div>
        </div><!--/span-->
    
</asp:Content>

