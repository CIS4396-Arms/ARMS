<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="ARMS_Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="story" id="login">

        <h3>Login</h3>
        <asp:Label ID="LabelIP" runat="server" Visible="False" /><br /><br />
        <asp:Label ID="Label1" runat="server" Text="AccessNet Username"/><br /> 
        
        <asp:TextBox ID="TextBoxUID" runat="server" Width="100%"/><br /><br />
        <asp:Label ID="Label2" runat="server" Text="TUSecure Password"/><br />
        <asp:TextBox ID="TextBoxPWD" runat="server" TextMode="Password" Width="100%"/><br /><br /><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonLogin" runat="server" Text="Login"  
            onclick="ButtonLogin_Click" Width="111px"/><br />

    </div>
</asp:Content>