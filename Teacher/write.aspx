<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/MasterPageTeacher.master"
    AutoEventWireup="true" CodeFile="write.aspx.cs" Inherits="Teacher_write" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="write">
        <form class="form-horizontal" id="tea_write_form" method="post">
        <fieldset>
            <legend>写信</legend>
            <div class="control-group">
                <label class="control-label" for="username">
                    收件人:</label>
                <div class="controls">
                    <input type="text" class="input-xlarge" validation="{required:true}" value="<%=receiverID %>"
                        id="tea_receiver_input" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="username">
                    题目:</label>
                <div class="controls">
                    <input type="text" class="input-xlarge" validation="{required:true}" id="tea_topic_input" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="textarea">
                    内容:</label>
                <div class="controls">
                    <textarea class="input-xlarge" id="tea_content_textarea" rows="8"></textarea>
                </div>
            </div>
            <div class="form-actions">
                <button type="submit" class="btn btn-primary">
                    发送</button>
                <a class="btn" href="SDefault.aspx">取消</a>
            </div>
        </fieldset>
        </form>
    </div>
</asp:Content>
