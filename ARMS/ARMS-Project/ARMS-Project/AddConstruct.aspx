<%@ Page Title="" Language="C#" MasterPageFile="~/assets/Layout.Master" AutoEventWireup="true" CodeBehind="AddConstruct.aspx.cs" Inherits="ARMS_Project.AddConstruct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="content">
        <h3>Add DNA Construct</h3>
        <div class="alert alert-error">
          <button type="button" class="close" data-dismiss="alert">×</button>
          <p></p>
        </div>
        <table class="data form table table-bordered table-striped">
            <tr>
                <td>Lab:</td>
                <td>
                    <asp:DropDownList ID="ddlLabID" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtname" CssClass="quickValidate" data-validate="required" data-name="Name" runat="server" Text='<%# Eval("name") %>' /></td>
            </tr>
            <tr>
                <td>Insert:</td>
                <td><asp:TextBox ID="txtinsert" CssClass="quickValidate" data-validate="required" data-name="Insert" runat="server" Text='<%# Eval("insert") %>' /></td>
            </tr>
            <tr>
                <td>Vector:</td>
                <td><asp:TextBox ID="txtvector" CssClass="quickValidate" data-validate="required" data-name="Vector" runat="server" Text='<%# Eval("vector") %>' /></td>
            </tr>
            <tr>
                <td>Species:</td>
                <td><asp:TextBox ID="txtSpecies" CssClass="quickValidate" data-validate="required" data-name="Species" runat="server" Text='<%# Eval("species") %>' /></td>
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
                    </asp:DropDownList>
                    <asp:TextBox ID="txtantibioticResistance" runat="server" placeholder="Other" CssClass="other hide" />
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
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" OnClick="btnSubmit_click" Text="Submit" />
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        $('.form').quickValidate();
    </script>
</asp:Content>
