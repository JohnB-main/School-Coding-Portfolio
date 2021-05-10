<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="submit.aspx.cs" Inherits="_313ProjectFinal.submit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Submit Your Weapon</h1>
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <br />
    <asp:TextBox ID="name" runat="server"></asp:TextBox>
    <br />
        <br />
    <%-- Different Criteria for subbmission; uses listBoxes where it seems logical to (Unlikely to change for the options available) --%>
        Weapon Type<br />
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
        Element<br />
        <asp:ListBox ID="ele" runat="server" Height="119px">
            <asp:ListItem Value="Fire">Fire</asp:ListItem>
            <asp:ListItem Value="Corrosive">Corrosive</asp:ListItem>
            <asp:ListItem>Shock</asp:ListItem>
            <asp:ListItem Value="Cryo">Cryo</asp:ListItem>
            <asp:ListItem Value="Radiation">Radiation</asp:ListItem>
            <asp:ListItem Selected="True" Value="none">None</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        Prefix(s)<br />
    <asp:TextBox ID="pre" runat="server"></asp:TextBox>
        <br />
        <br />
        Alien Barrel<br />
        <asp:ListBox ID="alien" runat="server">
            <asp:ListItem>Y</asp:ListItem>
            <asp:ListItem Selected="True">N</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" BorderWidth="2px" OnClick="Button1_Click" Text="Submit" />
    <br />
    <br />
    <h1><asp:Label ID="status" runat="server" Text="Submit When Ready" BorderWidth="5px" ></asp:Label></h1>
</asp:Content>
