<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModerationPage.aspx.cs" Inherits="HRiDiscuss.ModerationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Layout">
    <asp:GridView ID="GvArticles" runat="server" AutoGenerateColumns="False" DataKeyNames="ArticleID" DataSourceID="DsArticles" Width="100%">
        <Columns>
            <asp:BoundField DataField="ArticleID" HeaderText="ArticleID" InsertVisible="False" ReadOnly="True" SortExpression="ArticleID" />
            <asp:BoundField DataField="ArticleTitle" HeaderText="ArticleTitle" SortExpression="ArticleTitle" />
            <asp:BoundField DataField="ArticleText" HeaderText="ArticleText" SortExpression="ArticleText" />
            <asp:BoundField DataField="ArticleAuthor" HeaderText="ArticleAuthor" SortExpression="ArticleAuthor" />
            <asp:BoundField DataField="ArticlePostDate" HeaderText="ArticlePostDate" SortExpression="ArticlePostDate" />
            <asp:BoundField DataField="IsModerated" HeaderText="IsModerated" SortExpression="IsModerated" />
            <asp:TemplateField>
                <HeaderTemplate>Image</HeaderTemplate>
                <ItemTemplate>
                    <img src='data:image/jpg;base64,<%# Eval("ArticleImage") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("ArticleImage")) : string.Empty %>' alt="image" height="100" width="200" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns> 
    </asp:GridView>
        </div>
    <asp:SqlDataSource ID="DsArticles" runat="server" ConnectionString="<%$ ConnectionStrings:DsAccounts %>" SelectCommand="SELECT * FROM [Articles]"></asp:SqlDataSource>
</asp:Content>
 