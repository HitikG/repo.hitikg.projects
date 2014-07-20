<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="HRiDiscuss.AddArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Layout">
        <asp:Label runat="server">Add An Article</asp:Label><br />
        <br />
        <asp:TextBox ID="TbArticleTitle" runat="server" placeholder="Article Title"></asp:TextBox><br />
        <br />
        <asp:TextBox ID="TbArticleText" runat="server" placeholder="Article Body" Height="93px" TextMode="MultiLine" Width="235px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:FileUpload runat="server" ID="UploadImages" AllowMultiple="false" /> 
        <asp:Button ID="BtnAddArticle" runat="server" Text="Add!" OnClick="BtnAddArticle_Click" />
        <asp:Label ID="LblError" runat="server" />
        
    </div> 
</asp:Content>
