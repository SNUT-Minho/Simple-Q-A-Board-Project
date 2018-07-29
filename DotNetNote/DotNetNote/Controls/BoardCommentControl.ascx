<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoardCommentControl.ascx.cs" Inherits="DotNetNote.DotNetNote.Controls.BoardCommentControl" %>

<asp:Repeater ID="ctlCommentList" runat="server">
    <HeaderTemplate>
        <table style="padding: 10px; margin-left: 20px; margin-right: 20px; width: 95%;">
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="border-bottom:1px solid #808080;">
            <td style="width:80px;">
                <%# Eval("Name") %>
            </td>
            <td style="width: 250px;">
                  <%# Dul.HtmlUtility.Encode(Eval("Opinion").ToString()) %>
            </td>
            <td style="width: 180px;">
                  <%# Eval("PostDate") %>
            </td>
            <td style="width: 10px; text-align:center;">
                <a href='BoardCommentDelete.aspx?BoardId=<%= Request["Id"] %>&Id=<%# Eval("Id") %>&ANum=<%=Request["ANum"] %>' title="코멘트 삭제">
                    <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                </a>  
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>


<br /><br />  
<table style="width: 500px; margin-left:auto;">
    <tr>
        <td style="width: 64px; text-align:right;">이 름 :
        </td>
        <td style="width: 128px;">
            <asp:TextBox ID="txtName" runat="server" Width="128px" CssClass="form-control" style="display:inline-block;"></asp:TextBox>
        </td>
        <td style="width: 64px; text-align:right;">암 호 :
        </td>
        <td style="width: 128px;">
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="128px" CssClass="form-control" style="display:inline-block;"></asp:TextBox>
        </td>
        <td style="width: 128px; text-align:right;">
            <asp:Button ID="btnWriteComment" runat="server" Text="의견남기기" Width="96px"
                CssClass="form-control btn btn-primary" style="display:inline-block;" OnClick="btnWriteComment_OnClick" />
        </td>
    </tr>
    <tr>
        <td style="width: 64px; text-align:right;">의 견 :
        </td>
        <td colspan="4" style="width:448px;">
            <asp:TextBox ID="txtOpinion" runat="server" Rows="3" Columns="70" Width="448" CssClass="form-control" style="display:inline-block;" MaxLength="30"></asp:TextBox>
        </td>
        <asp:RequiredFieldValidator ID="valNameCommentControl" runat="server" ErrorMessage="이름을 입력하세요" ControlToValidate="txtName" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="valPasswordCommentControl" runat="server" ErrorMessage="암호를 입력하세요" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="valOpinionCommentControl" runat="server" ErrorMessage="내용을 입력하세요" ControlToValidate="txtOpinion" Display="None"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="valCommentSummary" runat="server" ShowSummary="false" ShowMessageBox="true" />
    </tr>
</table>
<hr />  
