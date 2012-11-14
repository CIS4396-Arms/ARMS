<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="True" CodeBehind="Antibodies.aspx.cs" Inherits="ARMS_Project.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="popUp">
        <h3>Antibody Name<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <div class="controls">
            <a href="#" class="edit icon-button"><i class="icon-edit"></i><span>Edit</span></a>
            <a runat="server" id="btnSave" OnClick="btnSave_click" href="#" class="save icon-button hide"><i class="icon-save"></i><span>Save</span></a>
        </div>
        <table class="data form">
            <tr>
                <td>Lab ID:</td>
                <td><asp:TextBox ID="txtlabID" runat="server" Text='<%# Eval("labID") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Lot Number:</td>
                <td><asp:TextBox ID="txtlotNumber" runat="server" Text='<%# Eval("lotNumber") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Enzyme Name:</td>
                <td><asp:TextBox ID="txtenzymeName" runat="server" Text='<%# Eval("enzymeName") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Solution:</td>
                <td><asp:TextBox ID="txtsolution" runat="server" Text='<%# Eval("solution") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Clone:</td>
                <td><asp:TextBox ID="txtclone" runat="server" Text='<%# Eval("clone") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Host Species:</td>
                <td><asp:TextBox ID="txthostSpecies" runat="server" Text='<%# Eval("hostSpecies") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Format:</td>
                <td><asp:TextBox ID="txtformat" runat="server" Text='<%# Eval("format") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Reactive Species:</td>
                <td><asp:TextBox ID="txtreactiveSpecies" runat="server" Text='<%# Eval("reactiveSpecies") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Concetration:</td>
                <td><asp:TextBox ID="txtconcentration" runat="server" Text='<%# Eval("concentration") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Working Dilution:</td>
                <td><asp:TextBox ID="txtworkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Antigen:</td>
                <td><asp:TextBox ID="txtantigen" runat="server" Text='<%# Eval("antigen") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Phlourosphore:</td>
                <td><asp:TextBox ID="txtphlourosphore" runat="server" Text='<%# Eval("phlourosphore") %>' Enabled='false' /></td>
            </tr>
            <tr>
                <td>Protocol HREF:</td>
                <td><asp:TextBox ID="txtprotcolHref" runat="server" Text='<%# Eval("protocolHREF") %>' Enabled='false' /></td>
            </tr>
           
        </table>
    </div>
    <div id="content">
        <h3>Primary Antibodies</h3>
        <asp:GridView ID="gvAntibodies" runat="server" AutoGenerateColumns="False" CssClass="data">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="enzymeName" HeaderText="Enzyme Name" />
                <asp:BoundField DataField="hostSpecies" HeaderText="Host Species" />
                <asp:BoundField DataField="lotNumber" HeaderText="Lot Number" />
                <asp:BoundField DataField="format" HeaderText="Clone" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" CssClass="view" Text="<i class='icon-search'></i>" NavigateUrl='<%# Eval("id") %>'/>
                        <asp:HyperLink ID="deleteButton" runat="server" Text="<i class='icon-trash'></i>" NavigateUrl="#" OnClick="Delete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>