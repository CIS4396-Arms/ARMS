<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ARMS_Project.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content" class="validate">
        <h3>Admin</h3>

        <div class="alert alert-error">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <p>Warning!</p>
        </div>
        <fieldset id="createLab" class="form-horizontal">
            <legend>Create Lab</legend>
            <label>Lab Name:</label>
            <asp:TextBox ID="txtLabName" runat="server" CssClass="quickValidate" data-validate="required" data-name="Lab Name" ontextchanged="txtLabName_TextChanged"></asp:TextBox>
            <asp:Button ID="btnCreateLab" runat="server" text="Create" CssClass="btn" OnClick="btnCreateLab_Click" />
        </fieldset>
        <fieldset id="addUser" class="form-horizontal">
            <legend>Add User to Lab</legend>
            <label>TU AccessNet Username:</label>
            <asp:TextBox ID="txtUserName" CssClass="quickValidate" data-validate="required" data-name="AccessNet Name" runat="server"></asp:TextBox>
            <label>Lab Name:</label>
            <asp:DropDownList ID="ddlLabs" runat="server"></asp:DropDownList>
            <asp:Button ID="btnAddUserToLab" runat="server" text="Add" CssClass="btn" />
        </fieldset>
        <script type="text/javascript">
            $('#createLab, #addUser').quickValidate();
        </script>
    </div>
</asp:Content>
