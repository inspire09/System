<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPageManager.master" AutoEventWireup="true" CodeFile="student_index.aspx.cs" Inherits="Manager_student_index" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../assets/js/jquery.js" type="text/javascript"></script>
        <script type="text/javascript">
        $(document).ready(function() {
            $('#Button2').click(function() { 
                $.ajax({
                    type: "POST",
                    
                    url: "../student_insert.ashx", 
                    data: "{sno:'1004',sname:'wang'}",
                    dataType: "json",
                    success: function(result){
                        alert(result.name);
                    }
                });  
            
            }); 
        }); 
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
										
				
				<form id="aaa" class="form-horizontal" method="post" Runat="Server">
				
				<input type="button" id="Button2" value="HelloWorld"/>         
    <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-primary" />
				<button id="btn1" type="button" class="btn btn-primary">保存</button>
	          	</form>
				
					    
</asp:Content>

