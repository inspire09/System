<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPageStudent.master"
    AutoEventWireup="true" CodeFile="my_vol.aspx.cs" Inherits="Student_myvolunteer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <table id="myvol_table"  class="table table-striped">
        <thead>
            <tr>
                <th>
                    志愿类别
                </th>
                <th>
                    导师
                </th>
                <th>
                    状态
                </th>
                <th class="th_options">
                </th>
            </tr>
        </thead>
        <tbody id="myvol_tbody">
            <tr>
                <td>
                    第一志愿
                </td>
                <td id="tname_0_td">
                    
                </td>
                <td id="status_0_td">
                    
                </td>
                <td id="operat_0_td">
                    <a href='volunteer.aspx'>选择志愿</a>
                </td>
            </tr>
            <tr>
                <td>
                    第二志愿
                </td>
                <td id="tname_1_td">
                    
                </td>
                <td id="status_1_td">
                    
                </td>
                <td id="operat_1_td">
                    <a href='volunteer.aspx'>选择志愿</a>
                </td>
            </tr>
            <tr>
                <td>
                    第三志愿
                </td>
                <td id="tname_2_td">
                    
                </td>
                <td id="status_2_td">
                    
                </td>
                <td id="operat_2_td">
                    <a href='volunteer.aspx'>选择志愿</a>
                </td>
            </tr>
        </tbody>
    </table>
    
</asp:Content>
