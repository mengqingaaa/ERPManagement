<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FunctionMenuList.ascx.cs" 
	Inherits="ERPManagement.Controls.FunctionMenuList" %>

<ul>
	<asp:Repeater ItemType="ERPManagement.Models.FuncMenu" SelectMethod="GetFunctionMenu" runat="server">
		<ItemTemplate>
			<li>
				<a href="/<%# Item.UrlSection %>" ><%# Item.Name %></a>
			</li>
		</ItemTemplate>
	</asp:Repeater>
</ul>