<%@ Page Language="VB" AutoEventWireup="false" CodeFile="wap.aspx.vb" Inherits="wap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<SCRIPT language="JavaScript">
	
		function Atualiza(){
	        document.location.reload();
		}
		
		window.setTimeout('Atualiza()',1000);
	
				
		</SCRIPT>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="Button2" runat="server" Text="LED" BackColor="Red" /><br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="ACENDER LED" /><br />
        <asp:Button ID="Button1" runat="server" Text=" APAGAR LED " /></div>
    </form>
</body>
</html>
