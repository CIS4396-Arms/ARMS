<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddConstruct.aspx.cs" Inherits="ARMS_Project.AddConstruct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <h3>Add DNA Construct</h3>
        <table class="data form">
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtName" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Source:</td>
                <td><asp:TextBox ID="txtSource" runat="server" Text='<%# Eval("source") %>' /></td>
            </tr>
            <tr>
                <td>Digest Site 5:</td>
                <td><asp:TextBox ID="txtDigestSite5" runat="server" Text='<%# Eval("digestSite5") %>' /></td>
            </tr>
            <tr>
                <td>Digest Site 3:</td>
                <td><asp:TextBox ID="txtDigestSite3" runat="server" Text='<%# Eval("digestSite3") %>' /></td>
            </tr>
            <tr>
                <td>Buffer:</td>
                <td><asp:TextBox ID="txtBuffer" runat="server" Text='<%# Eval("buffer") %>' /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
