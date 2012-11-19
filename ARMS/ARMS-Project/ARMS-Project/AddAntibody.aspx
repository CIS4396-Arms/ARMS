<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddAntibody.aspx.cs" Inherits="ARMS_Project.AddAntibody" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    
    <div id="content">
        <h3>Add Antibody</h3>
        <table class="data form">
            <tr>
                <td>Lab ID:</td>
                <td>
                    <asp:DropDownList ID="ddlLabID" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Lot Number:</td>
                <td><asp:TextBox ID="txtLotNumber" runat="server" Text='<%# Eval("lotNumber") %>' /></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtName" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Type:</td>
                <td>
                    <asp:RadioButton id="rbMono" CssClass="radio" Text="Monoclonal" Checked="True" GroupName="cloneType" runat="server" />
                    <asp:RadioButton id="rbPoly" CssClass="radio" Text="Polyclonal" GroupName="cloneType" runat="server" />
                </td>
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
                <td>Reactive Species:</td>
                <td><asp:TextBox ID="txtReactiveSpecies" runat="server" Text='<%# Eval("reactiveSpecies") %>' /></td>
            </tr>
            <tr>
                <td>Concentration:</td>
                <td><asp:TextBox ID="txtConcentration" runat="server" Text='<%# Eval("concentration") %>' /></td>
            </tr>
            <tr>
                <td>Working Dilution:</td>
                <td><asp:TextBox ID="txtWorkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' /></td>
            </tr>
            <tr>
                <td>Isotype:</td>
                <td><asp:TextBox ID="txtIsotype" runat="server" Text='<%# Eval("isotype") %>' /></td>
            </tr>
            <tr>
                <td>Antigen:</td>
                <td><asp:TextBox ID="txtAntigen" runat="server" Text='<%# Eval("antigen") %>' /></td>
            </tr>
            <tr>
                <td>Fluorophore:</td>
                <td><asp:TextBox ID="txtFluorophore" runat="server" Text='<%# Eval("fluorophore") %>' /></td>
            </tr>
            <tr>
                <td>Application</td>
                <td><asp:TextBox ID="txtApplication" runat="server" Text='<%# Eval("application") %>' /></td>
            </tr>
            <tr>
                <td>Protocol</td>
                <td>
                    
                    <ul id="protocol">
                    
                    </ul>

                    <asp:FileUpload id="ProtcolUpload"                 
                       runat="server">
                   </asp:FileUpload>

                   <br /><br />

                   <asp:Button id="btnProtocolUpload" 
                       Text="Upload file"
                       OnClick="ProtcolUpload_Click"
                       runat="server">
                   </asp:Button>
                   
                   <asp:Label ID="lblProtcolUpload" runat="server"></asp:Label>

                   <asp:HiddenField ID="protocolHREF" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
