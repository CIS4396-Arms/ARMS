<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddConstruct.aspx.cs" Inherits="ARMS_Project.AddConstruct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <h3>Add DNA Construct</h3>
        <table class="data form">
            <tr>
                <td>Lab Id:</td>
                <td><asp:TextBox ID="txtlabID" runat="server" Text='<%# Eval("labId") %>' /></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtname" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Insert:</td>
                <td><asp:TextBox ID="txtinsert" runat="server" Text='<%# Eval("insert") %>' /></td>
            </tr>
            <tr>
                <td>Vector:</td>
                <td><asp:TextBox ID="txtvector" runat="server" Text='<%# Eval("vector") %>' /></td>
            </tr>
            <tr>
                <td>Species:</td>
                <td><asp:TextBox ID="txtSpecies" runat="server" Text='<%# Eval("species") %>' /></td>
            </tr>
            <tr>
                <td>Antibiotic Resistance:</td>
                <td><asp:TextBox ID="txtantibioticResistance" runat="server" Text='<%# Eval("antibioticResistance") %>' /></td>
            </tr>
            <tr>
                <td>Digest Site 5':</td>
                <td><asp:TextBox ID="txtdigestSite5" runat="server" Text='<%# Eval("digestSite5") %>' /></td>
            </tr>
            <tr>
                <td>Digest Site 3':</td>
                <td><asp:TextBox ID="txtdigestSite3" runat="server" Text='<%# Eval("digestSite3") %>' /></td>
            </tr>
            <tr>
                <td>Notes:</td>
                <td><asp:TextBox ID="txtnotes" runat="server" TextMode="MultiLine" Text='<%# Eval("notes") %>' /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
