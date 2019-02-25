<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="WebApp.SamplePages.FirstPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Enter your name"></asp:Label>
    &nbsp&nbsp
    <asp:TextBox ID="YourName" runat="server"></asp:TextBox>
    <br/>
    <asp:Button ID="PressMe" runat="server" Text="Press Me" />
    <br />
    <asp:Literal ID="Output" runat="server"></asp:Literal>
</asp:Content>
