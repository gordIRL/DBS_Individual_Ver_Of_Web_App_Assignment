<%@ Page Title="" Language="C#" MasterPageFile="~/WebFormsMasterPage.Master" AutoEventWireup="true" CodeBehind="CreateNewCustomer.aspx.cs" Inherits="Ellen_Conversion_M_1.WebPagesForDatabase.CreateNewCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="180px">
        <asp:Label ID="Label1" runat="server" Text="Please enter your details to create an account."></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Email:  "></asp:Label>
        &nbsp;<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <br />
        <br />
        <asp:Label ID="lblDisplayStatus" runat="server" Text="Status: "></asp:Label>
    </asp:Panel>





</asp:Content>
