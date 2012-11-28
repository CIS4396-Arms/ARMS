<%@ Page Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="Constructs.aspx.cs" Inherits="ARMS_Project.Constructs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    <div id="popUp">
        <h3>DNA Construct<a href="#close"><i class="icon-remove-sign"></i></a></h3>
        <div class="alert alert-error">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <p></p>
        </div>
        <div class="controls">
            <a href="#" class="edit icon-button"><i class="icon-edit"></i><span>Edit</span></a>
            <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_click" class="save icon-button hide" Text="<i class='icon-save'></i><span>Save</span>"></asp:LinkButton>
        </div>
        <table class="data form table table-striped table-bordered">
        <asp:HiddenField ID="txtid" runat="server" />
            <tr>
                <td>Lab:</td>
                <td><asp:DropDownList ID="ddllabID" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox CssClass="quickValidate" data-validate="required" data-name="Name" ID="txtname" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Insert:</td>
                <td><asp:TextBox CssClass="quickValidate" data-validate="required" data-name="Insert" ID="txtinsert" runat="server" Text='<%# Eval("insert") %>' /></td>
            </tr>
            <tr>
                <td>Vector:</td>
                <td><asp:TextBox ID="txtvector" CssClass="quickValidate" data-validate="required" data-name="Vector" runat="server" Text='<%# Eval("vector") %>' /></td>
            </tr>
            <tr>
                <td>Species:</td>
                <td><asp:TextBox ID="txtspecies" CssClass="quickValidate" data-validate="required" data-name="Species" runat="server" Text='<%# Eval("species") %>' /></td>
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
                <td>Digest Site 5':</td>
                <td>
                    <asp:ListBox ID="ddldigestSite5" runat="server" SelectionMode="Multiple" CssClass="chzn-select">
                        <asp:ListItem>Aat II</asp:ListItem>
                        <asp:ListItem>Acc I</asp:ListItem>
                        <asp:ListItem>Acc III</asp:ListItem>
                        <asp:ListItem>Acc65 I</asp:ListItem>
                        <asp:ListItem>AccB7 I</asp:ListItem>
                        <asp:ListItem>Age I</asp:ListItem>
                        <asp:ListItem>Alu I</asp:ListItem>
                        <asp:ListItem>Alw26 I</asp:ListItem>
                        <asp:ListItem>Alw44 I</asp:ListItem>
                        <asp:ListItem>Apa I</asp:ListItem>
                        <asp:ListItem>Ava I</asp:ListItem>
                        <asp:ListItem>Ava II</asp:ListItem>
                        <asp:ListItem>Bal I</asp:ListItem>
                        <asp:ListItem>BamH I</asp:ListItem>
                        <asp:ListItem>Ban I</asp:ListItem>
                        <asp:ListItem>Ban II</asp:ListItem>
                        <asp:ListItem>Bbu I</asp:ListItem>
                        <asp:ListItem>Bcl I</asp:ListItem>
                        <asp:ListItem>Bgl I</asp:ListItem>
                        <asp:ListItem>Bgl II</asp:ListItem>
                        <asp:ListItem>BsaM I</asp:ListItem>
                        <asp:ListItem>Bsp1286 I</asp:ListItem>
                        <asp:ListItem>BsrS I</asp:ListItem>
                        <asp:ListItem>BssH II</asp:ListItem>
                        <asp:ListItem>Bst98 I</asp:ListItem>
                        <asp:ListItem>BstE II</asp:ListItem>
                        <asp:ListItem>BstO I</asp:ListItem>
                        <asp:ListItem>BstX I</asp:ListItem>
                        <asp:ListItem>BstZ I</asp:ListItem>
                        <asp:ListItem>Bsu36 I</asp:ListItem>
                        <asp:ListItem>Cfo I</asp:ListItem>
                        <asp:ListItem>Cla I</asp:ListItem>
                        <asp:ListItem>Csp I</asp:ListItem>
                        <asp:ListItem>Csp45 I</asp:ListItem>
                        <asp:ListItem>Dde I</asp:ListItem>
                        <asp:ListItem>Dpn I</asp:ListItem>
                        <asp:ListItem>Dra I</asp:ListItem>
                        <asp:ListItem>EclHK I</asp:ListItem>
                        <asp:ListItem>Eco47 III</asp:ListItem>
                        <asp:ListItem>Eco52 I</asp:ListItem>
                        <asp:ListItem>EcoICR I</asp:ListItem>
                        <asp:ListItem>EcoR I</asp:ListItem>
                        <asp:ListItem>EcoR V </asp:ListItem>
                        <asp:ListItem>Fok I</asp:ListItem>
                        <asp:ListItem>Hae II</asp:ListItem>
                        <asp:ListItem>Hae III</asp:ListItem>
                        <asp:ListItem>Hha I</asp:ListItem>
                        <asp:ListItem>Hinc II</asp:ListItem>
                        <asp:ListItem>Hind III</asp:ListItem>
                        <asp:ListItem>Hinf I</asp:ListItem>
                        <asp:ListItem>Hpa I</asp:ListItem>
                        <asp:ListItem>Hpa II</asp:ListItem>
                        <asp:ListItem>Hsp92 I</asp:ListItem>
                        <asp:ListItem>Hsp92 II</asp:ListItem>
                        <asp:ListItem>I-Ppo I</asp:ListItem>
                        <asp:ListItem>Kpn I</asp:ListItem>
                        <asp:ListItem>Mbo I</asp:ListItem>
                        <asp:ListItem>Mbo II</asp:ListItem>
                        <asp:ListItem>Mlu I</asp:ListItem>
                        <asp:ListItem>Msp I</asp:ListItem>
                        <asp:ListItem>MspA1 I</asp:ListItem>
                        <asp:ListItem>Nae I</asp:ListItem>
                        <asp:ListItem>Nar I</asp:ListItem>
                        <asp:ListItem>Nci I</asp:ListItem>
                        <asp:ListItem>Nco I</asp:ListItem>
                        <asp:ListItem>Nde I</asp:ListItem>
                        <asp:ListItem>Nde II</asp:ListItem>
                        <asp:ListItem>NgoM IV</asp:ListItem>
                        <asp:ListItem>Nhe I</asp:ListItem>
                        <asp:ListItem>Not I</asp:ListItem>
                        <asp:ListItem>Nru I</asp:ListItem>
                        <asp:ListItem>Nsi I</asp:ListItem>
                        <asp:ListItem>Pst I</asp:ListItem>
                        <asp:ListItem>Pvu I</asp:ListItem>
                        <asp:ListItem>Pvu II</asp:ListItem>
                        <asp:ListItem>Rsa I</asp:ListItem>
                        <asp:ListItem>Sac I</asp:ListItem>
                        <asp:ListItem>Sac II</asp:ListItem>
                        <asp:ListItem>Sal I</asp:ListItem>
                        <asp:ListItem>Sau3A I</asp:ListItem>
                        <asp:ListItem>Sca I</asp:ListItem>
                        <asp:ListItem>Sfi I</asp:ListItem>
                        <asp:ListItem>Sgf I</asp:ListItem>
                        <asp:ListItem>Sin I</asp:ListItem>
                        <asp:ListItem>Sma I</asp:ListItem>
                        <asp:ListItem>SnaB I</asp:ListItem>
                        <asp:ListItem>Spe I</asp:ListItem>
                        <asp:ListItem>Sph I</asp:ListItem>
                        <asp:ListItem>Ssp I</asp:ListItem>
                        <asp:ListItem>Stu I</asp:ListItem>
                        <asp:ListItem>Sty I</asp:ListItem>
                        <asp:ListItem>Taq I</asp:ListItem>
                        <asp:ListItem>Tru9 I</asp:ListItem>
                        <asp:ListItem>Tth111 I</asp:ListItem>
                        <asp:ListItem>Vsp I</asp:ListItem>
                        <asp:ListItem>Xba I</asp:ListItem>
                        <asp:ListItem>Xho I</asp:ListItem>
                        <asp:ListItem>Xho II</asp:ListItem>
                        <asp:ListItem>Xma I</asp:ListItem>
                        <asp:ListItem>Xmn I</asp:ListItem>                      
                    </asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>Digest Site 3':</td>
                <td>
                    <asp:ListBox ID="ddldigestSite3" runat="server" SelectionMode="Multiple" CssClass="chzn-select">
                        <asp:ListItem>Aat II</asp:ListItem>
                        <asp:ListItem>Acc I</asp:ListItem>
                        <asp:ListItem>Acc III</asp:ListItem>
                        <asp:ListItem>Acc65 I</asp:ListItem>
                        <asp:ListItem>AccB7 I</asp:ListItem>
                        <asp:ListItem>Age I</asp:ListItem>
                        <asp:ListItem>Alu I</asp:ListItem>
                        <asp:ListItem>Alw26 I</asp:ListItem>
                        <asp:ListItem>Alw44 I</asp:ListItem>
                        <asp:ListItem>Apa I</asp:ListItem>
                        <asp:ListItem>Ava I</asp:ListItem>
                        <asp:ListItem>Ava II</asp:ListItem>
                        <asp:ListItem>Bal I</asp:ListItem>
                        <asp:ListItem>BamH I</asp:ListItem>
                        <asp:ListItem>Ban I</asp:ListItem>
                        <asp:ListItem>Ban II</asp:ListItem>
                        <asp:ListItem>Bbu I</asp:ListItem>
                        <asp:ListItem>Bcl I</asp:ListItem>
                        <asp:ListItem>Bgl I</asp:ListItem>
                        <asp:ListItem>Bgl II</asp:ListItem>
                        <asp:ListItem>BsaM I</asp:ListItem>
                        <asp:ListItem>Bsp1286 I</asp:ListItem>
                        <asp:ListItem>BsrS I</asp:ListItem>
                        <asp:ListItem>BssH II</asp:ListItem>
                        <asp:ListItem>Bst98 I</asp:ListItem>
                        <asp:ListItem>BstE II</asp:ListItem>
                        <asp:ListItem>BstO I</asp:ListItem>
                        <asp:ListItem>BstX I</asp:ListItem>
                        <asp:ListItem>BstZ I</asp:ListItem>
                        <asp:ListItem>Bsu36 I</asp:ListItem>
                        <asp:ListItem>Cfo I</asp:ListItem>
                        <asp:ListItem>Cla I</asp:ListItem>
                        <asp:ListItem>Csp I</asp:ListItem>
                        <asp:ListItem>Csp45 I</asp:ListItem>
                        <asp:ListItem>Dde I</asp:ListItem>
                        <asp:ListItem>Dpn I</asp:ListItem>
                        <asp:ListItem>Dra I</asp:ListItem>
                        <asp:ListItem>EclHK I</asp:ListItem>
                        <asp:ListItem>Eco47 III</asp:ListItem>
                        <asp:ListItem>Eco52 I</asp:ListItem>
                        <asp:ListItem>EcoICR I</asp:ListItem>
                        <asp:ListItem>EcoR I</asp:ListItem>
                        <asp:ListItem>EcoR V </asp:ListItem>
                        <asp:ListItem>Fok I</asp:ListItem>
                        <asp:ListItem>Hae II</asp:ListItem>
                        <asp:ListItem>Hae III</asp:ListItem>
                        <asp:ListItem>Hha I</asp:ListItem>
                        <asp:ListItem>Hinc II</asp:ListItem>
                        <asp:ListItem>Hind III</asp:ListItem>
                        <asp:ListItem>Hinf I</asp:ListItem>
                        <asp:ListItem>Hpa I</asp:ListItem>
                        <asp:ListItem>Hpa II</asp:ListItem>
                        <asp:ListItem>Hsp92 I</asp:ListItem>
                        <asp:ListItem>Hsp92 II</asp:ListItem>
                        <asp:ListItem>I-Ppo I</asp:ListItem>
                        <asp:ListItem>Kpn I</asp:ListItem>
                        <asp:ListItem>Mbo I</asp:ListItem>
                        <asp:ListItem>Mbo II</asp:ListItem>
                        <asp:ListItem>Mlu I</asp:ListItem>
                        <asp:ListItem>Msp I</asp:ListItem>
                        <asp:ListItem>MspA1 I</asp:ListItem>
                        <asp:ListItem>Nae I</asp:ListItem>
                        <asp:ListItem>Nar I</asp:ListItem>
                        <asp:ListItem>Nci I</asp:ListItem>
                        <asp:ListItem>Nco I</asp:ListItem>
                        <asp:ListItem>Nde I</asp:ListItem>
                        <asp:ListItem>Nde II</asp:ListItem>
                        <asp:ListItem>NgoM IV</asp:ListItem>
                        <asp:ListItem>Nhe I</asp:ListItem>
                        <asp:ListItem>Not I</asp:ListItem>
                        <asp:ListItem>Nru I</asp:ListItem>
                        <asp:ListItem>Nsi I</asp:ListItem>
                        <asp:ListItem>Pst I</asp:ListItem>
                        <asp:ListItem>Pvu I</asp:ListItem>
                        <asp:ListItem>Pvu II</asp:ListItem>
                        <asp:ListItem>Rsa I</asp:ListItem>
                        <asp:ListItem>Sac I</asp:ListItem>
                        <asp:ListItem>Sac II</asp:ListItem>
                        <asp:ListItem>Sal I</asp:ListItem>
                        <asp:ListItem>Sau3A I</asp:ListItem>
                        <asp:ListItem>Sca I</asp:ListItem>
                        <asp:ListItem>Sfi I</asp:ListItem>
                        <asp:ListItem>Sgf I</asp:ListItem>
                        <asp:ListItem>Sin I</asp:ListItem>
                        <asp:ListItem>Sma I</asp:ListItem>
                        <asp:ListItem>SnaB I</asp:ListItem>
                        <asp:ListItem>Spe I</asp:ListItem>
                        <asp:ListItem>Sph I</asp:ListItem>
                        <asp:ListItem>Ssp I</asp:ListItem>
                        <asp:ListItem>Stu I</asp:ListItem>
                        <asp:ListItem>Sty I</asp:ListItem>
                        <asp:ListItem>Taq I</asp:ListItem>
                        <asp:ListItem>Tru9 I</asp:ListItem>
                        <asp:ListItem>Tth111 I</asp:ListItem>
                        <asp:ListItem>Vsp I</asp:ListItem>
                        <asp:ListItem>Xba I</asp:ListItem>
                        <asp:ListItem>Xho I</asp:ListItem>
                        <asp:ListItem>Xho II</asp:ListItem>
                        <asp:ListItem>Xma I</asp:ListItem>
                        <asp:ListItem>Xmn I</asp:ListItem>
                    </asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>Notes:</td>
                <td><asp:TextBox ID="txtnotes" runat="server" TextMode="MultiLine" Text='<%# Eval("notes") %>' /></td>
            </tr>
        </table>
    </div>
    
    <script type="text/javascript">
        $('#popUp').quickValidate();
    </script>
    <div id="content">
        <h3>DNA Constructs</h3>

        <div class="filter">
            <h4>Filter Constructs</h4>
            <asp:TextBox ID="txtFilterKeyword" runat="server" placeholder="Keyword"></asp:TextBox>
            <asp:DropDownList ID="ddlFilter" runat="server">
                <asp:ListItem Value="labID">Lab ID</asp:ListItem>
                <asp:ListItem Value="name">Name</asp:ListItem>
                <asp:ListItem Value="insert">Insert</asp:ListItem>
                <asp:ListItem Value="vector">Vector</asp:ListItem>
                <asp:ListItem Value="species">Species</asp:ListItem>
                <asp:ListItem Value="antibioticResistance">Antibiotic Resistance</asp:ListItem>
                <asp:ListItem Value="5'digestSite">Digest Site 5'</asp:ListItem>
                <asp:ListItem Value="3'digestSite">Digest Site 3'</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnFilter" runat="server" Text="Go" CssClass="go btn btn-success" OnClick="btnFilter_click" />
        </div>

        <div class="alert alert-info" runat="server" ID="alertNoResults">   
            <p>Nothing found, <a href="Constructs.aspx">Clear Search</a></p>
        </div>

        <div class="alert alert-success" runat="server" ID="alertResults">   
            <p><a href="Constructs.aspx">Clear Search</a></p>
        </div>

        <asp:objectdatasource
              id="constructsDataSource"
              runat="server"
               />

        <asp:GridView ID="gvConstructs" runat="server" DataSourceID="constructsDataSource" AutoGenerateColumns="False" CssClass="data table" AllowPaging="true" AllowSorting="true" >
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
