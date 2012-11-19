<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="SecondaryAntibodies.aspx.cs" Inherits="ARMS_Project.SecondaryAntibodies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="popUp">
        <h3>Secondary Antibody<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <div class="controls">
            <a href="#" class="edit icon-button"><i class="icon-edit"></i><span>Edit</span></a>
            <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_click" class="save icon-button hide" Text="<i class='icon-save'></i><span>Save</span>"></asp:LinkButton>
        </div>
        <table class="data form">
            <tr>
                <td>Lab ID:</td>
                <td><asp:TextBox ID="txtlabID" runat="server" Text='<%# Eval("labID") %>' /></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtantibodyName" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Concentration:</td>
                <td><asp:TextBox ID="txtconcentration" runat="server" Text='<%# Eval("concentration") %>' /></td>
            </tr>
            <tr>
                <td>Excitation:</td>
                <td><asp:TextBox ID="txtexcitation" runat="server" Text='<%# Eval("excitation") %>' /></td>
            </tr>
            <tr>
                <td>Host Species:</td>
                <td><asp:TextBox ID="txthostSpecies" runat="server" Text='<%# Eval("hostSpecies") %>' /></td>
            </tr>
            <tr>
                <td>Reactive Species:</td>
                <td><asp:TextBox ID="txtreactiveSpecies" runat="server" Text='<%# Eval("reactiveSpecies") %>' /></td>
            </tr>
            <tr>
                <td>Flourophore</td>
                <td><asp:TextBox ID="txtflourophore" runat="server" Text='<%# Eval("flourophore") %>' /></td>
            </tr>
            <tr>
                <td>Working Dilution</td>
                <td><asp:TextBox ID="txtworkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' /></td>
            </tr>
            <tr>
                <td>Lot Number</td>
                <td><asp:TextBox ID="txtlotNumber" runat="server" Text='<%# Eval("lotNumber") %>' /></td>
            </tr>
            <tr>
                <td>Antigen</td>
                <td><asp:TextBox ID="txtantigen" runat="server" Text='<%# Eval("antigen") %>' /></td>
            </tr>
            <tr>
                <td>Applications</td>
                <td><asp:TextBox ID="txtapplications" runat="server" Text='<%# Eval("applications") %>' /></td>
            </tr>
        </table>
    </div>
    
    <div id="content">
        <h3>Secondary Antibodies</h3>

        <asp:objectdatasource
              id="secondaryAntibodiesDataSource"
              runat="server"
               />

        <asp:GridView ID="gvSecondaryAntibodies" runat="server" AutoGenerateColumns="False" CssClass="data" AllowPaging="true" AllowSorting="true" DataSourceID="secondaryAntibodiesDataSource">
            <SortedAscendingHeaderStyle CssClass="sortAsc" />
            <SortedAscendingCellStyle CssClass="cellAsc" />
            <SortedDescendingHeaderStyle CssClass="sortDesc" />
            <SortedDescendingCellStyle CssClass="cellDesc" />
            <Columns>
                <asp:BoundField DataField="labID" HeaderText="Lab ID" SortExpression="labID" />
                <asp:BoundField DataField="antibodyName" HeaderText="Name" SortExpression="antibodyName" />
                <asp:BoundField DataField="hostSpecies" HeaderText="Host Species" SortExpression="hostSpecies" />
                <asp:BoundField DataField="reactiveSpecies" HeaderText="Reactive Species" SortExpression="reactiveSpecies" />
                <asp:BoundField DataField="flourophore" HeaderText="Flourophore" SortExpression="flourophore" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <span id="openSecondaryAntibodies">
                            <asp:HyperLink ID="viewButton" runat="server" CssClass="view" Text="<i class='icon-search'></i>" NavigateUrl='<%# Eval("id") %>'/>
                            <asp:LinkButton ID="deleteButton" runat="server" Text="<i class='icon-trash'></i>" PostBackUrl='<%# string.Format("?Delete={0}", Eval("id")) %>' OnClick="btnDelete_click" />
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <pagersettings mode="Numeric"
                  position="Bottom"           
                  pagebuttoncount="3"/>

            <pagerstyle
                height="30px"
                verticalalign="Bottom"
                horizontalalign="Center"/>

        </asp:GridView>
    </div>
</asp:Content>
