<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPageStudent.master" AutoEventWireup="true" CodeFile="receive.aspx.cs" Inherits="Student_receive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ChoiceSystemConnectionString %>" 
        SelectCommand="SELECT * FROM [note] WHERE ([receiver] = @receiver)">
        <SelectParameters>
            <asp:SessionParameter Name="receiver" SessionField="userID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
        DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <tr>
            <td><%# Eval("sender") %></td>
            <td><%# Eval("topic") %></td>
            <td><%# Eval("content") %></td>
            <td><%# Eval("date") %></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
            <td><%# Eval("sender") %></td>
            <td><%# Eval("topic") %></td>
            <td><%# Eval("content") %></td>
            <td><%# Eval("date") %></td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <span>未返回数据。</span>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <div ID="itemPlaceholderContainer" runat="server" style="">
                <table class="table table-striped">
                    <thead>
					    <tr>
							<th>发件人</th>
							<th>主题</th>
							<th>内容</th>
							<th>时间</th>
						</tr>
					</thead>
					<tbody id="stu_info_tbody"> 
					    <span ID="itemPlaceholder" runat="server" />    
				    </tbody>
                </table>
            </div>
            <div style="">
                <asp:DataPager ID="DataPager1" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                            ShowLastPageButton="True" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
    </asp:ListView>
    </form>
</asp:Content>

