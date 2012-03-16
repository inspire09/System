<%@ Page Language="C#" MasterPageFile="~/MasterPageStudent.master" AutoEventWireup="true" CodeFile="SDefault.aspx.cs" Inherits="Student_SDefault" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBoxOldPwd" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="TextBoxNewPwd" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="TextBoxNewPwdAgain" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="ButtonUpdate" runat="server" onclick="ButtonUpdate_Click" 
        Text="Button" />
</asp:Content>

