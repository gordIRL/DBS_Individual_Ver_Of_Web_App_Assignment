<%@ Page Title="" Language="C#" MasterPageFile="~/WebFormsMasterPage.Master" AutoEventWireup="true" CodeBehind="CreateBooking.aspx.cs" Inherits="Ellen_Conversion_M_1.WebPagesForDatabase.CreateBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="height: 46px">Create a New Booking</h1>
    <asp:Panel ID="Panel1" runat="server" Height="162px">
        <asp:Label ID="Label1" runat="server" Text="Please enter your email that you set up your account with:"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtEmail" runat="server" Width="177px"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <br />
        <br />
        <asp:Label ID="lblBookingStatus" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
</asp:Content>
