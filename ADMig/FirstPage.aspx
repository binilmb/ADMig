<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="ADMig.FirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/jquery-ui.css" />
    <script src="Scripts/jquery-1.12.4.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script>
        $(document).ready(function () {
            $('#txtDtPicker').datepicker();
        });
        function Validate() {
            if ($('#datepicker').val() == '') {
                alert("Please select date");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Logged in User : <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label></p>
            <p>Select Date: <input type="text" id="txtDtPicker" style="position: relative; z-index: 100000;" runat="server" /></p>
            <p><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="return Validate();" /></p>
        </div>
    </form>
</body>
</html>
