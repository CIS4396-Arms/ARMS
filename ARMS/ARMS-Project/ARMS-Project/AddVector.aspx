<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddVector.aspx.cs" Inherits="ARMS_Project.AddVector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div id="content">
        <h3>Add Vector</h3>
        <table class="data form">
            <tr>
                <td>MCS:</td>
                <td><asp:TextBox ID="txtMCS" runat="server" Text='<%# Eval("MCS") %>' /></td>
            </tr>
            <tr>
                <td>ARS:</td>
                <td><asp:TextBox ID="txtARS" runat="server" Text='<%# Eval("ARS") %>' /></td>
            </tr>
            <tr>
                <td>Promoter:</td>
                <td><asp:TextBox ID="txtPromter" runat="server" Text='<%# Eval("promoter") %>' /></td>
            </tr>
            <tr>
                <td>Size VP:</td>
                <td><asp:TextBox ID="txtSizeVP" runat="server" Text='<%# Eval("sizeVP") %>' /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>