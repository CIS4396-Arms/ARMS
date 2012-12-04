<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="SecondaryAntibodies.aspx.cs" Inherits="ARMS_Project.SecondaryAntibodies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="popUp">
        <h3>Secondary Antibody<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <div class="alert alert-error">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <p></p>
        </div>
        <div class="controls">
            <a href="#" class="edit icon-button"><i class="icon-edit"></i><span>Edit</span></a>
            <asp:LinkButton runat="server" id="btnPrint" class="icon-button" Text="Print" OnClick="btnPrint_Click"></asp:LinkButton>
            <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_click" class="save icon-button hide" Text="<i class='icon-save'></i><span>Save</span>"></asp:LinkButton>
        </div>
        <table class="data form">
        <asp:HiddenField ID="txtid" runat="server" />
            <tr>
                <td>Lab ID:</td>
                <td><asp:DropDownList ID="ddllabID" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtantibodyName" CssClass="quickValidate" data-validate="required" data-name="Name" runat="server" Text='<%# Eval("name") %>' /></td>
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
                <td>
                    <asp:DropDownList ID="ddlhostSpecies" runat="server" CssClass="chzn-select">
                        <asp:ListItem>Bovine</asp:ListItem>
                        <asp:ListItem>Cat</asp:ListItem>
                        <asp:ListItem>Chicken</asp:ListItem>
                        <asp:ListItem>Dog</asp:ListItem>
                        <asp:ListItem>Goat</asp:ListItem>
                        <asp:ListItem>Guinea Pig</asp:ListItem>
                        <asp:ListItem>Hamster</asp:ListItem>
                        <asp:ListItem>Horse</asp:ListItem>
                        <asp:ListItem>Human</asp:ListItem>
                        <asp:ListItem>Mouse</asp:ListItem>
                        <asp:ListItem>Mouse IgG1</asp:ListItem>
                        <asp:ListItem>Mouse IgG2a</asp:ListItem>
                        <asp:ListItem>Mouse IgG2b</asp:ListItem>
                        <asp:ListItem>Mouse IgG2c</asp:ListItem>
                        <asp:ListItem>Mouse IgG3</asp:ListItem>
                        <asp:ListItem>Rabbit</asp:ListItem>
                        <asp:ListItem>Rat</asp:ListItem>
                        <asp:ListItem>Sheep</asp:ListItem>
                        <asp:ListItem>Swine</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Reactive Species:</td>
                <td>
                    <asp:ListBox ID="ddlreactiveSpecies" runat="server" SelectionMode="Multiple" CssClass="chzn-select">
                        <asp:ListItem>Bovine</asp:ListItem>
                        <asp:ListItem>Cat</asp:ListItem>
                        <asp:ListItem>Chicken</asp:ListItem>
                        <asp:ListItem>Dog</asp:ListItem>
                        <asp:ListItem>Goat</asp:ListItem>
                        <asp:ListItem>Guinea Pig</asp:ListItem>
                        <asp:ListItem>Hamster</asp:ListItem>
                        <asp:ListItem>Horse</asp:ListItem>
                        <asp:ListItem>Human</asp:ListItem>
                        <asp:ListItem>Mouse</asp:ListItem>
                        <asp:ListItem>Mouse IgG1</asp:ListItem>
                        <asp:ListItem>Mouse IgG2a</asp:ListItem>
                        <asp:ListItem>Mouse IgG2b</asp:ListItem>
                        <asp:ListItem>Mouse IgG2c</asp:ListItem>
                        <asp:ListItem>Mouse IgG3</asp:ListItem>
                        <asp:ListItem>Rabbit</asp:ListItem>
                        <asp:ListItem>Rat</asp:ListItem>
                        <asp:ListItem>Sheep</asp:ListItem>
                        <asp:ListItem>Swine</asp:ListItem>
                    </asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>Fluorophore:</td>
                <td>
                    <asp:DropDownList ID="ddlfluorophore" runat="server" CssClass="chzn-select">
                        <asp:ListItem>Methoxycoumarin DyLight 405</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 405</asp:ListItem>
                        <asp:ListItem>Brilliant Violet 421TM</asp:ListItem>
                        <asp:ListItem>HiLyte FluorTM 405</asp:ListItem>
                        <asp:ListItem>DyLight 350</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 350</asp:ListItem>
                        <asp:ListItem>Aminocoumarin (AMCA)</asp:ListItem>
                        <asp:ListItem>BD HorizonTM V450</asp:ListItem>
                        <asp:ListItem>Pacific BlueTM</asp:ListItem>
                        <asp:ListItem>EviTagTM quantum dots-Lake Placid Blue AMCyan</asp:ListItem>
                        <asp:ListItem>BD HorizonTM V500</asp:ListItem>
                        <asp:ListItem>Cy2</asp:ListItem>
                        <asp:ListItem>ChromeoTM 488</asp:ListItem>
                        <asp:ListItem>DyLight 488</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 488</asp:ListItem>
                        <asp:ListItem>FAM</asp:ListItem>
                        <asp:ListItem>Fluorescein Iso-thiocyanate (FITC)</asp:ListItem>
                        <asp:ListItem>EviTagTM quantum dots-Adirondack Green</asp:ListItem>
                        <asp:ListItem>ChromeoTM 505 HiLyte</asp:ListItem>
                        <asp:ListItem>FluorTM 488</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 514</asp:ListItem>
                        <asp:ListItem>EviTagTM quantum dots-Catskill Green</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 430</asp:ListItem>
                        <asp:ListItem>Pacific OrangeTM</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 532 HEX</asp:ListItem>
                        <asp:ListItem>EviTagTM quantum dots-Hops Yellow</asp:ListItem>
                        <asp:ListItem>ChromeoTM 546 Cy3</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 555</asp:ListItem>
                        <asp:ListItem>HiLyte FluorTM 555</asp:ListItem>
                        <asp:ListItem>5-TAMRA</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 546</asp:ListItem>
                        <asp:ListItem>DyLight 550</asp:ListItem>
                        <asp:ListItem>Phycoerythrin (PE)</asp:ListItem>
                        <asp:ListItem>Tetramethyl Rhodamine Isothiocyanate (TRITC)</asp:ListItem>
                        <asp:ListItem>EviTagTM quantum dots-Birch Yellow</asp:ListItem>
                        <asp:ListItem>Cy3.5</asp:ListItem>
                        <asp:ListItem>Rhodamine Red-X</asp:ListItem>
                        <asp:ListItem>PE-Dyomics 590</asp:ListItem>
                        <asp:ListItem>EviTagTM quantum ROX dots-Fort Orange</asp:ListItem>
                        <asp:ListItem>ROX</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 568</asp:ListItem>
                        <asp:ListItem>Red 613</asp:ListItem>
                        <asp:ListItem>Texas Red</asp:ListItem>
                        <asp:ListItem>HiLyte FluorTM 594</asp:ListItem>
                        <asp:ListItem>PE-Texas Red</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 594</asp:ListItem>
                        <asp:ListItem>DyLight 594</asp:ListItem>
                        <asp:ListItem>EviTagTM quantum dots-Maple-Red Orange</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 610</asp:ListItem>
                        <asp:ListItem>ChromeoTM 494</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 633</asp:ListItem>
                        <asp:ListItem>SureLight APC</asp:ListItem>
                        <asp:ListItem>DyLight 633</asp:ListItem>
                        <asp:ListItem>Allophycocyanin (APC)</asp:ListItem>
                        <asp:ListItem>ChromeoTM 642</asp:ListItem>
                        <asp:ListItem>Quantum Red</asp:ListItem>
                        <asp:ListItem>SureLight P3</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 647</asp:ListItem>
                        <asp:ListItem>Cy5</asp:ListItem>
                        <asp:ListItem>PE-Cy5</asp:ListItem>
                        <asp:ListItem>SureLight P1</asp:ListItem>
                        <asp:ListItem>PE-Alexa Fluor 647</asp:ListItem>
                        <asp:ListItem>PE-Dyomics 647</asp:ListItem>
                        <asp:ListItem>DyLight 650</asp:ListItem>
                        <asp:ListItem>HiLyte FluorTM 647</asp:ListItem>
                        <asp:ListItem>Peridinin Chlorophyll (PerCP)</asp:ListItem>
                        <asp:ListItem>IRDye 700DX</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 660</asp:ListItem>
                        <asp:ListItem>PE-Cy5.5</asp:ListItem>
                        <asp:ListItem>APC-Cy5.5</asp:ListItem>
                        <asp:ListItem>Cy5.5</asp:ListItem>
                        <asp:ListItem>TruRed</asp:ListItem>
                        <asp:ListItem>HiLyte FluorTM 680</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 680</asp:ListItem>
                        <asp:ListItem>DyLight 680</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 700</asp:ListItem>
                        <asp:ListItem>APC-Cy7</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 750</asp:ListItem>
                        <asp:ListItem>Cy7</asp:ListItem>
                        <asp:ListItem>PE-Dyomics 747</asp:ListItem>
                        <asp:ListItem>DyLight 755</asp:ListItem>
                        <asp:ListItem>HiLyte FluorTM 750</asp:ListItem>
                        <asp:ListItem>PE-Cy7</asp:ListItem>
                        <asp:ListItem>IRDye 800RS</asp:ListItem>
                        <asp:ListItem>DyLight 800</asp:ListItem>
                        <asp:ListItem>IRDye 800CW</asp:ListItem>
                        <asp:ListItem>Alexa Fluor 790</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList><p class="clearfix"><br />
                    <asp:TextBox ID="txtfluorophore" runat="server" placeholder="Other" CssClass="other" Text='<%# Eval("fluorophore") %>' /></p>
                </td>
            </tr>
            <tr>
                <td>Working Dilution</td>
                <td><asp:TextBox ID="txtworkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' /></td>
            </tr>
            <tr>
                <td>Lot Number</td>
                <td><asp:TextBox ID="txtlotNumber" runat="server" CssClass="quickValidate" data-validate="required" data-name="Lot Number" Text='<%# Eval("lotNumber") %>' /></td>
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
    <script type="text/javascript">
        $('#popUp').quickValidate();
    </script>
    <div id="content">
        <h3>Secondary Antibodies</h3>

        <div class="filter">
            <h4>Filter Secondary Antibodies</h4>
            <asp:TextBox ID="txtFilterKeyword" runat="server" placeholder="Keyword"></asp:TextBox>
            <asp:DropDownList ID="ddlFilter" runat="server">
                <asp:ListItem Value="labID">Lab ID</asp:ListItem>
                <asp:ListItem Value="antibodyName">Name</asp:ListItem>
                <asp:ListItem Value="hostSpecies">Host Species</asp:ListItem>
                <asp:ListItem Value="reactiveSpecies">Reactive Species</asp:ListItem>
                <asp:ListItem Value="lotNumber">Lot Number</asp:ListItem>
                <asp:ListItem Value="concentration">Concentration</asp:ListItem>
                <asp:ListItem Value="workingDilution">Working Dilution</asp:ListItem>
                <asp:ListItem Value="applications">Applications</asp:ListItem>
                <asp:ListItem Value="antigen">Antigen</asp:ListItem>
                <asp:ListItem Value="fluorophore">Fluorophore</asp:ListItem>
                <asp:ListItem Value="excitation">Excitation</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnFilter" runat="server" Text="Go" CssClass="go btn btn-success" OnClick="btnFilter_click" />
        </div>
        <div class="alert alert-info" runat="server" ID="alertNoResults">   
            <p>Nothing found, <a href="SecondaryAntibodies.aspx">Clear Search</a></p>
        </div>

        <div class="alert alert-success" runat="server" ID="alertResults">   
            <p><a href="SecondaryAntibodies.aspx">Clear Search</a></p>
        </div>
        <asp:objectdatasource
              id="secondaryAntibodiesDataSource"
              runat="server"
               />

        <asp:GridView ID="gvSecondaryAntibodies" runat="server" AutoGenerateColumns="False" CssClass="data table" AllowPaging="true" AllowSorting="true" DataSourceID="secondaryAntibodiesDataSource">
            <SortedAscendingHeaderStyle CssClass="sortAsc" />
            <SortedAscendingCellStyle CssClass="cellAsc" />
            <SortedDescendingHeaderStyle CssClass="sortDesc" />
            <SortedDescendingCellStyle CssClass="cellDesc" />
            <Columns>
                <asp:BoundField DataField="labID" HeaderText="Lab ID" SortExpression="labID" />
                <asp:BoundField DataField="antibodyName" HeaderText="Name" SortExpression="antibodyName" />
                <asp:BoundField DataField="hostSpecies" HeaderText="Host Species" SortExpression="hostSpecies" />
                <asp:BoundField DataField="reactiveSpecies" HeaderText="Reactive Species" SortExpression="reactiveSpecies" />
                <asp:BoundField DataField="fluorophore" HeaderText="Fluorophore" SortExpression="fluorophore" />
                <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="actions">
                    <ItemTemplate>
                        <span id="openSecondaryAntibodies">
                            <asp:HyperLink ID="viewButton" runat="server" CssClass="view" Text="<i class='icon-search'></i>" NavigateUrl='<%# Eval("id") %>'/>
                            <asp:LinkButton ID="deleteButton" runat="server" CssClass="deleteButton" Text="<i class='icon-trash'></i>" PostBackUrl='<%# string.Format("?Delete={0}", Eval("id")) %>' OnClick="btnDelete_click" />
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