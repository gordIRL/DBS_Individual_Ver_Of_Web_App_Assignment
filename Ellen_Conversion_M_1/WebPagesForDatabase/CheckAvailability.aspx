<%@ Page Title="" Language="C#" MasterPageFile="~/WebFormsMasterPage.Master" AutoEventWireup="true" CodeBehind="CheckAvailability.aspx.cs" Inherits="Ellen_Conversion_M_1.WebPagesForDatabase.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    &nbsp;<br />
    <asp:Button ID="btnCheckDateAvailability" runat="server" OnClick="btnCheckDateAvailability_Click" Text="Check Date Availability" />
&nbsp; <asp:Button ID="btnRegisterAsNewCustomer" runat="server"  OnClick="btnRegisterAsNewCustomer_Click" Text="Register as a New Customer" />
    &nbsp;
    <asp:Button ID="btnSearchForBookingByEmail_" runat="server" OnClick="btnSearchForBookingByEmail__Click" Text="Search For Booking By Email" />
    <asp:Panel ID="panelRegisterNewCustomer" runat="server" Height="148px" BorderStyle="Solid" Width="1067px">
        <br />
        <asp:Label ID="Label7" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label8" runat="server" Text="Email:  "></asp:Label>
        &nbsp;<asp:TextBox ID="txtEmail0" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        &nbsp;&nbsp;
        <asp:Button ID="btnRegisterNewCustomerCANCEL" runat="server" OnClick="btnRegisterNewCustomerCANCEL_Click" Text="Cancel" />
        &nbsp;
        <br />
        <br />
        <asp:Label ID="lblDisplayStatus" runat="server" Text="Status: "></asp:Label>
        &nbsp;<asp:Button ID="btnRegisterNewCustomerEXIT" runat="server" OnClick="btnRegisterNewCustomerEXIT_Click" Text="Proceed" Visible="False" />
    </asp:Panel>
    <p>&nbsp;</p>
    <asp:Panel ID="panelCheckDatesAreAvailable" runat="server" Height="262px" BorderStyle="Solid">
        <asp:Label ID="Label9" runat="server" Text="Please select dates to check availability."></asp:Label>
        <br />
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" style="float:left"></asp:Calendar>
        <asp:Button ID="btnAddDate" runat="server" OnClick="btnAddDate_Click" Text="Add Date(s)" Width="104px" />
        <asp:ListBox ID="lstboxDisplayDates" runat="server" AutoPostBack="True" Height="177px" style="float:right" Width="181px"></asp:ListBox>
        <br />
        <asp:Button ID="btnReloadPage" runat="server" OnClick="btnReloadPage_Click"  Text="Clear Dates" Width="105px" />
        
    </asp:Panel>
        



    <asp:Panel ID="panelNoOfGuests" runat="server" Height="139px" BorderStyle="Solid">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Please enter number of guests: "></asp:Label>
        <asp:TextBox ID="txtNoOfGuests" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCheckAvailability" runat="server" OnClick="btnCheckAvailability_Click" Text="Check Availability" />
        <br />
        <br />
        <asp:Label ID="lblAvailabilityResult" runat="server" Text="Results:"></asp:Label>               
    </asp:Panel>
   
    <asp:Button ID="btnProceedToCreateBookingPanel" runat="server" OnClick="btnCreateAvailabiltyBooking_Click" Text="Create Availabilty Booking" />



    <asp:Panel ID="panelCreateBooking" runat="server" BorderStyle="Solid" Height="108px" Width="1071px">
        <asp:Label ID="Label2" runat="server" Text="Please enter valid email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmitEmail" runat="server" OnClick="btnSubmitEmail_Click" Text="Submit" />
        <br />
        <br />
        <asp:Label ID="lblBookingStatus" runat="server" Text="Status: "></asp:Label>
        <asp:Button ID="btnProceedToAvailability" runat="server" OnClick="btnProceedToAvailability_Click" Text="Proceed" />
       



    </asp:Panel>



    <asp:Panel ID="panelCreateAvailabilityBooking" runat="server" Height="70px" BorderStyle="Solid" Width="1068px">
        <asp:Label ID="Label3" runat="server" Text="Retrieve Booking ID:"></asp:Label>
        <br />
        <asp:Label ID="lblFinalAvailabilityDisplay" runat="server" Text="Status:  "></asp:Label>
        <br />
        <asp:Button ID="btnRetrieveBookingID" runat="server" Text="Retrieve BookingID" OnClick="btnRetrieveBookingID_Click_Click" />
        <asp:Button ID="btnProceedToAvailLast" runat="server" OnClick="btnProceedToAvailLast_Click" Text="Proceed" Visible="False" />
    </asp:Panel>



    <asp:Panel ID="panelCreateAvailLast" runat="server" BorderStyle="Solid" Height="118px" Width="1068px">
        <asp:Label ID="Label4" runat="server" Text="Create Availability (LAST):"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblAvailabilityStatus" runat="server" Text="Status: "></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnCreateAvailLAST" runat="server" OnClick="btnCreateAvailLAST_Click" Text="Create Final Availability Booking" />
        <asp:Button ID="btnBookingCompleteEXIT" runat="server" OnClick="btnBookingCompleteEXIT_Click" Text="Booking Complete - EXIT" Visible="False" />
    </asp:Panel>
    <asp:Panel ID="panelSearchForBookingByEmail" runat="server" BorderStyle="Solid" Height="118px" Width="1069px">
        <asp:Label ID="Label5" runat="server" Text="Search for Booking by Email: "></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Please enter email used to make booking: "></asp:Label>
        <asp:TextBox ID="txtEmailForBookingSearch" runat="server" Width="182px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmitEmailSearch" runat="server" OnClick="btnSubmitEmailSearch_Click" Text="Search For Booking" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnlSearchForBookingByEmailEXIT" runat="server" OnClick="btnlSearchForBookingByEmailEXIT_Click" Text="EXIT" />
        <br />
        <br />
    </asp:Panel>
    <asp:GridView ID="dataGridViewBookingSearch" runat="server">
    </asp:GridView>



</asp:Content>
