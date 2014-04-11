<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.ascx.cs" 
	Inherits="ERPManagement.Controls.CustomerList" %>

<div id="cumstomerList">
	<asp:Repeater ItemType="ERPManagement.Models.Customer" SelectMethod="GetCustomers" runat="server">
		<ItemTemplate>
			<div>
				<h3><a href="<%# GetCustomerLink(Item.Code) %>" ><%# Item.Code %></a></h3>
				<h3><%# Item.Name %></h3>
				<h4><%# Item.Version %></h4>
				<h4><%# Item.CustomoerId %></h4>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>

<div id="divErrNotExist" runat="server">
	Sorry, this customer does not exist!<br />
</div>