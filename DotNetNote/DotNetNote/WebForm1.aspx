<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DotNetNote.DotNetNote.WebForm1" %>

<%@ Register Src="~/DotNetNote/AdvancedPagingSingleBootstrap.ascx" TagPrefix="uc1" TagName="AdvancedPagingSingleBootstrap" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
   
</head>
<body>
   
    <form id="form1" runat="server">
           <span class="label label-danger" style="height:auto; width:2px; font-size:1px;" >new</span>
        <div>
            <uc1:AdvancedPagingSingleBootstrap runat="server" ID="AdvancedPagingSingleBootstrap" />
        </div>
    </form>
</body>
</html>
