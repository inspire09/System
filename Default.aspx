<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>综合导师系统</title>
    <!-- Le styles -->
    <link href="assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />   
    <link href="assets/css/bootstrap-plus.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/login.css" rel="stylesheet" type="text/css" />
    
    <!-- Le javascript -->
    <script src="assets/js/jquery.js" type="text/javascript"></script>
    <script src="assets/js/jquery.patch.js" type="text/javascript"></script>
    <script src="assets/js/jquery.form.js" type="text/javascript"></script>
    <script src="assets/js/jquery.metadata.js" type="text/javascript"></script>
    <script src="assets/js/jquery.validate.js" type="text/javascript"></script>
    <script src="assets/js/jquery.validate.messages_cn.js" type="text/javascript"></script>  
    <script src="assets/js/bootstrap.js" type="text/javascript"></script>
    <script src="assets/js/login.js" type="text/javascript"></script>
    
</head>
<body>
    
        <div class="container">
			<div class="jumbotron masthead">
				<h1>综合导师系统</h1>
			</div>
			<div class="row">
				<div class="span4 offset4">
					<div id="login">
						<form id="login_form" runat="server" class="form-horizontal" method="post">
							<h2>用户登录</h2>
							<div class="control-group">
								<label>帐号</label>
								<div class="input">
									<asp:TextBox ID="TextBoxUserID" runat="server" CssClass="span3"
									    validation="{required:true}" placeholder="Enter your username…"></asp:TextBox>    
								</div>
							</div>
							<div class="control-group">
								<label>密码</label>
								<div class="input">
									<asp:TextBox ID="TextBoxUserPass" runat="server" CssClass="span3" 
                                        validation="{required:true}" placeholder="Enter your password…"></asp:TextBox>
								</div>
							</div>
							<div class="control-group actions clearfix">
								<div class="select pull-left">
									<asp:DropDownList ID="DropDownListPrivilege" runat="server" CssClass="btn span2">
                                        <asp:ListItem Selected="True">学生</asp:ListItem>
                                        <asp:ListItem>教师</asp:ListItem>
                                        <asp:ListItem>管理员</asp:ListItem>
                                    </asp:DropDownList>
								</div>
								<asp:Button ID="ButtonLogin" runat="server" Text="登录" CssClass="btn silver-btn pull-right" 
                                     onclick="ButtonLogin_Click"/>
							</div>
							<div class="clearfix">
								<a href="#" class="forgot-password pull-left">忘记密码?</a>
							</div>
						</form>
					</div>
				</div>
			</div>
		</div>
		
</body>
</html>
