<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppMaker.aspx.cs" Inherits="NSCC.Web.Awards.Application.Tests.AppMaker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel runat="server" ID="pnlMessage" Visible="False" BackColor="LightGreen">
        <p>Success!</p>
    </asp:Panel>
    <div>
        Submission Id: <asp:TextBox runat="server" ID="tbSubmissionId" />
        <br/>
        Award Code: <asp:TextBox runat="server" ID="tbAwardCode" />
        <br/>
        Desired Filename: <asp:TextBox runat="server" ID="tbFilename" Width="200" />
        <br/>
        <asp:Button runat="server" ID="btnGenerate" OnClick="btnGenerate_Click" Text="Generate PDF"/>
    </div>
    </form>
</body>
</html>
