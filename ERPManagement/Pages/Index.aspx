<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" MasterPageFile="~/Pages/Masters/ERPMMaster.master" 
	Inherits="ERPManagement.Pages.Index" %>

<asp:Content ContentPlaceHolderID="ContentHolder" runat="server">
	<div class="content">
		Content
	</div>
	<div>
		<ul>
			<asp:Repeater SelectMethod="getConfigData" ItemType="System.String" runat="server" >
				<ItemTemplate>
					<li><%# Item %></li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</div>
</asp:Content>