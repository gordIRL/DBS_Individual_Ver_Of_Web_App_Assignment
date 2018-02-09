<%@ Page Title="" Language="C#" MasterPageFile="~/WebFormsMasterPage.Master" AutoEventWireup="true" CodeBehind="CheckAvailability.aspx.cs" Inherits="Ellen_Conversion_M_1.WebPagesForDatabase.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Please select dates to check availability</h1>
    <asp:Panel ID="Panel1" runat="server" Height="215px">
        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" style="float:left"></asp:Calendar>
        <asp:Button ID="btnAddDate" runat="server" OnClick="btnAddDate_Click" Text="Add Date(s)" Width="104px" />
        <asp:ListBox ID="lstboxDisplayDates" runat="server" AutoPostBack="True" Height="183px" style="float:right" Width="181px"></asp:ListBox>
        <br />
        <asp:Button ID="btnReloadPage" runat="server" OnClick="btnReloadPage_Click"  Text="Clear Dates" Width="105px" />
        
    </asp:Panel>
    <br />
        



    <asp:Panel ID="Panel2" runat="server" Height="122px">
        <asp:Label ID="Label1" runat="server" Text="Please enter number of guests: "></asp:Label>
        <asp:TextBox ID="txtNoOfGuests" runat="server"></asp:TextBox>
        <asp:Button ID="btnCheckAvailability" runat="server" OnClick="btnCheckAvailability_Click" Text="Check Availability" />
        <br />
        <asp:Label ID="lblAvailabilityResult" runat="server" Text="Results:"></asp:Label>               
    </asp:Panel>
   
    <a href="CreateNewCustomer.aspx">Register as a New Customer (CreateNewCustomer Page)</a>

    <br />
    <br />
    <asp:Button ID="btnCreateAvailabiltyBooking" runat="server" OnClick="btnCreateAvailabiltyBooking_Click" Text="Create Availabilty Booking" />



    <asp:Panel ID="panelCreateAvailability" runat="server" BorderStyle="Solid" Height="139px" Width="1071px">
        <br />
        <asp:Label ID="Label9" runat="server" Text="Book Availability:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="BookingId: "></asp:Label>
        <asp:TextBox ID="txtAvail_BookingID" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label7" runat="server" Text="RoomID: "></asp:Label>
        <asp:TextBox ID="txtAvail_RoomID" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="No Of Guests: "></asp:Label>
        <asp:TextBox ID="txtAvail_NoOfGuests" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBookAvailability" runat="server"  Text="Book Availability" />
        <br />
        <br />
        <asp:Label ID="lblAvailabilityStatus" runat="server" Text="Status: "></asp:Label>
        <asp:Label ID="lbAvailabilityStatus" runat="server" Text="Label"></asp:Label>
    </asp:Panel>



</asp:Content>
