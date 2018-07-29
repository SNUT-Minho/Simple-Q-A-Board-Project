<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardDelete.aspx.cs" Inherits="DotNetNote.DotNetNote.BoardDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script>
    function ConfirmDelete() {
        var varFlage = false;
        if (window.confirm("현재 글을 삭제하시겠습니까?")) {
            varFlage = true;
        } else {
            varFlage = false;
        }
        return varFlage;
    }
</script>
    <h2>게시물 삭제</h2>
    <span style="color:red;">글 삭제 - 글을 삭제하려면 글 작성시에 기록하였던 비밀번호가 필요합니다.</span>
    <hr />
    <div style="text-align:center">
        <asp:Label ID="lblId" runat="server" ForeColor="red"></asp:Label>번 글을 지우시겠습니까?
        <br /><br />
        비밀번호 : 
        <asp:TextBox ID="txtPassword" runat="server" Width="120px" CssClass="form-control" style="display:inline-block;" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btnDelete" runat="server" Width="100px" CssClass="btn btn-danger" Text="지우기" Style="display:inline-block;" OnClick="btnDelete_Click" />
        <asp:HyperLink ID="lnkCancel" runat="server" CssClass="btn btn-default">취소</asp:HyperLink>
        <br /><br />
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
    </div>
</asp:Content>
