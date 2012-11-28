<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="True" CodeBehind="AddAntibody.aspx.cs" Inherits="ARMS_Project.AddAntibody" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    
    <div id="content">
        <h3>Add Antibody</h3>

        <div class="alert alert-error">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <p></p>
        </div>
        
        <table class="data form table table-striped table-bordered form-inline">
            <tr>
                <td>Lab:</td>
                <td>
                    <asp:DropDownList ID="ddlLabID" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Lot Number:</td>
                <td><asp:TextBox ID="txtLotNumber" CssClass="quickValidate" data-validate="required" data-name="Lot Number" runat="server" Text='<%# Eval("lotNumber") %>' /></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtName" CssClass="quickValidate" data-validate="required" data-name="Name" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Type:</td>
                <td>
                    <asp:RadioButton id="rbMono" CssClass="radio" Text="Monoclonal" Checked="True" GroupName="cloneType" runat="server" />
                    <asp:RadioButton id="rbPoly" CssClass="radio" Text="Polyclonal" GroupName="cloneType" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Clone:</td>
                <td><asp:TextBox ID="txtClone" runat="server" Text='<%# Eval("clone") %>' /></td>
            </tr>
            <tr>
                <td>Host Species:</td>
                <td>
                    <asp:DropDownList ID="ddlHostSpecies" runat="server" CssClass="chzn-select">
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
                    <asp:ListBox ID="ddlReactiveSpecies" runat="server" SelectionMode="Multiple" CssClass="chzn-select">
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
                <td>Concentration:</td>
                <td><asp:TextBox ID="txtConcentration" runat="server" Text='<%# Eval("concentration") %>' /></td>
            </tr>
            <tr>
                <td>Working Dilution:</td>
                <td><asp:TextBox ID="txtWorkingDilution" runat="server" Text='<%# Eval("workingDilution") %>' /></td>
            </tr>
            <tr>
                <td>Isotype:</td>
                <td><asp:TextBox ID="txtIsotype" runat="server" Text='<%# Eval("isotype") %>' /></td>
            </tr>
            <tr>
                <td>Antigen:</td>
                <td><asp:TextBox ID="txtAntigen" runat="server" Text='<%# Eval("antigen") %>' /></td>
            </tr>
            <tr>
                <td>Fluorophore:</td>
                <td>
                    <asp:DropDownList ID="ddlFluorophore" runat="server" CssClass="chzn-select">
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
                    </asp:DropDownList>
                    <asp:TextBox ID="fluorophoreOther" runat="server" placeholder="Other" CssClass="other hide" />
                </td>
            </tr>
            <tr>
                <td>Application</td>
                <td><asp:TextBox ID="txtApplication" runat="server" Text='<%# Eval("application") %>' /></td>
            </tr>
            <tr>
                <td>Protocol</td>
                <td>
                    
                    <ul id="protocol">
                    
                    </ul>

                    <asp:FileUpload id="ProtcolUpload"                 
                       runat="server">
                   </asp:FileUpload>

                   <br /><br />

                   <asp:Button id="btnProtocolUpload" 
                       Text="Upload file"
                       OnClick="ProtcolUpload_Click"
                       runat="server" 
                       CssClass="btn btn-primary upload" />
                   
                   
                   <asp:Label ID="lblProtcolUpload" runat="server"></asp:Label>

                   <asp:HiddenField ID="protocolHREF" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>
        <script type="text/javascript">
            $('.form').quickValidate();
        </script>
    </div>
</asp:Content>
