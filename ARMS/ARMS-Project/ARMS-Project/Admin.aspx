<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ARMS_Project.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <h3>Admin</h3>
        <div class="subForm">
            <h4>Create Lab</h4>
            <label>Lab Name:</label>
            <asp:TextBox ID="txtLabName" runat="server"></asp:TextBox>
            <asp:Button ID="btnCreateLab" runat="server" text="Create" CssClass="btn" />
        </div>
        <div class="subForm">
            <h4>Add User to Lab</h4>
            <label>TU AccessNet Username:</label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <label>Lab Id:</label>
            <asp:DropDownList ID="ddlLabs" runat="server"></asp:DropDownList>
            <asp:Button ID="btnAddUserToLab" runat="server" text="Add" CssClass="btn" />
        </div>
    </div>
</asp:Content>
