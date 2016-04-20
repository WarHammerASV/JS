<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="JScntrl.CommonParameterControl" %>

<div>
    <fieldset id="border">
        <legend id="paramType"><asp:Label ID="parType" runat="server"></asp:Label></legend><br />

        <asp:Label text="ID= " runat="server"></asp:Label>
        <asp:Label ID="Id" runat="server"></asp:Label><br />

        <asp:Label text="Name= " runat="server"></asp:Label>
        <asp:Label ID="Name" runat="server"></asp:Label><br />

        <asp:Label text="Description= " runat="server"></asp:Label>
        <asp:Label ID="Description" runat="server"></asp:Label><br />

        <asp:Label text="Value= " runat="server"></asp:Label>
        <asp:TextBox ID="Value" runat="server" TextChanged="textChangedEventHandler"></asp:TextBox>
        <br />
    </fieldset>
</div>
<br />