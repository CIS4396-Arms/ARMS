<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddSecondaryAntibody.aspx.cs" Inherits="ARMS_Project.AddSecondaryAntibody" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <h3>Add Secondary Antibody</h3>
        <table class="data form">
            <tr>
                <td>Lab ID:</td>
                <td><asp:TextBox ID="txtLabID" runat="server" Text='<%# Eval("labID") %>' /></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtName" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Concentration:</td>
                <td><asp:TextBox ID="txtConcentration" runat="server" Text='<%# Eval("concentration") %>' /></td>
            </tr>
            <tr>
                <td>Excitation:</td>
                <td><asp:TextBox ID="txtExcitation" runat="server" Text='<%# Eval("excitation") %>' /></td>
            </tr>
            <tr>
                <td>Host Species:</td>
                <td><asp:TextBox ID="txtHostSpecies" runat="server" Text='<%# Eval("hostSpecies") %>' /></td>
            </tr>
            <tr>
                <td>Reactive Species:</td>
                <td><asp:TextBox ID="txtReactiveSpecies" runat="server" Text='<%# Eval("reactiveSpecies") %>' /></td>
            </tr>
            <tr>
                <td>Flourophore</td>
                <td><asp:TextBox ID="txtFlourophore" runat="server" Text='<%# Eval("flourophore") %>' /></td>
            </tr>
            <tr>
                <td>Working Dilution</td>
                <td><asp:TextBox ID="txtWorkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' /></td>
            </tr>
            <tr>
                <td>Lot Number</td>
                <td><asp:TextBox ID="txtLotNumber" runat="server" Text='<%# Eval("lotNumber") %>' /></td>
            </tr>
            <tr>
                <td>Antigen</td>
                <td><asp:TextBox ID="txtAntigen" runat="server" Text='<%# Eval("antigen") %>' /></td>
            </tr>
            <tr>
                <td>Applications</td>
                <td><asp:TextBox ID="txtApplications" runat="server" Text='<%# Eval("applications") %>' /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
