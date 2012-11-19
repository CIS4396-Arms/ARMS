<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Vectors.aspx.cs" Inherits="ARMS_Project.Vectors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="popUp">
        <h3>Vector<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <div class="controls">
            <a href="#" class="edit icon-button"><i class="icon-edit"></i><span>Edit</span></a>
            <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_click" class="save icon-button hide" Text="<i class='icon-save'></i><span>Save</span>"></asp:LinkButton>
        </div>
        <table class="data form">
           <asp:HiddenField ID="txtid" runat="server" />
           <tr>
                <td>Lab ID:</td>
                <td><asp:TextBox ID="txtlabID" runat="server" Text='<%# Eval("labID") %>' /></td>
            </tr>
            <tr>
                <td>Vector Name:</td>
                <td><asp:TextBox ID="txtvectorName" runat="server" Text='<%# Eval("vectorName") %>' /></td>
            </tr>
            <tr>
                <td>Multiple Cloning Site:</td>
                <td><asp:TextBox ID="txtmultipleCloningSite" runat="server" Text='<%# Eval("multipleCloningSite") %>' /></td>
            </tr>
            <tr>
                <td>Antibiotic Resistance</td>
                <td><asp:TextBox ID="txtantibioticResistance" runat="server" Text='<%# Eval("antibioticResistance") %>' /></td>
            </tr>
            <tr>
                <td>Promoter:</td>
                <td><asp:TextBox ID="txtpromter" runat="server" Text='<%# Eval("promoter") %>' /></td>
            </tr>
            <tr>
                <td>Size:</td>
                <td><asp:TextBox ID="txtvectorSize" runat="server" Text='<%# Eval("vectorSize") %>' /></td>
            </tr>
            <tr>
                <td>Notes:</td>
                <td><asp:TextBox ID="txtnotes" runat="server" TextMode="multiline" Text='<%# Eval("notes") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td>Specs</td>
                <td>

                    <asp:FileUpload id="SpecUpload"                 
                       runat="server">
                   </asp:FileUpload>

                   <br /><br />

                   <asp:Button id="btnSpecUpload" 
                       Text="Upload file"
                       OnClick="SpecUpload_Click"
                       runat="server">
                   </asp:Button>
                   
                   <asp:Label ID="lblSpecUpload" runat="server"></asp:Label>

                   <asp:HiddenField ID="txtspecSheetHREF" runat="server" />
                </td>
            </tr>
           
        </table>
    </div>

    <div id="content">
        <h3>Vectors</h3>
        <div class="filter">
            <h4>Filter Vectors</h4>
            <asp:TextBox ID="txtFilterKeyword" runat="server" placeholder="Keyword"></asp:TextBox>
            <asp:DropDownList ID="ddlFilter" runat="server">
                <asp:ListItem Value="labID">Lab ID</asp:ListItem>
                <asp:ListItem Value="vectorName">Name</asp:ListItem>
                <asp:ListItem Value="multipleCloningSite">Multiple Cloning Site</asp:ListItem>
                <asp:ListItem Value="antibioticResistance">Antibiotic Resistance</asp:ListItem>
                <asp:ListItem Value="promoter">Promoter</asp:ListItem>
                <asp:ListItem Value="vectorSize">Size</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnFilter" runat="server" Text="Go" CssClass="go" OnClick="btnFilter_click" />
        </div>
        <asp:objectdatasource
              id="vectorsDataSource"
              runat="server"
               />
        <asp:GridView ID="gvVectors" runat="server" DataSourceID="vectorsDataSource" AutoGenerateColumns="False" CssClass="data" AllowPaging="true" AllowSorting="true">
            <SortedAscendingHeaderStyle CssClass="sortAsc" />
            <SortedAscendingCellStyle CssClass="cellAsc" />
            <SortedDescendingHeaderStyle CssClass="sortDesc" />
            <SortedDescendingCellStyle CssClass="cellDesc" />
            <Columns>
                <asp:BoundField DataField="labID" HeaderText="Lab ID" SortExpression="labID" />
                <asp:BoundField DataField="vectorName" HeaderText="Name" SortExpression="vectorName" />
                <asp:BoundField DataField="multipleCloningSite" HeaderText="MCS" SortExpression="multipleCloningSite" />
                <asp:BoundField DataField="antibioticResistance" HeaderText="AR" SortExpression="antibioticResistance" />
                <asp:BoundField DataField="promoter" HeaderText="Promoter" />
                <asp:BoundField DataField="vectorSize" HeaderText="Size" SortExpression="vectorSize" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <span id="openVectors">
                            <asp:HyperLink ID="openVector" runat="server" CssClass="view" Text="<i class='icon-search'></i>" NavigateUrl='<%# Eval("id") %>'/>
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

        </asp:GridView>
    </div>
</asp:Content>