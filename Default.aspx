<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
    </main>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
    <!-- Ülke Adı Girişi -->
    <asp:TextBox ID="txtUlkeAd" runat="server" Placeholder="Ülke adı girin"></asp:TextBox>
    <asp:Button ID="btnAddUlke" runat="server" Text="Ülke Ekle" OnClick="btnAddUlke_Click" />

    <asp:TextBox ID="txtUlkeId" runat="server" placeholder="Silinecek Ulke ID"></asp:TextBox>
    <asp:Button ID="btnDeleteUlke" runat="server" Text="Sil" OnClick="btnDeleteUlke_Click" />

    <br />
    <br />

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true">
    </asp:GridView>


</asp:Content>
