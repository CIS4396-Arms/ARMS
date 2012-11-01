<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="True" CodeBehind="LoginFailure.aspx.cs" Inherits="ARMS_Project.LoginFailure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="story" id="login">
        <h3>Login Failure</h3>
        <p>The username or password entered is incorrect.</p>
        <br />

        <a href="Login.aspx">Click Here to Login</a>
    </div>
</asp:Content>