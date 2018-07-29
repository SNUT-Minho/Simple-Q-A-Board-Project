<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardList.aspx.cs" Inherits="DotNetNote.DotNetNote.BoardList" %>

<%@ Register Src="~/DotNetNote/Controls/AdvancedPagingSingleBootstrap.ascx" TagPrefix="uc1" TagName="AdvancedPagingSingleBootstrap" %>
<%@ Register Src="~/DotNetNote/Controls/BoardSearchFormSingleControl.ascx" TagPrefix="uc1" TagName="BoardSearchFormSingleControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>게시판</h2>
    <span style="color: red;"> 글 목록 </span>
    <hr />
    <table style="width: 750px; margin-left: auto; margin-right: auto;">
        <tr>
            <td>
                <style>
                    table th {
                        text-align: center;
                    }
                </style>
                <div style="font-style:italic; text-align:right; font-size: 10px;">
                       Total Record: <asp:Literal ID="lblTotalRecord" runat="server"></asp:Literal>
                </div>
                <asp:GridView ID="ctlBoardList"
                    runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                    CssClass="table table-bordered table-hover table-condensed table-striped table-responsive">
                    <Columns>
                        <asp:TemplateField HeaderText="번호" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <!--The DataItemIndex property is a zero based index and hence we need to increment it by one so that we get values starting from one.-->
                                <%# intTotalCount - ((Container.DataItemIndex)) - (intPage * 10) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="제목" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="350px">
                            <ItemTemplate>
                                <!--스텝 들여쓰기-->
                                <%# Dul.BoardLibrary.FuncStep(Eval("RefOrder")) %>
                                <!-- Id값을 읽어와 해당 BoardView 페이지로 이동하는 Link-->
                                <asp:HyperLink ID="lnkTitle" runat="server" NavigateUrl='<%# "BoardView.aspx?Id=" + Eval("Id")+ "&ANum="+(intTotalCount - ((Container.DataItemIndex)) - (intPage * 10)) %>'>
                                   <%# Dul.HtmlUtility.EncodeWithTabAndSpace(Dul.StringLibrary.CutStringUnicode(Eval("Title").ToString(), 25)) %>
                                </asp:HyperLink>
                                <%# Dul.BoardLibrary.ShowCommentCount(Eval("CommentCount")) %>
                                <%# Dul.BoardLibrary.FuncNew(Eval("PostDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="파일" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkFileName" runat="server" NavigateUrl='<%# "BoardDown.aspx?Id=" + Eval("Id").ToString() %>' onclick="return confirm('[경 고] \n\r신뢰할 수 있는 파일만 다운로드하세요. \n\r정말 다운로드 하시겠습니까?');">
                                    <%# Dul.BoardLibrary.DownLoadFile(Eval("FileName").ToString()) %>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="작성자" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                              <%# Dul.StringLibrary.CutStringUnicode(Eval("Name").ToString(), 6) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="작성일" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                              <%# Dul.BoardLibrary.FuncShowTime(Eval("PostDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ReadCount" HeaderText="조회수" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px" />
                    </Columns>

                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 16px; text-align:center;" >
                <uc1:AdvancedPagingSingleBootstrap runat="server" ID="AdvancedPagingSingleBootstrap" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <a href="BoardWrite.aspx" class="btn btn-default">글쓰기</a>
            </td>
        </tr>
    </table>
    <uc1:BoardSearchFormSingleControl runat="server" id="BoardSearchFormSingleControl" />
</asp:Content>
