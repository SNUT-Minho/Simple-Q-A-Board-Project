<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardWrite.aspx.cs" Inherits="DotNetNote.DotNetNote.BoardWrite" ValidateRequest="false" %>

<%@ Register Src="~/DotNetNote/Controls/BoardWriteFromControl.ascx" TagPrefix="uc1" TagName="BoardWriteFromControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <uc1:BoardWriteFromControl runat="server" ID="BoardWriteFromControl" />
 
</asp:Content>
