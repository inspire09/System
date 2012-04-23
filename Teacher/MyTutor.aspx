<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/MasterPageTeacher.master"
    AutoEventWireup="true" CodeFile="MyTutor.aspx.cs" Inherits="Teacher_myTutor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="stu_count">
        <p>
            已选学生数：<span id="count" class='badge badge-warning'></span>
        </p>
        <p>
            可选学生数：<span id="total" class='badge badge-success'></span>
        </p>
    </div>
    <table id="mytutor_table" class="table table-striped">
        <thead>
            <tr>
                <th>
                    学号
                </th>
                <th>
                    姓名
                </th>
                <th>
                    性别
                </th>
                <th>
                    学院
                </th>
                <th>
                    专业
                </th>
                <th class="th_options">
                </th>
                <th class="th_options">
                </th>
            </tr>
        </thead>
        <tbody id="mytutor_tbody">
        </tbody>
    </table>
</asp:Content>
