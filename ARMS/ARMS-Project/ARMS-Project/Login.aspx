<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="ARMS_Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="story" id="login">

        <h3>Login</h3>
        <asp:Label ID="LabelIP" runat="server" Visible="False" /><br /><br />
        <asp:Label ID="Label1" runat="server" Text="RMS Username"/><br /> 
        
        <asp:TextBox ID="TextBoxUID" runat="server"/><br /><br />
        <asp:Label ID="Label2" runat="server" Text="RMS Password"/><br />
        <asp:TextBox ID="TextBoxPWD" runat="server" TextMode="Password" />
        <br /><br />
        <asp:LinkButton runat="server" ID="btnForgotPassword" Text="Forgot Password?" onclick="btnForgotPassword_Click" ></asp:LinkButton>
        <br />
        <asp:Label runat="server" ID="lblForgotPassword" Text="Your password has been reset and been sent to the email address associated with the provided username." Visible="false"></asp:Label>
        <br /><br />  
        <asp:Button ID="ButtonLogin" runat="server" Text="Login"  
            onclick="ButtonLogin_Click" CssClass="btn btn-primary" /><br /><br />
            <asp:Label ID="lblNewPass1" runat="server" Text="Enter New Password" Visible="false" /><br />
            <asp:TextBox ID="txtNewPass1" runat="server" TextMode="Password" Width="100%" Visible="false"/><br />
            <asp:Label ID="lblNewPass2" runat="server" Text="Enter New Password Again" Visible="false" /><br />
            <asp:TextBox ID="txtNewPass2" runat="server" TextMode="Password" Width="100%" Visible="false"/><br />
    </div>
</asp:Content>