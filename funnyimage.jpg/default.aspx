<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="funnyimage.jpg._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Media</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <style>
        body {
}

.btnVis{
    display: none;
}
    </style>
</head>
<body>
    
    <form id="fmImage" runat="server">
    <div>

        <img src="myimage.jpg" alt="my Image" />
    
         <asp:HiddenField ID="HFXcoords" runat="server"   />
        <asp:HiddenField ID="HFYcoords" runat="server" />


         <asp:ScriptManager runat="server" ID="sm">
 </asp:ScriptManager>
 <asp:updatepanel runat="server">
 <ContentTemplate>
 <asp:Button ID="btnGetHiddenCoord" runat="server" OnClick="btnGetHiddenCoord_Click" Text="get values" CssClass="btnVis" />
 </ContentTemplate>
 </asp:updatepanel>
        
         <input id="btnstopTimer" class="btnVis" value="stop timer" onclick="clearTimeout(timer);" />
    </div>
    </form>


</body>

    <script src="data.js"></script>

</html>
