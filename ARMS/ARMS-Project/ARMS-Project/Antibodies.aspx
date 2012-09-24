<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Antibodies.aspx.cs" Inherits="ARMS_Project.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="story" id="view">
        <h3>Antibodies</h3>
        <asp:Button runat="server" ID="dbConnTestBTN" Text="Connect" onclick="dbConnTestBTN_Click" />
        <asp:Label runat="server" ID="dbConnTestLBL" Text=""></asp:Label>
    </div>
</asp:Content>
