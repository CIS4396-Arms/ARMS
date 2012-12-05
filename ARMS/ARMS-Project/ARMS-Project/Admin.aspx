<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ARMS_Project.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content" class="validate">
        <h3>Admin</h3>
        <div class="alert alert-error">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <p></p>
        </div>

        <fieldset id="createLab" class="form-horizontal">
            <legend>Create Lab</legend>
            <label>Lab Name:</label>
            <asp:TextBox ID="txtLabName" runat="server" CssClass="quickValidate" data-validate="required" data-name="Lab Name" ontextchanged="txtLabName_TextChanged"></asp:TextBox>
            <asp:Button ID="btnCreateLab" runat="server" text="Create" CssClass="btn" OnClick="btnCreateLab_Click" />
        </fieldset>
        <fieldset id="addUser" class="form-horizontal">
            <legend>Add User to Lab</legend>
            <label>Username:</label>
            <asp:TextBox ID="txtUserName" CssClass="quickValidate" data-validate="required" data-name="Username" runat="server"></asp:TextBox>
            <br /><br />
             <label>Full Name:</label>
            <asp:TextBox ID="txtFullName" CssClass="quickValidate" data-validate="required" data-name="Full Name" runat="server"></asp:TextBox>
            <br /><br />
            <label>Email Address:</label>
            <asp:TextBox ID="txtEmail" CssClass="quickValidate" data-validate="required" data-name="Email Address" runat="server"></asp:TextBox>
            <br /><br />
            <label>Lab Name:</label>
            <asp:DropDownList ID="ddlLabs" runat="server"></asp:DropDownList>
            <asp:Button ID="btnAddUserToLab" runat="server" text="Add" CssClass="btn" 
                onclick="btnAddUserToLab_Click" />
        </fieldset>
        <script type="text/javascript">
            $('#createLab, #addUser').quickValidate();
        </script>
        <%-- 
        <asp:ObjectDataSource
            id="labUserDataSource"
            runat="server"
            selectmethod="GetUsers"
            typename="ARMS_Project.UserLogic"
        />

        <asp:GridView ID="gvLabUsers" runat="server" AutoGenerateColumns="False" CssClass="data table" DataSourceID="labUserDataSource">
            <Columns>
                <asp:BoundField DataField="labID" HeaderText="Lab ID" />
                <asp:BoundField DataField="fullName" HeaderText="Name" />
                <asp:BoundField DataField="AccessnetID" HeaderText="Username" />
            </Columns>
        </asp:GridView>
        --%>
    </div>
</asp:Content>
