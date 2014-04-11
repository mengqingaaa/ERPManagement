<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlExec.aspx.cs" MasterPageFile="~/Pages/Masters/ERPMMaster.master" 
	Inherits="ERPManagement.Pages.SqlExec" %>

<%@ Register TagPrefix="MQ" TagName="CustomerList" Src="~/Controls/CustomerList.ascx" %>

<asp:Content ContentPlaceHolderID="ContentHolder" runat="server">
	<MQ:CustomerList runat="server" />

	<div id="functionContent" runat="server">
	<% if (this.customerCount == 1) { %>

		<div>
			<span>System Dababase: </span>
			<span><% =this.customers.First().DBSysname %></span>
			<br />
			<span>Business Database: </span>
			<span><% =this.customers.First().DBBizName %></span>
		</div>
		
		<div>
			<asp:FileUpload id="SqlUploader" runat="server" />
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

	<% } // (if this.customerCOunt == 1) %>
	</div>

</asp:Content>