<%@ Page Title="" Language="C#" MasterPageFile="~/WebFormsMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm_with_Master_P5.aspx.cs" Inherits="Ellen_Conversion_M_1.Asp_WebForm_Pages.WebForm_with_Master_P5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Page Five</h1>
    <p>&nbsp;</p>
    <p>
        <asp:Button ID="btnPanelCreateCustomer_Show" runat="server" OnClick="btnPanelCreateCustomer_Click" Text="Create Customer - Show" Width="222px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCreateBooking_Show" runat="server"  Text="Create Booking - Show" OnClick="btnCreateBooking_Show_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPan3_RetrieveAvail_Show" runat="server" OnClick="btnPan3_RetrieveAvail_Show_Click" Text="RetrieveAvailability - Show" />
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>&nbsp;</p>
    <asp:Panel ID="pan1_Create_Customer" runat="server" BorderStyle="Solid" Height="96px" Width="1047px">
        <asp:Label ID="lblCreateCustomerHeader" runat="server" Text="Create New Customer:"></asp:Label>
        <br />
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblNoOfGuests" runat="server" Text="No of Guests: " Visible="False"></asp:Label>
        <asp:TextBox ID="txtNoOfGuests" runat="server" Width="57px" Visible="False"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNewCustomer" runat="server" OnClick="btnNewCustomer_Click" Text="Submit" />
        <br />
        &nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="New Customer created:  "></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDisplay1" runat="server" BorderStyle="None"></asp:Label>
    </asp:Panel>



    <br />
    <br />
    <asp:Panel ID="pan2_CreateBooking" runat="server" BorderStyle="Solid" Height="121px" Width="1050px">
        <asp:Label ID="Label3" runat="server" Text="Create basic booking using existing email:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter Valid / Existing Email:  "></asp:Label>
        <asp:TextBox ID="txtEmailCreateBooking" runat="server"></asp:TextBox>
        <asp:Button ID="btnClearBooking" runat="server" OnClick="btnClearBooking_Click" Text="Clear" />
        <asp:Button ID="btnCreateBooking" runat="server" OnClick="btnCreateBooking_Click" Text="Create Booking" />
        <br />
        <br />
        <asp:Label ID="lblBookingStatus" runat="server" Text="Status:"></asp:Label>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel2" runat="server" Width="1130px">
        <asp:ListBox ID="ListBox1" runat="server" Height="105px" Width="1055px" ></asp:ListBox>
        <br />
    </asp:Panel>
    <asp:Panel ID="pan3_RetrieveAvailability" runat="server" BorderStyle="Solid" Height="97px" Width="1061px">
        <asp:Label ID="Label4" runat="server" Text="Retrieve Availability Booking:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Enter email associated with Availability: "></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtRetrieveAvailability" runat="server" Width="176px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRetrieveAll" runat="server" OnClick="btnRetrieveAll_Click1" Text="RetrieveAll" />
    </asp:Panel>
    <br />
    <asp:GridView ID="dataGridView_Page_5" runat="server">
    </asp:GridView>
    <br />
    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" Height="139px" Width="1071px">
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
        <asp:Button ID="btnBookAvailability" runat="server" OnClick="btnBookAvailability_Click" Text="Book Availability" />
        <br />
        <br />
        <asp:Label ID="lblAvailabilityStatus" runat="server" Text="Status: "></asp:Label>
        <asp:Label ID="lbAvailabilityStatus" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
    <br />
    <asp:Button ID="btnRandomness" runat="server" OnClick="btnRandomness_Click" Text="AddRandomness !!" />
&nbsp;
    <asp:Button ID="btnClearListBoxAvailability" runat="server" OnClick="btnClearListBoxAvailability_Click" Text="Clear ListBoxAvailability" Width="144px" />
    <br />
    <br />
    <asp:ListBox ID="lstBoxAvailability" runat="server" Height="92px" Width="815px"></asp:ListBox>
    <br />
    <br />
    <asp:Calendar ID="Calendar1" runat="server"
        OnSelectionChanged="Calendar1_SelectionChanged"
        OnDayRender="Calendar1_DayRender">
        
    </asp:Calendar>



    <asp:Button ID="btnAddDate" runat="server" OnClick="btnAddDate_Click" Text="Add Date(s)" />
    <asp:Button ID="btnReloadPage" runat="server" Text="Clear Dates" OnClick="btnReloadPage_Click" />
    <br />
    <asp:Label ID="lblSelectedDates" runat="server" Text="Selected Dates:"></asp:Label>
    <br />
    <asp:ListBox ID="lstboxDisplayDates" runat="server" AutoPostBack="True" Height="146px" Width="181px"></asp:ListBox>
    <br />



</asp:Content>
