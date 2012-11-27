<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddAntibody.aspx.cs" Inherits="ARMS_Project.AddAntibody" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    
    <div id="content">
        <h3>Add Antibody</h3>
        <table class="data form table table-striped table-bordered">
            <tr>
                <td>Lab:</td>
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
                <td>
                    <asp:DropDownList ID="ddlHostSpecies" runat="server" CssClass="chzn-select">
                        <asp:ListItem>Bovine</asp:ListItem>
                        <asp:ListItem>Cat</asp:ListItem>
                        <asp:ListItem>Chicken</asp:ListItem>
                        <asp:ListItem>Dog</asp:ListItem>
                        <asp:ListItem>Goat</asp:ListItem>
                        <asp:ListItem>Guinea Pig</asp:ListItem>
                        <asp:ListItem>Hamster</asp:ListItem>
                        <asp:ListItem>Horse</asp:ListItem>
                        <asp:ListItem>Human</asp:ListItem>
                        <asp:ListItem>Mouse</asp:ListItem>
                        <asp:ListItem>Mouse IgG1</asp:ListItem>
                        <asp:ListItem>Mouse IgG2a</asp:ListItem>
                        <asp:ListItem>Mouse IgG2b</asp:ListItem>
                        <asp:ListItem>Mouse IgG2c</asp:ListItem>
                        <asp:ListItem>Mouse IgG3</asp:ListItem>
                        <asp:ListItem>Rabbit</asp:ListItem>
                        <asp:ListItem>Rat</asp:ListItem>
                        <asp:ListItem>Sheep</asp:ListItem>
                        <asp:ListItem>Swine</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Reactive Species:</td>
                <td>
                    <asp:ListBox ID="ddlReactiveSpecies" runat="server"  SelectionMode="Multiple" CssClass="chzn-select">
                        <asp:ListItem>Bovine</asp:ListItem>
                        <asp:ListItem>Cat</asp:ListItem>
                        <asp:ListItem>Chicken</asp:ListItem>
                        <asp:ListItem>Dog</asp:ListItem>
                        <asp:ListItem>Goat</asp:ListItem>
                        <asp:ListItem>Guinea Pig</asp:ListItem>
                        <asp:ListItem>Hamster</asp:ListItem>
                        <asp:ListItem>Horse</asp:ListItem>
                        <asp:ListItem>Human</asp:ListItem>
                        <asp:ListItem>Mouse</asp:ListItem>
                        <asp:ListItem>Mouse IgG1</asp:ListItem>
                        <asp:ListItem>Mouse IgG2a</asp:ListItem>
                        <asp:ListItem>Mouse IgG2b</asp:ListItem>
                        <asp:ListItem>Mouse IgG2c</asp:ListItem>
                        <asp:ListItem>Mouse IgG3</asp:ListItem>
                        <asp:ListItem>Rabbit</asp:ListItem>
                        <asp:ListItem>Rat</asp:ListItem>
                        <asp:ListItem>Sheep</asp:ListItem>
                        <asp:ListItem>Swine</asp:ListItem>
                    </asp:ListBox>
                </td>
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
                       runat="server" 
                       CssClass="btn btn-primary" />
                   
                   
                   <asp:Label ID="lblProtcolUpload" runat="server"></asp:Label>

                   <asp:HiddenField ID="protocolHREF" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
