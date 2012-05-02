<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPageStudent.master"
    AutoEventWireup="true" CodeFile="write.aspx.cs" Inherits="Student_write" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form-horizontal" id="stu_write_form" method="post">
    <fieldset>
        <legend>写信</legend>
        <div class="control-group">
            <label class="control-label" for="username">
                收件人:</label>
            <div class="controls">
                <input type="text" class="input-xlarge" validation="{required:true}" value="<%=receiverID %>" id="stu_receiver_input" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="username">
                题目:</label>
            <div class="controls">
                <input type="text" class="input-xlarge" validation="{required:true}" id="stu_topic_input" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="textarea">
                内容:</label>
            <div class="controls">
                <textarea class="input-xlarge" id="stu_content_textarea" rows="8"></textarea>
            </div>
        </div>
        <div class="form-actions">
            <button type="submit" class="btn btn-primary">发送</button>
            <a class="btn" href="SDefault.aspx">取消</a>
        </div>
    </fieldset>
    </form>
</asp:Content>
