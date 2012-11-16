<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="True" CodeBehind="Antibodies.aspx.cs" Inherits="ARMS_Project.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="popUp">
        <h3>Antibody Name<a href="#close"><i class="icon-remove-sign"></i></a></h3>
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
                <td>Lot Number:</td>
                <td><asp:TextBox ID="txtlotNumber" runat="server" Text='<%# Eval("lotNumber") %>' /></td>
            </tr>
            <tr>
                <td>Enzyme Name:</td>
                <td><asp:TextBox ID="txtname" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Type:</td>
                <td><asp:TextBox ID="txttype" runat="server" Text='<%# Eval("type") %>' /></td>
            </tr>
            <tr>
                <td>Clone:</td>
                <td><asp:TextBox ID="txtclone" runat="server" Text='<%# Eval("clone") %>' /></td>
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
                <td>Concentration:</td>
                <td><asp:TextBox ID="txtconcentration" runat="server" Text='<%# Eval("concentration") %>' /></td>
            </tr>
            <tr>
                <td>Working Dilution:</td>
                <td><asp:TextBox ID="txtworkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' /></td>
            </tr>
            <tr>
                <td>Isotype:</td>
                <td><asp:TextBox ID="txtisotype" runat="server" Text='<%# Eval("isotype") %>' /></td>
            </tr>
            <tr>
                <td>Antigen:</td>
                <td><asp:TextBox ID="txtantigen" runat="server" Text='<%# Eval("antigen") %>' /></td>
            </tr>
            <tr>
                <td>Fluorophore:</td>
                <td><asp:TextBox ID="txtfluorophore" runat="server" Text='<%# Eval("fluorophore") %>' /></td>
            </tr>
            <tr>
                <td>Application</td>
                <td><asp:TextBox ID="txtapplication" runat="server" Text='<%# Eval("application") %>' /></td>
            </tr>
           
        </table>
    </div>
    <div id="content">
        <h3>Primary Antibodies</h3>
        <div class="filter">
            <h4>Filter Antibodies</h4>
            <asp:TextBox ID="txtFilterKeyword" runat="server" placeholder="Keyword"></asp:TextBox>
            <asp:DropDownList ID="ddlFilter" runat="server">
                <asp:ListItem Value="labID">Lab ID</asp:ListItem>
                <asp:ListItem Value="enzymeName">Name</asp:ListItem>
                <asp:ListItem Value="hostSpecies">Host Species</asp:ListItem>
                <asp:ListItem Value="reactiveSpecies">Reactive Species</asp:ListItem>
                <asp:ListItem Value="lotNumber">Lot Number</asp:ListItem>
                <asp:ListItem Value="type">Type</asp:ListItem>
                <asp:ListItem Value="clone">Clone</asp:ListItem>
                <asp:ListItem Value="concentration">Concentration</asp:ListItem>
                <asp:ListItem Value="workingDilution">Working Dilution</asp:ListItem>
                <asp:ListItem Value="isotype">Isotype</asp:ListItem>
                <asp:ListItem Value="applications">Applications</asp:ListItem>
                <asp:ListItem Value="antigen">Antigen</asp:ListItem>
                <asp:ListItem Value="flurosphore">Flurosphore</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnFilter" runat="server" Text="Go" CssClass="go" OnClick="btnFilter_click" />
        </div>
        <asp:objectdatasource
              id="antibodiesDataSource"
              runat="server"
               />

        <asp:GridView ID="gvAntibodies" runat="server" DataSourceID="antibodiesDataSource" AutoGenerateColumns="False" CssClass="data" AllowPaging="true" AllowSorting="true" >
            <SortedAscendingHeaderStyle CssClass="sortAsc" />
            <SortedAscendingCellStyle CssClass="cellAsc" />
            <SortedDescendingHeaderStyle CssClass="sortDesc" />
            <SortedDescendingCellStyle CssClass="cellDesc" />
            <Columns>
                <asp:BoundField DataField="labID" SortExpression="labID" HeaderText="Lab ID" />
                <asp:BoundField DataField="name" SortExpression="name" HeaderText="Name"  />
                <asp:BoundField DataField="type" SortExpression="type" HeaderText="Type" />
                <asp:BoundField DataField="hostSpecies" HeaderText="Host Species" SortExpression="hostSpecies" />
                <asp:BoundField DataField="reactiveSpecies" HeaderText="Reactive Species" SortExpression="reactiveSpecies" />
                <asp:BoundField DataField="applications" SortExpression="applications" HeaderText="Applications" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="actions" HeaderStyle-CssClass="actionsHeader">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="view" Text="<i class='icon-search'></i>" NavigateUrl='<%# Eval("id") %>'/>
                        <asp:LinkButton ID="deleteButton" runat="server" Text="<i class='icon-trash'></i>" PostBackUrl='<%# string.Format("?Delete={0}", Eval("id")) %>' OnClick="btnDelete_click" />
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