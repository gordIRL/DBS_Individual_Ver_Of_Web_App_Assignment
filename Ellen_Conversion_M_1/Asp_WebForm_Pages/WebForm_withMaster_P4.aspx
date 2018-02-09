<%@ Page Title="" Language="C#" MasterPageFile="~/WebFormsMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm_withMaster_P4.aspx.cs" Inherits="Ellen_Conversion_M_1.WebForm_withMaster_P4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Page Four</h1>
    
    <%--<asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>--%>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    <asp:Button ID="Button1" runat="server" Text="Add Date" OnClick="Button1_Click" />
    <asp:Button ID="BtnReloadPage" runat="server" Text="ReLoad Page" OnClick="BtnReloadPage_Click" />
   <%-- <asp:Calendar ID="Calendar1" runat="server" 
        BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" 
        NextPrevFormat="FullMonth" 
        ShowGridLines="True"

        OnSelectionChanged="Calendar1_SelectionChanged"
        
        SelectionMode="Day" 
        
        
        Width="715px">


        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />       
    </asp:Calendar>--%>



<%--OnPreRender="Calendar1_PreRender"--%>


    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" 
            Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px"
                NextPrevFormat="ShortMonth"  Width="330px" 

        
        OnSelectionChanged="Calendar1_SelectionChanged" BorderStyle="Solid" 
            CellSpacing="1">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                    Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="#333399" Font-Bold="True"
                    Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>

         <br />
         <br />
         <%--<asp:Button runat="server" ID="btnGetSelectedDate" Text="Get Selected Date" 
            onclick="btnGetSelectedDate_Click" /> &nbsp;&nbsp;&nbsp;<br />--%>
         
    
    <b>Selected Dates : </b><asp:Label runat="server" ID="lblDate" ></asp:Label>
  


</asp:Content>
