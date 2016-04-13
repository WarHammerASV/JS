<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoolParameterControl.ascx.cs" Inherits="JScntrl.BoolParameterControl" %>

<div runat="server">
    <fieldset id="border">
        <legend id="paramType"><asp:Label ID="parType" runat="server"></asp:Label></legend><br />

        <asp:Label text="ID= " runat="server"></asp:Label>
        <asp:Label ID="Id" runat="server"></asp:Label><br />

        <asp:Label text="Name= " runat="server"></asp:Label>
        <asp:Label ID="Name" runat="server"></asp:Label><br />

        <asp:Label text="Description= " runat="server"></asp:Label>
        <asp:Label ID="Description" runat="server"></asp:Label><br /><br />

        <asp:CheckBox ID="Value" runat="server"></asp:CheckBox>
        
    </fieldset>
</div>
