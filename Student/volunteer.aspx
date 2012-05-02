<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPageStudent.master" AutoEventWireup="true" CodeFile="volunteer.aspx.cs" Inherits="Student_volunteer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" class="form-inline form-search" runat="server" >
        <p>
        <asp:DropDownList ID="DropDownListCollege" runat="server" AutoPostBack="True" 
            CssClass="span2" 
            onselectedindexchanged="DropDownListCollege_SelectedIndexChanged">
            <asp:ListItem Selected="True">所有学院</asp:ListItem>
            <asp:ListItem>法学院</asp:ListItem>
            <asp:ListItem>工商管理学院</asp:ListItem>
            <asp:ListItem>经济与国际贸易学院</asp:ListItem>
            <asp:ListItem>金融学院</asp:ListItem>            
            <asp:ListItem>会计学院</asp:ListItem>
            <asp:ListItem>人文学院</asp:ListItem>
            <asp:ListItem>数学与统计学院</asp:ListItem>
            <asp:ListItem>外国语学院</asp:ListItem>
            <asp:ListItem>信息学院</asp:ListItem>           
            <asp:ListItem>艺术学院</asp:ListItem>
        </asp:DropDownList>
        </p>
        <asp:DropDownList ID="DropDownList1" CssClass="span2" runat="server">
            <asp:ListItem Selected="True" Value="tname">姓名</asp:ListItem>
            <asp:ListItem Value="title">职称</asp:ListItem>
            <asp:ListItem Value="education">学历</asp:ListItem>
            <asp:ListItem Value="research">研究方向</asp:ListItem>
            <asp:ListItem Value="course">主教课程</asp:ListItem>
            <asp:ListItem Value="room">教研室</asp:ListItem>
            <asp:ListItem Value="article">论文情况</asp:ListItem>
            <asp:ListItem Value="demand">对学生要求</asp:ListItem>
        </asp:DropDownList>
        
        <asp:TextBox ID="TextBox1" runat="server" CssClass="input-medium search-query span3" 
            placeholder="输入导师姓名搜索.."></asp:TextBox>
		<label class="checkbox">
    		<input type="checkbox" name="" /> 不显示已满的导师
  		</label>
  		
        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" onclick="BtnSelect_Click"><i class="icon-search icon-white"></i> 查询</asp:LinkButton>
 		
	</form>
	<!--			
	<div id="college_select" class="tabbable">
		<ul class="nav nav-tabs">
			<li class="active"><a href="#college_0" data-toggle="tab">所有学院</a></li>
			<li><a href="#college_0" data-toggle="tab">法学院</a></li>
			<li><a href="#college_0" data-toggle="tab">工商管理学院</a></li>
			<li><a href="#college_0" data-toggle="tab">经济与国际贸易学院</a></li>
			<li><a href="#college_0" data-toggle="tab">金融学院</a></li>
			<li><a href="#college_0" data-toggle="tab">会计学院</a></li>
	        <li><a href="#college_0" data-toggle="tab">人文学院</a></li>
	        <li><a href="#college_0" data-toggle="tab">数学与统计学院</a></li>
	        <li><a href="#college_0" data-toggle="tab">外国语学院</a></li>
	        <li><a href="#college_0" data-toggle="tab">信息学院</a></li>
	        <li><a href="#college_0" data-toggle="tab">艺术学院</a></li>			
		</ul>
	</div>
	-->
	<div class="tab-content">
        <div id="college_0" class="tab-pane fade active in">       						
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:ChoiceSystemConnectionString %>" 
                 SelectCommand="SELECT * FROM [teacherInfo]"></asp:SqlDataSource>					
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="tno" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <li class="span3">
					    <div class="thumbnail">
                            <img src="../assets/img/teacher/<%# Eval("photo") %>.jpg" />
                            <div class="favorite clearfix">
                                <a class="btn btn-danger"><i class="icon-heart icon-white"></i> 赞<span>(18)</span></a>
                                <a href="write.aspx?receiverID=<%# Eval("tno") %>" class="btn btn-success pull-right"><i class="icon-envelope icon-white"></i> 私信</a>
                            </div>
                            <div class="caption">
                                <h4><%# Eval("tname") %></h4>
                                <p><%# Eval("title") %><span class="pull-right"><%# Eval("education") %></span></p>
                                <p><%# Eval("research") %></p>
                                <p><%# Eval("email") %></p>
                                <p><a href="#" rel="popover" title="概况" data-content="教研室:<%# Eval("room") %><br/>电话:<%# Eval("tel") %><br/>主教课程:<%# Eval("course") %><br/>论文情况:<%# Eval("article") %><br/>对学生要求:<%# Eval("demand") %>">详细资料</a></p>
                                <div class='confirm clearfix'>
                                    <p class='pull-left'>
                                    <span class='badge badge-warning'>3</span> / <span class='badge badge-success'>8</span>
                                    </p>
                                    <div class='btn-group pull-right'>
                                        <button class='btn btn-primary dropdown-toggle' data-toggle='dropdown'>
                                            <i class='icon-ok icon-white'></i> 选定&nbsp;<span class='caret'></span>
                                        </button>
                                        <ul class='dropdown-menu'>
                                            <li><input type="hidden" id="tno_input" value="<%# Eval("tno") %>" /></li>
                                            <li><a href='#' data-choice="0">第一志愿</a></li>
                                            <li><a href='#' data-choice="1">第二志愿</a></li>
                                            <li><a href='#' data-choice="2">第三志愿</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <li class="span3">
					    <div class="thumbnail">
                            <img src="../assets/img/teacher/<%# Eval("photo") %>.jpg" />
                            <div class="favorite clearfix">
                                <a class="btn btn-danger"><i class="icon-heart icon-white"></i> 赞<span>(18)</span></a>
                                <a href="write.aspx?receiverID=<%# Eval("tno") %>" class="btn btn-success pull-right"><i class="icon-envelope icon-white"></i> 私信</a>
                            </div>
                            <div class="caption">
                                <h4><%# Eval("tname") %></h4>
                                <p><%# Eval("title") %><span class="pull-right"><%# Eval("education") %></span></p>
                                <p><%# Eval("research") %></p>
                                <p><%# Eval("email") %></p>
                                <p><a href="#" rel="popover" title="概况" data-content="教研室:<%# Eval("room") %><br/>电话:<%# Eval("tel") %><br/>主要课程:<%# Eval("course") %><br/>论文情况:<%# Eval("article") %>">详细资料</a></p>
                                <div class='confirm clearfix'>
                                    <p class='pull-left'>
                                    <span class='badge badge-warning'>3</span> / <span class='badge badge-success'>8</span>
                                    </p>
                                    <div class='btn-group pull-right'>
                                        <button class='btn btn-primary dropdown-toggle' data-toggle='dropdown'>
                                            <i class='icon-ok icon-white'></i> 选定&nbsp;<span class='caret'></span>
                                        </button>
                                        <ul class='dropdown-menu'>
                                            <li><input type="hidden" id="tno_input" value="<%# Eval("tno") %>" /></li>
                                            <li><a href='#' data-choice="0">第一志愿</a></li>
                                            <li><a href='#' data-choice="1">第二志愿</a></li>
                                            <li><a href='#' data-choice="2">第三志愿</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>
                    <span>未返回数据。</span>
                </EmptyDataTemplate>            
                <LayoutTemplate>
                    <div ID="itemPlaceholderContainer" runat="server" style="">
                        <div class="span9">
        		            <ul class="thumbnails">
					            <span ID="itemPlaceholder" runat="server" />
				            </ul>
        	            </div>                   
                    </div>               
                </LayoutTemplate>           
            </asp:ListView>					        				
        </div>               
    </div>

</asp:Content>

