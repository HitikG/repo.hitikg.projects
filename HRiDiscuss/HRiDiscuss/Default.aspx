<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HRiDiscuss.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Layout" style="overflow-x:hidden">
        <asp:SqlDataSource ID="DsArticles" runat="server" ConnectionString="<%$ ConnectionStrings:DsAccounts %>" SelectCommand="SELECT * FROM [Articles]"></asp:SqlDataSource>
        <asp:Panel ID="PnlPost1" runat="server" Width="100%" style="overflow-x:hidden">
            <asp:Label ID="LblPostTitle1" runat="server" Text="PLACEHOLDER MAIN TITLE"></asp:Label><br /><br />
            <asp:Label ID="LblPostInfo1" runat="server" Text="PLACEHOLDER AUTHOR DATE"></asp:Label><br /><br />
            <asp:Image ID="PostImage1" runat="server" src='data:image/jpg;base64,<%# Eval("ArticleImage") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("ArticleImage")) : string.Empty %>' alt="image" height="100" width="200" /><br /><br />
            <asp:Label ID="LblPostText1" runat="server" Text="PLACEHOLDER MAIN TEXT"></asp:Label><br /><br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </asp:Panel><br /><br /><br />
        <asp:Panel ID="PnlPost2" runat="server" Width="100%" style="overflow-x:hidden">
            <asp:Label ID="LblPostTitle2" runat="server" Text="PLACEHOLDER MAIN TITLE"></asp:Label><br /><br />
            <asp:Label ID="LblPostInfo2" runat="server" Text="PLACEHOLDER AUTHOR DATE"></asp:Label><br /><br />
            <asp:Image ID="PostImage2" runat="server" /><br /><br />
            <asp:Label ID="LblPostText2" runat="server" Text="PLACEHOLDER MAIN TEXT"></asp:Label><br /><br />
        </asp:Panel><br /><br /><br />
        <asp:Panel ID="PnlPost3" runat="server" Width="100%" style="overflow-x:hidden">
            <asp:Label ID="LblPostTitle3" runat="server" Text="PLACEHOLDER MAIN TITLE"></asp:Label><br /><br />
            <asp:Label ID="LblPostInfo3" runat="server" Text="PLACEHOLDER AUTHOR DATE"></asp:Label><br /><br />
            <asp:Image ID="PostImage3" runat="server" /><br /><br />
            <asp:Label ID="LblPostText3" runat="server" Text="PLACEHOLDER MAIN TEXT"></asp:Label><br /><br />
        </asp:Panel><br /><br /><br />
        <asp:Panel ID="PnlPost4" runat="server" Width="100%" style="overflow-x:hidden">
            <asp:Label ID="LblPostTitle4" runat="server" Text="PLACEHOLDER MAIN TITLE"></asp:Label><br /><br /> 
            <asp:Label ID="LblPostInfo4" runat="server" Text="PLACEHOLDER AUTHOR DATE"></asp:Label><br /><br />
            <asp:Image ID="PostImage4" runat="server" /><br /><br />
            <asp:Label ID="LblPostText4" runat="server" Text="PLACEHOLDER MAIN TEXT"></asp:Label><br /><br />
        </asp:Panel><br /><br /><br />
        <asp:Panel ID="PnlPost5" runat="server" Width="100%" style="overflow-x:hidden">
            <asp:Label ID="LblPostTitle5" runat="server" Text="PLACEHOLDER MAIN TITLE"></asp:Label><br /><br />     
            <asp:Label ID="LblPostInfo5" runat="server" Text="PLACEHOLDER AUTHOR DATE"></asp:Label><br /><br />
            <asp:Image ID="PostImage5" runat="server" /><br /><br />
            <asp:Label ID="LblPostText5" runat="server" Text="PLACEHOLDER MAIN TEXT"></asp:Label><br /><br />
        </asp:Panel>
    </div>

</asp:Content>

