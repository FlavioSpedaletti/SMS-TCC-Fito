Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbConnection

Partial Class wap
    Inherits System.Web.UI.Page

    Dim strConexao As String = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("BIBLIO.MDB"))
    Dim conexao As New OleDbConnection(strConexao)
    Dim Cmd As New OleDbCommand()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strSQL As String = " SELECT * FROM AUTHORS WHERE AU_ID=9999 "

        GridView1.Visible = False

        With Cmd
            .Connection = conexao
            .CommandText = strSQL
        End With

        Try
            'abre a conexão e vincula o resultado da execução do comando a fonte de dados do datagrid 
            conexao.Open()
            GridView1.DataSource = Cmd.ExecuteReader
            GridView1.DataBind()

            If GridView1.Rows.Count > 0 Then
                Button2.BackColor = Color.Green
            Else
                Button2.BackColor = Color.Red
            End If

        Catch ex As Exception
            Response.Write("ex = " & ex.Message)
        Finally
            'Fecha a conexao
            conexao.Close()
        End Try

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strSQL As String = " DELETE FROM AUTHORS WHERE AU_ID=9999 "

        With Cmd
            .Connection = conexao
            .CommandText = strSQL
        End With

        Try
            'abre a conexão e vincula o resultado da execução do comando a fonte de dados do datagrid 
            conexao.Open()
            Cmd.ExecuteNonQuery()
            Response.Write("LED APAGADO COM SUCESSO !")
            Button2.BackColor = Color.Red
        Catch ex As Exception
            Response.Write("ex = " & ex.Message)
        Finally
            'Fecha a conexao
            conexao.Close()
        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim strSQL As String = " INSERT INTO AUTHORS VALUES (9999,'LED','9999') "

        With Cmd
            .Connection = conexao
            .CommandText = strSQL
        End With

        Try
            'abre a conexão e vincula o resultado da execução do comando a fonte de dados do datagrid 
            conexao.Open()
            Cmd.ExecuteNonQuery()
            Response.Write("LED ACESO COM SUCESSO !")
            Button2.BackColor = Color.Green
        Catch ex As Exception
            Response.Write("ex = " & ex.Message)
        Finally
            'Fecha a conexao
            conexao.Close()
        End Try
    End Sub
End Class
