<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FunctionMenuList.ascx.cs" 
	Inherits="ERPManagement.Controls.FunctionMenuList" %>

<asp:Repeater ItemType="ERPManagement.Models.FuncMenu" SelectMethod="GetFunctionMenu" runat="server">
	<ItemTemplate>
		<a href="/<%# Item.UrlSection %>" ><%# Item.Name %></a>
	</ItemTemplate>
</asp:Repeater>
