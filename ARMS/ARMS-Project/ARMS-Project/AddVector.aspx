<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddVector.aspx.cs" Inherits="ARMS_Project.AddVector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div id="content">
        <h3>New Vector</h3>
        <table class="data form">
            <tr>
                <td>Lab ID:</td>
                <td><asp:TextBox ID="txtlabID" runat="server" Text='<%# Eval("labID") %>' /></td>
            </tr>
            <tr>
                <td>Vector Name:</td>
                <td><asp:TextBox ID="txtvectorName" runat="server" Text='<%# Eval("vectorName") %>' /></td>
            </tr>
            <tr>
                <td>Multiple Cloning Site:</td>
                <td><asp:TextBox ID="txtmultipleCloningSite" runat="server" Text='<%# Eval("multipleCloningSite") %>' /></td>
            </tr>
            <tr>
                <td>Antibiotic Resistance</td>
                <td><asp:TextBox ID="txtantibioticResistance" runat="server" Text='<%# Eval("antibioticResistance") %>' /></td>
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
                       runat="server">
                   </asp:Button>
                   
                   <asp:Label ID="lblSpecUpload" runat="server"></asp:Label>

                   <asp:HiddenField ID="specSheetHREF" runat="server" />
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