<%@ Page Title="" Language="C#" MasterPageFile="~/WebFormsMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm_with_Master_P3.aspx.cs" Inherits="Ellen_Conversion_M_1.Asp_WebForm_Pages.WebForm_with_Master_P3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../stylesheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Page 3</h1>
    <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
    <%-- AutoPostBack="false"--%>


    <div>
        <asp:ValidationSummary ID="ValidationSummary1"  ValidationGroup="AAA" runat="server" Forecolor="Red"/>
    </div>



    <div id="new_test" >                                                                           
        <asp:TextBox  ID = "TextBox1" ValidationGroup="AAA" runat = "server" ></asp:TextBox>        
        <asp:Button   ID = "Button1"  ValidationGroup="AAA" runat = "server" Text="Submit Data" OnClick="Button1_Click"/>  
        <asp:Label    ID = "Label1"   ValidationGroup="AAA" runat = "server" Text="Label">Label1 Default Display</asp:Label>
        

<%--breaks if this is set ToolTip 'true' - false means only sever-side validation--%>
      <asp:RequiredFieldValidator             
            ID="RequiredFieldValidator1"
            runat="server" 
            ValidationGroup="AAA"     
            ControlToValidate="TextBox1"
            ErrorMessage="This field can't be empty !!" 
            Text="*"                
            Display="Dynamic"
            EnableClientScript="False"   
      ></asp:RequiredFieldValidator>


      <asp:CompareValidator 
            ID="CompareValidator1" 
            runat="server" 
            ValidationGroup="AAA"
            ControlToValidate="TextBox1"
            ErrorMessage="Not a valid number!! CompareValidator"
            Text="*" 
            Display="Dynamic"
            Type="Double"
            Operator ="DataTypeCheck"
            EnableClientScript="False" 
      ></asp:CompareValidator>

    </div>





    <asp:GridView ID="gvGrid" runat="server">
    </asp:GridView>


    <asp:Panel ID="Panel1" runat="server" CssClass="Panel1">

    <asp:TextBox ID="txtName" runat="server" Width="136px"></asp:TextBox>


        &nbsp;
        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <asp:Button ID="btnRetrieveAll" runat="server" OnClick="btnRetrieveAll_Click" Text="Retrieve All" />
        <asp:Button ID="btnClearDisplay" runat="server" OnClick="btnClearDisplay_Click" Text="Clear Display" />
    </asp:Panel>




   
    <asp:ListBox ID="ListBox1" runat="server" BackColor="#FFFF66" Height="191px" Width="550px"></asp:ListBox>

</asp:Content>
