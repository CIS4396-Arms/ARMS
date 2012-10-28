<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddAntibody.aspx.cs" Inherits="ARMS_Project.AddAntibody" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    
    <div id="content">
        <h3>Add Antibody</h3>
        <table class="data form">
            <tr>
                <td>Lab ID:</td>
                <td><asp:TextBox ID="txtLabID" runat="server" Text='<%# Eval("labID") %>'/></td>
            </tr>
            <tr>
                <td>Lot Number:</td>
                <td><asp:TextBox ID="txtLotNumber" runat="server" Text='<%# Eval("lotNumber") %>' /></td>
            </tr>
            <tr>
                <td>Enzyme Name:</td>
                <td><asp:TextBox ID="txtEnzymeName" runat="server" Text='<%# Eval("enzymeName") %>' /></td>
            </tr>
            <tr>
                <td>Solution:</td>
                <td><asp:TextBox ID="txtSolution" runat="server" Text='<%# Eval("solution") %>' /></td>
            </tr>
            <tr>
                <td>Clone:</td>
                <td><asp:TextBox ID="txtClone" runat="server" Text='<%# Eval("clone") %>' /></td>
            </tr>
            <tr>
                <td>Host Species:</td>
                <td><asp:TextBox ID="txtHostSpecies" runat="server" Text='<%# Eval("hostSpecies") %>' /></td>
            </tr>
            <tr>
                <td>Format:</td>
                <td><asp:TextBox ID="txtFormat" runat="server" Text='<%# Eval("format") %>' /></td>
            </tr>
            <tr>
                <td>Reactive Species:</td>
                <td><asp:TextBox ID="txtReactiveSpecies" runat="server" Text='<%# Eval("reactiveSpecies") %>' /></td>
            </tr>
            <tr>
                <td>Concetration:</td>
                <td><asp:TextBox ID="txtConcentration" runat="server" Text='<%# Eval("concentration") %>' /></td>
            </tr>
            <tr>
                <td>Working Dilution:</td>
                <td><asp:TextBox ID="txtWorkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' /></td>
            </tr>
            <tr>
                <td>Antigen:</td>
                <td><asp:TextBox ID="txtAntigen" runat="server" Text='<%# Eval("antigen") %>' /></td>
            </tr>
            <tr>
                <td>Phlourosphore:</td>
                <td><asp:TextBox ID="txtPhlourosphore" runat="server" Text='<%# Eval("phlourosphore") %>' /></td>
            </tr>
            <tr>
                <td>Protocol HREF:</td>
                <td><asp:TextBox ID="txtProtcolHref" runat="server" Text='<%# Eval("protocolHREF") %>' /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
