<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlExec.aspx.cs" MasterPageFile="~/Pages/Masters/ERPMMaster.master" 
	Inherits="ERPManagement.Pages.SqlExec" %>

<%@ Register TagPrefix="MQ" TagName="CustomerList" Src="~/Controls/CustomerList.ascx" %>

<asp:Content ContentPlaceHolderID="ContentHolder" runat="server">
	<MQ:CustomerList runat="server" ID="ucCustomerList"/>

	<div id="functionContent" runat="server">
	<% if (customerCount == 1) { %>

		<div>
			<asp:RadioButtonList AutoPostBack="true" OnSelectedIndexChanged="rblDBSelection_SelectedIndexChanged" ID="rblDBSelection" runat="server">
			</asp:RadioButtonList>
		</div>
		
		<div>
			<asp:FileUpload id="fuplSqlUploader" runat="server" />
			<asp:Button id="btnSqlUploader" text="Upload" OnClick="btnSqlUploader_Click" runat="server" />
			<br />
			<asp:Button ID="btnSqlExecution" text="Exec" OnClick="btnSqlExecution_Click" runat="server" />
		</div>

		<div id="uploaderMsg">
			<asp:Label ID="lblUploaderMsg" runat="server"></asp:Label>
		</div>

		<div id="uploadContent">
			<textarea id="txtAreaSqlScriptContent" runat="server"></textarea>
		</div>

		<div id="ExecMsg">
			<asp:Label ID="lblExecuMsg" runat="server"></asp:Label>
		</div>

	<% } // (customerCount == 1) %>
	</div>
	<% =customerCount %>
</asp:Content>