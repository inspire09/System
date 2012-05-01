<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/MasterPageTeacher.master"
    AutoEventWireup="true" CodeFile="SAvatar.aspx.cs" Inherits="Student_SAvatar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="upload_image_form" class="form-horizontal" method="post">
    <fieldset>
        <legend>修改头像</legend>
        <div class="control-group">
            <label class="control-label" for="fileInput">
                本地照片</label>
            <div class="controls">
                <input class="input-file" id="image_file" name="image_file" type="file">
            </div>
        </div>
        <div class="row">
        <div id="my_avatar" class="span4 img_crop_container">
            <img src="../assets/sample/pool.jpg" alt="" />
        </div>
        <div class="span3">
            <div class="avatar_preview" style="width: 225px; height: 300px; overflow: hidden;">
                <img src="../assets/sample/pool.jpg" alt="" />
            </div>
            <div style="width: 225px;">
                <div class="alert alert-info" style="padding: 9px;">
                    <h5>您上传的头像会自动生成225x300像素的尺寸</h5>
                </div>
            </div>
        </div>
    </div>
    <div class="form-actions">
        <button id="upload_image_btn" type="submit" class="btn btn-primary">保存</button>
        <button class="btn">取消</button>
    </div>
    </fieldset>
    </form>
    
    
</asp:Content>
