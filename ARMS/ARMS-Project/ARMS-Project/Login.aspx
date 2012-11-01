<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="ARMS_Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="story" id="login">
        <h3>Login</h3>
        <asp:Label ID="LabelIP" runat="server" /><br /><br />
        <asp:TextBox ID="TextBoxUID" runat="server"/><br /><br />
        <asp:TextBox ID="TextBoxPWD" runat="server" TextMode="Password"/><br /><br />
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" 
            onclick="ButtonLogin_Click"/><br />

    </div>
</asp:Content>