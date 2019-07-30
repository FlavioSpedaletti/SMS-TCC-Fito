<% Response.ContentType = "text/vnd.wap.wml" %><?xml version="1.0" encoding="iso-8859-1"?>
<!DOCTYPE wml PUBLIC "-//WAPFORUM//DTD WML 1.1//EN" "http://www.wapforum.org/DTD/wml_1.1.xml">
<wml>

<!-- Esta é a carta(CARD) principal do Baralho (DECK) -->
<card id="MainCard">
<p align="left"><small><b>TESTE WAP(ASP) COM BD ACCESS</b></small></p>
<%

strconn = "DRIVER=Microsoft Access Driver (*.mdb);DBQ=" & Server.MapPath("BIBLIO.MDB")
set conn = server.createobject("adodb.connection")
conn.open strconn
set rs = server.createobject("adodb.recordset")

Query = "Select * from PUBLISHERS Where PubId < 30  ORDER BY PubId"
rs.open Query, conn
if not rs.eof Then
  rs.movefirst
  Do While NOt Rs.EOF
  id = rs("PubId")
  %>
  <!--<p align="left"><small><anchor><%=rs("name")%><go href="titulos.asp?id=<%=id%>"/></anchor></small></p>-->
  <%
  rs.movenext
  Loop
else
  response.write("<p align='left'><small>Não existem registros para o criterio.</small></p>")
End if

rs.close
Set conv = nothing
set rs= nothing
set conn = nothing

%>

<p align="left"><small><anchor>ACENDER LED<go href="titulos.asp?id=9999"/></anchor></small></p>
<p align="left"><small><anchor>APAGAR LED<go href="titulos.asp?id=8888"/></anchor></small></p>

</card>
</wml>