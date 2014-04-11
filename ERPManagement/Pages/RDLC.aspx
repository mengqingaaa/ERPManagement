<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RDLC.aspx.cs" MasterPageFile="~/Pages/Masters/ERPMMaster.master" 
	Inherits="ERPManagement.Pages.RDLC" %>

<%@ Register TagPrefix="MQ" TagName="CustomerList" Src="~/Controls/CustomerList.ascx" %>

<asp:Content ContentPlaceHolderID="ContentHolder" runat="server">
	<div class="content">
		<MQ:CustomerList runat="server" />
	</div>
</asp:Content>