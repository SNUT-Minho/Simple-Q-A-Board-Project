<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoardSearchFormSingleControl.ascx.cs" Inherits="DotNetNote.DotNetNote.Controls.BoardSearchFormSingleControl" %>
<div style="text-align: center;">
    <asp:DropDownList ID="SearchField" runat="server" CssClass="form-control" Width="80px" Style="display: inline-block; padding-top: 8px; font-size: 13px;">
        <asp:ListItem Value="Name">이름</asp:ListItem>
        <asp:ListItem Value="Title">제목</asp:ListItem>
        <asp:ListItem Value="Content">내용</asp:ListItem>
    </asp:DropDownList>&nbsp;&nbsp;
        <asp:TextBox ID="SearchQuery" runat="server" Width="200px" CssClass="form-control" Style="display: inline-block;"></asp:TextBox>&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="valSearchQuery" runat="server" ErrorMessage="검색할 단어를 입력해주세요" ControlToValidate="SearchQuery" Display="None"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false" ShowMessageBox="true" />
    <asp:Button ID="btnSearch" runat="server" Text="검색" CssClass="form-control" Width="100px" Style="display: inline-block; font-size: 13px" OnClick="btnSearch_Click" />
</div>
<br />
<% if (!string.IsNullOrEmpty(Request.QueryString["SearchField"]) && !String.IsNullOrEmpty(Request.QueryString["SearchQuery"])){ %>
<div style="text-align: center; width:auto; ">
    <a href="BoardList.aspx" class="btn btn-success">검색 완료</a>
</div>
<%}  %>
