<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Vectors.aspx.cs" Inherits="ARMS_Project.Vectors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div id="popUp">
        <h3>Vector<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <div class="alert alert-error">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <p></p>
        </div>
        <div class="controls">
            <a href="#" class="edit icon-button"><i class="icon-edit"></i><span>Edit</span></a>
            <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_click" class="save icon-button hide" Text="<i class='icon-save'></i><span>Save</span>"></asp:LinkButton>
            <asp:LinkButton runat="server" id="btnPrint" class="icon-button" Text="<i class='icon-print'></i><span>Print</span>" OnClick="btnPrint_Click"></asp:LinkButton>
        </div>
        <table class="data form table table-striped table-bordered">
           <asp:HiddenField ID="txtid" runat="server" />
           <tr>
                <td>Lab:</td>
                <td>
                    <asp:DropDownList ID="ddllabID" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Vector Name:</td>
                <td><asp:TextBox ID="txtvectorName" CssClass="quickValidate" data-validate="required" data-name="Name" runat="server" Text='<%# Eval("vectorName") %>' /></td>
            </tr>
            <tr>
                <td>Multiple Cloning Site:</td>
                <td><asp:TextBox ID="txtmultipleCloningSite" CssClass="quickValidate" data-validate="required" data-name="Multiple Cloning Site" runat="server" Text='<%# Eval("multipleCloningSite") %>' /></td>
            </tr>
            <tr>
                <td>Antibiotic Resistance</td>
                <td>
                    <asp:DropDownList ID="ddlantibioticResistance" runat="server" CssClass="chzn-select">
                        <asp:ListItem>Ampicillin</asp:ListItem>
                        <asp:ListItem>Carbenicillin</asp:ListItem>
                        <asp:ListItem>Chloramphenicol</asp:ListItem>
                        <asp:ListItem>Kanamycin</asp:ListItem>
                        <asp:ListItem>Rifampicin</asp:ListItem>
                        <asp:ListItem>Tetracycline HCl</asp:ListItem>
                        <asp:ListItem>Streptomycin</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList><p class="clearfix"><br />
                    <asp:TextBox ID="txtantibioticResistance" runat="server" placeholder="Other" CssClass="other" /></p>
                </td>
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
                       runat="server"
                       enabled="false">
                   </asp:FileUpload>

                   <br /><br />

                   <asp:Button id="btnSpecUpload" 
                       Text="Upload file"
                       OnClick="SpecUpload_Click"
                       runat="server"
                       CssClass="btn btn-primary"
                       Enabled="false"
                       />
                   
                   <asp:Label ID="lblSpecUpload" runat="server"></asp:Label>

                   <asp:HiddenField ID="txtspecSheetHREF" runat="server" />
                </td>
            </tr>
           
        </table>
    </div>
    <script type="text/javascript">
        $('#popUp').quickValidate();
    </script>
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
            <asp:Button ID="btnFilter" runat="server" Text="Go" CssClass="go btn btn-success" OnClick="btnFilter_click" />
        </div>
        <div class="alert alert-info" runat="server" ID="alertNoResults">   
            <p>Nothing found, <a href="Vectors.aspx">Clear Search</a></p>
        </div>

        <div class="alert alert-success" runat="server" ID="alertResults">   
            <p><a href="Vectors.aspx">Clear Search</a></p>
        </div>
        <asp:objectdatasource
              id="vectorsDataSource"
              runat="server"
               />
        <asp:GridView ID="gvVectors" runat="server" DataSourceID="vectorsDataSource" AutoGenerateColumns="False" CssClass="data table" AllowPaging="true" AllowSorting="true">
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
                        <asp:LinkButton ID="deleteButton" runat="server" CssClass="deleteButton" Text="<i class='icon-trash'></i>" PostBackUrl='<%# string.Format("?Delete={0}", Eval("id")) %>' OnClick="btnDelete_click" />
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