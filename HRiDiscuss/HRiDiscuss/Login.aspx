<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebShare.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Layout">
        <asp:Panel ID="PnlCreate" runat="server" DefaultButton="BtnCreate">
            <asp:Label ID="LblCreate" runat="server" Text="Create An Account"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TbCreateUser" runat="server" placeholder="Username" MaxLength="15"></asp:TextBox><br />
            <br />
            <asp:TextBox ID="TbCreatePass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="LblCreateMsg" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="BtnCreate" runat="server" Text="Create!" OnClick="BtnCreate_Click" TabIndex="2" />
        </asp:Panel>
        <br />
        <asp:Panel ID="PnlLogin" runat="server" DefaultButton="BtnLogin"> 
            <asp:Label ID="LblUser" runat="server" Text="Log In"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TbLoginUser" runat="server" placeholder="Username"></asp:TextBox><br />
            <br />
            <asp:TextBox ID="TbLoginPass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="LblLoginMsg" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="BtnLogin" runat="server" Text="Login!" OnClick="BtnLogin_Click" CssClass="Button" TabIndex="1" />
        </asp:Panel>
    </div>
</asp:Content>
  