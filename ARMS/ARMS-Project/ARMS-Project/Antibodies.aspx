<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Antibodies.aspx.cs" Inherits="ARMS_Project.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="story" id="view">
        <h3>Antibodies</h3>
        <asp:GridView ID="gvAntibodies" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="hostSpecies" HeaderText="Host Species" />
                <asp:BoundField DataField="lotID" HeaderText="Lot ID" />
                <asp:BoundField DataField="format" HeaderText="Clone" />
                <asp:TemplateField HeaderText="Actions">
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>