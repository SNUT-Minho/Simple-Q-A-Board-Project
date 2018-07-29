<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoardEditorFormControl.ascx.cs" Inherits="DotNetNote.DotNetNote.Controls.BoardEditorFormControl" %>

<style>
    html {
        min-width: 500px;
    }

    tr {
        height: 50px;
    }

    /*tr, td {
        border: 1px solid red;
    }*/

    .BoardWriteFormTableLeftStyle {
        width: 100px;
        text-align: right;
    }
</style>

<h2>게시판</h2>
<asp:Label ID="lblTitleDescription" runat="server" Text="" ForeColor="red"></asp:Label>
<hr />
<table style="width: 600px; border-collapse: collapse; padding: 5px; margin-left: auto; margin-right: auto;">
    <% if (!String.IsNullOrEmpty(Request.QueryString["Id"]) && FormType == DotNetNote.DotNetNote.Models.BoardWriteFormType.Modify)
        { %>
    <tr>
        <td class="BoardWriteFormTableLeftStyle">
            <span style="color: red;">*</span>번&nbsp;호
        </td>
        <td style="width: 400px; padding-left: 10px">
            <%= Request.QueryString["ANum"] %>
        </td>
    </tr>
    <% } %>
    <tr>
        <td class="BoardWriteFormTableLeftStyle">
            <span style="color: red;">*</span>이름&nbsp;
        </td>
        <td style="width: 400px; padding-left: 10px">
            <asp:TextBox ID="txtName" runat="server" MaxLength="10" Width="150px" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valName"
                runat="server" ErrorMessage=" 이름을 작성해 주세요." ControlToValidate="txtName" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">E-mail
        </td>
        <td style="padding-left: 10px">
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="80" Width="150px" CssClass="form-control" Style="display: inline-block"></asp:TextBox>
            <span style="color: #aaaaaa; font-style: italic">&nbsp;(Optional)</span>
            <asp:RegularExpressionValidator ID="valEmail" runat="server"
                ErrorMessage="메일형식이 올바르지 않습니다."
                ControlToValidate="txtEmail"
                Display="None" SetFocusOnError="True"
                ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">HomePage
        </td>
        <td style="padding-left: 10px">
            <asp:TextBox ID="txtHomepage" runat="server" CssClass="form-control" Style="display: inline-block;" MaxLength="80" Width="300px"></asp:TextBox>
            <span style="color: #aaaaaa; font-style: italic">&nbsp;(Optional)</span>
            <asp:RegularExpressionValidator ID="valHomepage" runat="server"
                ErrorMessage=" 홈페이지를 정확히 작성해주세요."
                ControlToValidate="txtHomepage" Display="None"
                ValidationExpression="^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"
                SetFocusOnError="True"></asp:RegularExpressionValidator>
        </td>
    </tr>

    <tr>
        <td style="text-align: right">
            <span style="color: red;">*</span>제 목
        </td>
        <td style="padding-left: 10px">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Style="display: inline-block;"
                MaxLength="30" Width="480px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valTitle" runat="server"
                ErrorMessage=" 제목을 기입해 주세요." ControlToValidate="txtTitle" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            <span style="color: red;">*</span>내&nbsp;용
        </td>
        <td style="padding-left: 10px">
            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="200px" Width="480px" CssClass="form-control" Style="display: inline-block"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="valContent" runat="server" ErrorMessage=" 내용을 기입해 주세요." ControlToValidate="txtContent" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr style="height: 70px">
        <td style="text-align: right;">파일첨부</td>
        <td style="padding-left: 10px">
            <asp:CheckBox ID="chkUpLoad" OnCheckedChanged="chkUpload_checkedChange" runat="server" CssClass="check-inline" Text="&nbsp;&nbsp;체크박스 선택시 파일 업로드 가능" AutoPostBack="True" Checked="false" />
            <span style="color: #aaaaaa; font-style: italic;">&nbsp;(Optional)</span>
            <asp:Panel ID="pnlFile" runat="server" Width="240px" Visible="False" Height="40px" Style="display: inline;">
                <input id="txtFileName" style="width: 290px; height: 35px;" type="file" size="29" name="File1" runat="server" class="form-control" />
                <asp:Label ID="lblFileNamePrevious" runat="server" Text="" Visible="false"></asp:Label>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">인코딩</td>
        <td style="padding-left: 10px">
            <asp:RadioButtonList ID="rdoEncoding" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="Text" Selected="True">&nbsp;Text&nbsp;</asp:ListItem>
                <asp:ListItem Value="HTML" style="padding-left: 10px;">&nbsp;HTML&nbsp;</asp:ListItem>
                <asp:ListItem Value="Mixed" style="padding-left: 10px;">&nbsp;Mixed&nbsp;</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            <span style="color: red;">*</span>비밀번호
        </td>
        <td style="padding-left: 10px">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"
                Style="display: inline-block" MaxLength="20" Width="150px" TextMode="Password" EnableViewState="False"></asp:TextBox>
            <span style="color: #aaaaaa;">(수정/삭제시에 필요)</span>
            <asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage=" 비밀번호를 기입해 주세요." ControlToValidate="txtPassword" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <%
        if (!Page.User.Identity.IsAuthenticated)
        {
    %>
    <tr>
        <td style="text-align: right;">
            <span style="color: red;">*</span>보안코드
        </td>
        <td style="padding-left: 10px">
            <asp:TextBox ID="txtImageText" runat="server" CssClass="form-control" Style="display: inline-block;" EnableViewState="False" MaxLength="20" Width="150px"></asp:TextBox>


            <asp:Image ID="imgSecurityText" runat="server" ImageUrl="../ImageText.aspx" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <span style="color: #aaaaaa;">(보안코드를 입력하세요)</span>
        </td>

    </tr>
    <%
        }
    %>
    <br />
    <tr>
        <td colspan="2" style="text-align: center;">
            <asp:Button ID="btnWrite" runat="server" Text="저장" CssClass="btn btn-primary" OnClick="btnWrite_Click" />
            <a href="BoardList.aspx" class="btn btn-default">리스트</a>
            <br />
            <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="False" ShowMessageBox="True" DisplayMode="BulletList" CssClass="BoardWriteFormTableLeftStyle" />
        </td>
    </tr>
</table>
