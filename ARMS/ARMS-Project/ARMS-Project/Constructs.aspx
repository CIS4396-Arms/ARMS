<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Constructs.aspx.cs" Inherits="ARMS_Project.Constructs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    <div id="popUp">
        <h3>DNA Construct<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <div class="controls">
            <a href="#" class="edit icon-button"><i class="icon-edit"></i><span>Edit</span></a>
            <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_click" class="save icon-button hide" Text="<i class='icon-save'></i><span>Save</span>"></asp:LinkButton>
        </div>
        <table class="data form">
        <asp:HiddenField ID="txtid" runat="server" />
            <tr>
                <td>Lab Id:</td>
                <td><asp:TextBox ID="txtlabID" runat="server" Text='<%# Eval("labId") %>' /></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtname" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Insert:</td>
                <td><asp:TextBox ID="txtinsert" runat="server" Text='<%# Eval("insert") %>' /></td>
            </tr>
            <tr>
                <td>Vector:</td>
                <td><asp:TextBox ID="txtvector" runat="server" Text='<%# Eval("vector") %>' /></td>
            </tr>
            <tr>
                <td>Species:</td>
                <td><asp:TextBox ID="txtspecies" runat="server" Text='<%# Eval("species") %>' /></td>
            </tr>
            <tr>
                <td>Antibiotic Resistance:</td>
                <td><asp:TextBox ID="txtantibioticResistance" runat="server" Text='<%# Eval("antibioticResistance") %>' /></td>
            </tr>
            <tr>
                <td>Digest Site 5':</td>
                <td><asp:TextBox ID="txtdigestSite5" runat="server" Text='<%# Eval("digestSite5") %>' /></td>
            </tr>
            <tr>
                <td>Digest Site 3':</td>
                <td><asp:TextBox ID="txtdigestSite3" runat="server" Text='<%# Eval("digestSite3") %>' /></td>
            </tr>
            <tr>
                <td>Notes:</td>
                <td><asp:TextBox ID="txtnotes" runat="server" TextMode="MultiLine" Text='<%# Eval("notes") %>' /></td>
            </tr>
        </table>
    </div>

    <div id="content">
        <h3>DNA Constructs</h3>

        <div class="filter">
            <h4>Filter Constructs</h4>
            <asp:TextBox ID="txtFilterKeyword" runat="server" placeholder="Keyword"></asp:TextBox>
            <asp:DropDownList ID="ddlFilter" runat="server">
                <asp:ListItem Value="labID">Lab ID</asp:ListItem>
                <asp:ListItem Value="antibodyName">Name</asp:ListItem>
                <asp:ListItem Value="insert">Insert</asp:ListItem>
                <asp:ListItem Value="vector">Vector</asp:ListItem>
                <asp:ListItem Value="species">Species</asp:ListItem>
                <asp:ListItem Value="antibioticResistance">Antibiotic Resistance</asp:ListItem>
                <asp:ListItem Value="digestSite5">Digest Site 5'</asp:ListItem>
                <asp:ListItem Value="digestSite3">Digest Site 3'</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnFilter" runat="server" Text="Go" CssClass="go" OnClick="btnFilter_click" />
        </div>
        <asp:objectdatasource
              id="constructsDataSource"
              runat="server"
               />

        <asp:GridView ID="gvConstructs" runat="server" DataSourceID="constructsDataSource" AutoGenerateColumns="False" CssClass="data" AllowPaging="true" AllowSorting="true" >
            <SortedAscendingHeaderStyle CssClass="sortAsc" />
            <SortedAscendingCellStyle CssClass="cellAsc" />
            <SortedDescendingHeaderStyle CssClass="sortDesc" />
            <SortedDescendingCellStyle CssClass="cellDesc" />
            <Columns>
                <asp:BoundField DataField="labID" HeaderText="ID" SortExpression="labID" />
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <asp:BoundField DataField="species" HeaderText="Species" SortExpression="species" />
                <asp:BoundField DataField="insert" HeaderText="Insert" SortExpression="insert" />
                <asp:BoundField DataField="antibioticResistance" HeaderText="Antibiotic Resistance" SortExpression="antibioticResistance" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <span id="openConstructs">
                            <asp:HyperLink ID="openConstruct" runat="server" CssClass="view" Text="<i class='icon-search'></i>" NavigateUrl='<%# Eval("id") %>'/>
                        </span>
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
