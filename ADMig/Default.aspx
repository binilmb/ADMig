<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADMig.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ShowPage() {
            var winpop = window.open("FirstPage.aspx", "FirstPage", "width=400, height=400, top=200, left=500");
            winpop.focus();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button type="button" onclick="ShowPage();">Launch Page</button>
        </div>
    </form>
</body>
</html>
