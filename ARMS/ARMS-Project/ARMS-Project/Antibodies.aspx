<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Antibodies.aspx.cs" Inherits="ARMS_Project.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="popUp">
        <h3>Antibody Name<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <asp:FormView ID="fvAntibodies" runat="server" AutoGenerateColumns="False">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>Lab ID:</td>
                        <td><asp:TextBox ID="txtLabID" runat="server" Text='<%# Eval("labID") %>'/></td>
                    </tr>
                    <tr>
                        <td>Lot Number:</td>
                        <td><asp:TextBox ID="txtLotNumber" runat="server" Text='<%# Eval("lotNumber") %>' /></td>
                    </tr>
                    <tr>
                        <td>Enzyme Name:</td>
                        <td><asp:TextBox ID="txtEnzymeName" runat="server" Text='<%# Eval("enzymeName") %>' /></td>
                    </tr>
                    <tr>
                        <td>Solution:</td>
                        <td><asp:TextBox ID="txtSolution" runat="server" Text='<%# Eval("solution") %>' /></td>
                    </tr>
                    <tr>
                        <td>Clone:</td>
                        <td><asp:TextBox ID="txtClone" runat="server" Text='<%# Eval("clone") %>' /></td>
                    </tr>
                    <tr>
                        <td>Host Species:</td>
                        <td><asp:TextBox ID="txtHostSpecies" runat="server" Text='<%# Eval("hostSpecies") %>' /></td>
                    </tr>
                    <tr>
                        <td>Format:</td>
                        <td><asp:TextBox ID="txtFormat" runat="server" Text='<%# Eval("format") %>' /></td>
                    </tr>
                    <tr>
                        <td>Reactive Species:</td>
                        <td><asp:TextBox ID="txtReactiveSpecies" runat="server" Text='<%# Eval("reactiveSpecies") %>' /></td>
                    </tr>
                    <tr>
                        <td>Concetration:</td>
                        <td><asp:TextBox ID="txtConcentration" runat="server" Text='<%# Eval("concentration") %>' /></td>
                    </tr>
                    <tr>
                        <td>Working Dilution:</td>
                        <td><asp:TextBox ID="txtWorkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' /></td>
                    </tr>
                    <tr>
                        <td>Antigen:</td>
                        <td><asp:TextBox ID="txtAntigen" runat="server" Text='<%# Eval("antigen") %>' /></td>
                    </tr>
                    <tr>
                        <td>Phlourosphore:</td>
                        <td><asp:TextBox ID="txtPhlourosphore" runat="server" Text='<%# Eval("phlourosphore") %>' /></td>
                    </tr>
                    <tr>
                        <td>Protocol HREF:</td>
                        <td><asp:TextBox ID="txtProtcolHref" runat="server" Text='<%# Eval("protocolHREF") %>' /></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
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
        <asp:Label runat="server" ID="lblTest" Text="nothing happened yet"></asp:Label>
    </div>
</asp:Content>