<% Response.ContentType = "text/vnd.wap.wml" %><?xml version="1.0" encoding="iso-8859-1"?>
<!DOCTYPE wml PUBLIC "-//WAPFORUM//DTD WML 1.1//EN" "http://www.wapforum.org/DTD/wml_1.1.xml">
<wml>

<!-- Esta é a carta(CARD) principal do Baralho (DECK) -->
<card id="MainCard2">
<p align="left"><small>Descrição</small><br/></p>
<%

strconn = "DRIVER=Microsoft Access Driver (*.mdb);DBQ=" & Server.MapPath("BIBLIO.MDB")
set conn = server.createobject("adodb.connection")
conn.open strconn
set rs = server.createobject("adodb.recordset")
id = Request.QueryString("id")

if id=9999 then
	Query = "insert into authors values (9999,'LED','9999')"
	conn.Execute(query)
	
	response.write("<p align='left'><small>LED ACESO.</small></p>")
	
elseif id=8888 then
	Query = "delete from authors where au_id=9999"
	conn.Execute(query)
	
	response.write("<p align='left'><small>LED APAGADO.</small></p>")
	
else
	Query = "Select * from TITLES Where PubId =" & id & " ORDER BY PubId"
	
	rs.open Query, conn
	if not rs.eof Then
	  rs.movefirst
	  Do While NOt Rs.EOF
	  %>
	    <p align="left"><small><b><%=rs("title")%></b></small></p>
	  <%
	  rs.movenext
	  Loop
	else
	  response.write("<p align='left'><small>Não existem registros para o criterio.</small></p>")
	End if

	rs.close
	set rs= nothing
	set conn = nothing
	
end if



%>
<p align="left"><small><a href="editor.asp ">Retorna</a></small></p>
</card>
</wml>