<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="BasicControls.aspx.cs" Inherits="WebApp.SamplePages.BasicControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table align="center" style="width:80%">
        <tr>
            <td align="right></td>
            <td></td>
        </tr>
        <tr>
            <td align="right>
                <asp:Label ID="Label1" runat="server" Text="TextBox"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="SubmitButton" runat="server" OnClick="Button1_Click" Text="Submit Choice" />
            </td>
        </tr>
        <tr>
            <td align="right></td>
            <td></td>
        </tr>
        <tr>
            <td align="right>
                <asp:Label ID="Label2" runat="server" Text="Choice (RadioButtonList)"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">COMP1008</asp:ListItem>
                    <asp:ListItem Value="2">CPSC1517</asp:ListItem>
                    <asp:ListItem Value="3">DMIT2018</asp:ListItem>
                    <asp:ListItem Value="4">DMIT1508</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right></tdalign="right>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right></tdalign="right>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="MessageLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
