<%@ Page Title="" Language="C#" MasterPageFile="~/WebFormsMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm_with_Master_P2.aspx.cs" Inherits="Ellen_Conversion_M_1.Asp_WebForm_Pages.WebForm_with_Master_P2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script runat="server" type="text/c#">
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Panel refreshed at " +
            DateTime.Now.ToString();
    }
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Page 2</h1>
    <p>Hello this should be in the paragraph section</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Panel Created"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="Button1" runat="server" Text="Refresh Panel"   OnClick="Button1_Click"  />
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    </asp:UpdatePanel>


    <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>


    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>
