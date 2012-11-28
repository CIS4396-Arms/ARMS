<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddVector.aspx.cs" Inherits="ARMS_Project.AddVector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div id="content">
        <h3>New Vector</h3>
        <div class="alert alert-error">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <p></p>
        </div>
        <table class="data form table table-striped table-bordered">
            <tr>
                <td>Lab:</td>
                <td>
                    <asp:DropDownList ID="ddlLabID" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Vector Name:</td>
                <td><asp:TextBox ID="txtvectorName" CssClass="quickValidate" data-validate="required" data-name="Name" runat="server" Text='<%# Eval("vectorName") %>' /></td>
            </tr>
            <tr>
                <td>Multiple Cloning Site:</td>
                <td><asp:TextBox ID="txtmultipleCloningSite" CssClass="quickValidate" data-validate="required" data-name="Multiple Cloning Site" runat="server" Text='<%# Eval("multipleCloningSite") %>' /></td>
            </tr>
            <tr>
                <td>Antibiotic Resistance</td>
                <td>
                    <asp:DropDownList ID="ddlantibioticResistance" runat="server" CssClass="chzn-select">
                        <asp:ListItem>Ampicillin</asp:ListItem>
                        <asp:ListItem>Carbenicillin</asp:ListItem>
                        <asp:ListItem>Chloramphenicol</asp:ListItem>
                        <asp:ListItem>Kanamycin</asp:ListItem>
                        <asp:ListItem>Rifampicin</asp:ListItem>
                        <asp:ListItem>Tetracycline HCl</asp:ListItem>
                        <asp:ListItem>Streptomycin</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtantibioticResistance" runat="server" placeholder="Other" CssClass="other hide" />
                </td>
            </tr>
            <tr>
                <td>Promoter:</td>
                <td><asp:TextBox ID="txtpromter" runat="server" Text='<%# Eval("promoter") %>' /></td>
            </tr>
            <tr>
                <td>Size:</td>
                <td><asp:TextBox ID="txtvectorSize" runat="server" Text='<%# Eval("vectorSize") %>' /></td>
            </tr>
            <tr>
                <td>Notes:</td>
                <td><asp:TextBox ID="txtnotes" runat="server" TextMode="multiline" Text='<%# Eval("notes") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td>Specs</td>
                <td>

                    <asp:FileUpload id="SpecUpload"                 
                       runat="server">
                   </asp:FileUpload>

                   <br /><br />

                   <asp:Button id="btnSpecUpload" 
                       Text="Upload file"
                       OnClick="SpecUpload_Click"
                       runat="server"
                       CssClass="btn btn-primary" />
                   
                   <asp:Label ID="lblSpecUpload" runat="server"></asp:Label>

                   <asp:HiddenField ID="specSheetHREF" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>
        <script type="text/javascript">
            $('.form').quickValidate();
        </script>
    </div>
</asp:Content>