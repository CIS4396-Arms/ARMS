<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Constructs.aspx.cs" Inherits="ARMS_Project.Constructs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    <div id="popUp">
        <h3>DNA Construct Name<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <asp:FormView ID="fvConstructs" runat="server" AutoGenerateColumns="False">
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
        <h3>DNA Constructs</h3>
        <asp:GridView ID="gvConstructs" runat="server" AutoGenerateColumns="False" CssClass="data">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="source" HeaderText="Source" />
                <asp:BoundField DataField="buffer" HeaderText="Buffer" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="view" Text="<i class='icon-search'></i>" NavigateUrl='<%# Eval("id") %>'/>
                        <asp:HyperLink ID="deleteButton" runat="server" Text="<i class='icon-trash'></i>" NavigateUrl="#" OnClick="Delete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
