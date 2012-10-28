<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Vectors.aspx.cs" Inherits="ARMS_Project.Vectors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <h3>Vectors</h3>
        <asp:GridView ID="gvVectors" runat="server" AutoGenerateColumns="False" CssClass="data">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="MCS" HeaderText="MCS" />
                <asp:BoundField DataField="ARS" HeaderText="ARS" />
                <asp:BoundField DataField="promoter" HeaderText="Promoter" />
                <asp:BoundField DataField="sizeVP" HeaderText="Size VP" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <asp:HyperLink ID="viewButton" runat="server" CssClass="view" Text="<i class='icon-search'></i>" NavigateUrl='<%# Eval("id") %>'/>
                        <asp:HyperLink ID="deleteButton" runat="server" Text="<i class='icon-trash'></i>" NavigateUrl="#" OnClick="Delete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>