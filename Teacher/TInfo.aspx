<%@ Page Language="C#" MasterPageFile="~/MasterPageTeacher.master" AutoEventWireup="true" CodeFile="TInfo.aspx.cs" Inherits="Teacher_TInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
        
        <div class="span10">
          <div class="row-fluid">
          	<form id="form2" runat="server" class="form-horizontal">
          	
          	    <fieldset>
          			<legend>基本资料</legend>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ChoiceSystemConnectionString %>" 
                    SelectCommand="SELECT [sname], [sex], [institute], [major], [class], [tel], [email], [englishLevel], [honour], [intro], [remark] FROM [studentInfo] WHERE ([sno] = @sno)">
                    <SelectParameters>
                        <asp:SessionParameter Name="sno" SessionField="userID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>         	
          	
          		<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <div class="control-group">
          				<label class="control-label" for="username">学号:</label>
          				<div class="controls">
          					<asp:TextBox ID="TextBox1" runat="server" CssClass="input-xlarge" 
          					    Enabled="False"></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">姓名:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxName" runat="server" CssClass="input-xlarge"
			                Text='<%# Eval("sname") %>'></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
	          			<label class="control-label" for="select01">性别:</label>
	          			<div class="controls">
			              <asp:DropDownList ID="DropDownListSex" runat="server" CssClass="span1" 
                                SelectedValue='<%# Eval("sex") %>'>
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                          </asp:DropDownList>
			            </div>
		            </div>
          			<div class="control-group">
          				<label class="control-label" for="username">学院:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxInstitute" runat="server" CssClass="input-xlarge"
			                Text='<%# Eval("institute") %>'></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">专业:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxMajor" runat="server" CssClass="input-xlarge"
			                Text='<%# Eval("major") %>'></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">班级:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxClass" runat="server" CssClass="input-xlarge"
			                Text='<%# Eval("class") %>'></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">联系电话:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxTel" runat="server" CssClass="input-xlarge"
			                Text='<%# Eval("tel") %>'></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
          				<label class="control-label" for="username">Email:</label>
          				<div class="controls">
			              <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="input-xlarge"
			                Text='<%# Eval("email") %>'></asp:TextBox>
			            </div>
          			</div>
          			<div class="control-group">
			            <label class="control-label" for="textarea">获得荣誉:</label>
			            <div class="controls">
			              <asp:TextBox ID="TextBoxHonour" runat="server" CssClass="input-xlarge" 
                                TextMode="MultiLine" Text='<%# Eval("honour") %>'></asp:TextBox>
			              <p class="help-block">In addition to freeform text.</p>
			            </div>
			          </div>
			          <div class="control-group">
			            <label class="control-label" for="textarea">个人评价:</label>
			            <div class="controls">
			              <asp:TextBox ID="TextBoxIntro" runat="server" CssClass="input-xlarge" 
                                TextMode="MultiLine" Text='<%# Eval("intro") %>'></asp:TextBox>
			            </div>
			          </div>
			          <div class="control-group">
			            <label class="control-label" for="textarea">其他说明:</label>
			            <div class="controls">
			              <asp:TextBox ID="TextBoxRemark" runat="server" CssClass="input-xlarge" 
                                TextMode="MultiLine" Text='<%# Eval("remark") %>'></asp:TextBox>
			            </div>
			          </div>
			          <div class="form-actions">
			            <asp:Button ID="ButtonSave" runat="server" Text="保存" CssClass="btn btn-primary" />    
                        <asp:Button ID="ButtonCancel" runat="server" Text="取消" CssClass="btn" />
			          </div>
                    </ItemTemplate>
                </asp:DataList>
          			
          		</fieldset>
          	</form>
          </div>
        </div><!--/span-->

</asp:Content>

