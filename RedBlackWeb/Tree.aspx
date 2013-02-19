<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tree.aspx.cs" Inherits="RedBlackWeb.Tree" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Red-Black Tree Web Interface</title>
        <link href="Styles.css" rel="stylesheet" type="text/css" />
    </head>
    <body>

        <h1>Red-Black Tree Web Interface</h1>

        <form id="form1" runat="server">
            <asp:TextBox ID="Values" TextMode="MultiLine" Columns="20" Rows="30" runat="server" /><br />
            <asp:Button ID="SubmitButton" Text="Generate Graph" runat="server" />
            <p><em>Enter one alphanumeric value per line. Add a "-" line to enable "remove mode". Add a "+" line to enable "add mode" again.</em></p>
        </form>

        <asp:Image ID="Graph" runat="server" />

<!--
=== DOT Code Output ===
<asp:Label ID="Code" runat="server" />
-->

    </body>
</html>
