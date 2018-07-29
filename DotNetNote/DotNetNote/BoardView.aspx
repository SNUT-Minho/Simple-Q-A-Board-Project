<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardView.aspx.cs" Inherits="DotNetNote.DotNetNote.BoardView" %>

<%@ Register Src="~/DotNetNote/Controls/BoardCommentControl.ascx" TagPrefix="uc1" TagName="BoardCommentControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
  
</style>

    <div style="margin-top: 70px; border: 1px dotted #808080 ">
       
        <table style="margin-top: 20px; margin-bottom: 50px; width: 600px; margin-left: auto; margin-right: auto;">
             <tr style="border-bottom: 1px solid red;">
                <td><span class="glyphicon glyphicon-user" aria-hidden="true"></span>&nbsp;
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>님이 작성하신 내용입니다.</td>
                <td dir="rtl"  style="font-size:9px;"> <asp:Label ID="lblPostDate" runat="server" Text="" ></asp:Label> | Refer : <asp:Label ID="lblReadCount" runat="server" Text="" ></asp:Label></td>
                <td style="font-size:9px; margin-right:2px;"> </td>
            </tr>
            <tr>
                <td dir="ltr" style="font-size:9px; padding:auto;"><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span> 첨부파일 : <asp:Label ID="lblFile" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;|&nbsp;&nbsp;<span class="glyphicon glyphicon-send" aria-hidden="true"></span> 이메일 :  <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </td>
                <td dir="rtl"style="font-size:9px; padding:auto;" >
                   Article Number : <asp:Label ID="lblNum" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr >
                <td colspan="2">
                    <hr style="border:1px dotted orange;" />
                    <pre style="width:610px; white-space:pre-wrap;"><asp:Literal ID="ltlImage" runat="server"></asp:Literal><asp:Label ID="lblContent" runat="server" Width="600px" Height="115px"></asp:Label></pre>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr style="border:1px dotted #808080"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div><uc1:BoardCommentControl runat="server" ID="BoardCommentControl" /></div>
                </td>
            </tr>
        </table>

        <div style="text-align: center;">
            <asp:HyperLink ID="lnkDelte" runat="server" CssClass="btn btn-default">삭제</asp:HyperLink>
            <asp:HyperLink ID="lnkModify" runat="server" CssClass="btn btn-default">수정</asp:HyperLink>
            <asp:HyperLink ID="lnkReply" runat="server" CssClass="btn btn-default">답변</asp:HyperLink>
            <asp:HyperLink ID="lnkList" runat="server" NavigateUrl="BoardList.aspx" CssClass="btn btn-default">리스트</asp:HyperLink>
        </div>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>
        <br />
    </div>
</asp:Content>
