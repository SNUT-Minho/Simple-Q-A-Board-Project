<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardCommentDelete.aspx.cs" Inherits="DotNetNote.DotNetNote.BoardCommentDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>게시판</h2>
<span style="color:red;">코멘트 삭제 - 정확한 암호를 입력하시면 코멘트를 삭제하실 수 있습니다.</span>
<hr />
<table style="width: 500px; margin-left: auto;margin-right:auto;" class="table">
    <tr style="text-align:center;">
        <td colspan="2">
            <i class="glyphicon glyphicon-lock"></i><span style="font-size: 12pt;"> &nbsp;코멘트 삭제</span>
        </td>
    </tr>
     <tr style="text-align:center;">
        <td></td>
        <td>
            <span>해당 코멘트를 삭제하시려면 올바른 암호를 입력하십시오.<br /></span>
            <br />
            <%--암호(<u>P</u>):--%>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="40" Width="250px" AccessKey="P" TabIndex="2" CssClass="form-control" style="margin-left:auto; margin-right:auto;"></asp:TextBox>
            
        </td>
    </tr>
     <tr>
        <td colspan="2" style="text-align:center;">
            <asp:Button ID="btnCommentDelete" runat="server" Text="확인" CssClass="btn btn-danger" OnClick="btnCommentDelete_Click" />
            <asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage="암호를 입력하세요" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />
            <input type="button" value="뒤로" onclick="history.go(-1);" class="btn btn-default" /><br />
            <asp:Label ID="lblError" runat="server" ForeColor="red"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
