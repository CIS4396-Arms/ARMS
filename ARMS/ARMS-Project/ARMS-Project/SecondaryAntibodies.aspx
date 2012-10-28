<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="SecondaryAntibodies.aspx.cs" Inherits="ARMS_Project.SecondaryAntibodies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="popUp">
        <h3>Secondary Antibody Name<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <asp:FormView ID="fvSecondaryAntibodies" runat="server" AutoGenerateColumns="False">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>Lab ID:</td>
                        <td><asp:TextBox ID="txtLabID" runat="server" Text='<%# Eval("labID") %>'/></td>
                    </tr>
                    
                </table>
            </ItemTemplate>
        </asp:FormView>
    </div>
    
    <div id="content">
        <h3>Primary Antibodies</h3>
        <asp:GridView ID="gvSecondaryAntibodies" runat="server" AutoGenerateColumns="False" CssClass="data">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="labID" HeaderText="Lab ID" />
                <asp:BoundField DataField="concentration" HeaderText="Concentration" />
                <asp:BoundField DataField="color" HeaderText="Color" />
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
