<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="_313ProjectFinal.search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Choose a Method to Search by...</h1>
    <br />
    *results are at the bottom of the page<br />

    <fieldset>
        <legend>Search By Name</legend>
        <br />
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnName" runat="server" BorderWidth="2px" OnClick="name_Click" Text="Search" />

    </fieldset>
    <br />
    <br />

    <%-- Fieldsets separate search options --%>
    <%-- list boxes where applicable --%>
    <fieldset>
        <legend>Search By Type</legend>

        <br />
        <asp:ListBox ID="type" runat="server" Height="121px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
            <asp:ListItem Value="Pistol" Selected="True">Pistol</asp:ListItem>
            <asp:ListItem Value="Sniper">Sniper</asp:ListItem>
            <asp:ListItem Value="Shotgun">Shotgun</asp:ListItem>
            <asp:ListItem Value="Rocket Launcher">Rocket Launcher</asp:ListItem>
            <asp:ListItem Value="SMG">SMG</asp:ListItem>
            <asp:ListItem Value="Assault Rifle">Assault Rifle</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnType" runat="server" BorderWidth="2px" OnClick="type_Click" Text="Search" />

    </fieldset>
    <br />
    <br />

    <fieldset>
        <legend>Search By Element</legend>
        <br />
        <asp:ListBox ID="ele" runat="server" Height="119px">
            <asp:ListItem Value="Fire">Fire</asp:ListItem>
            <asp:ListItem Value="Corrosive">Corrosive</asp:ListItem>
            <asp:ListItem>Shock</asp:ListItem>
            <asp:ListItem Value="Cryo">Cryo</asp:ListItem>
            <asp:ListItem Value="Radiation">Radiation</asp:ListItem>
            <asp:ListItem Selected="True" Value="None">None</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnEle" runat="server" BorderWidth="2px" OnClick="ele_Click" Text="Search" />

    </fieldset>
    <br />
    <br />

    <fieldset>
        <legend>Search By Alien Barrel</legend>

        <br />
        <asp:ListBox ID="alien" runat="server" Height="47px">
            <asp:ListItem>Y</asp:ListItem>
            <asp:ListItem Selected="True">N</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnAl" runat="server" BorderWidth="2px" OnClick="al_Click" Text="Search" />

    </fieldset>
    <br />
    <br />
    
    &nbsp;<br />
    <br />
    <h1>Results</h1>
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" BorderColor="Orange">
        <RowStyle BorderColor="Orange" />
        <SelectedRowStyle BorderColor="Orange" />
        <SortedAscendingCellStyle BorderColor="Orange" />
        <SortedDescendingCellStyle BorderColor="Orange" />
    </asp:GridView>
    <br />

</asp:Content>
