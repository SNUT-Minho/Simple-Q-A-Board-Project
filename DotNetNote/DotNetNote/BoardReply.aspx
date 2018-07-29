<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardReply.aspx.cs" Inherits="DotNetNote.DotNetNote.BoardReply" %>


<%@ Register Src="~/DotNetNote/Controls/BoardEditorFormControl.ascx" TagPrefix="uc1" TagName="BoardEditorFormControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <uc1:BoardEditorFormControl runat="server" ID="BoardEditorFormControl" />
  
</asp:Content>
