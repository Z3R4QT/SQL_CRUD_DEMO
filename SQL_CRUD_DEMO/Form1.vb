Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand



    Private Sub btnConnect1_Click(sender As Object, e As EventArgs) Handles btnConnect1.Click

        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost; userid=root; password=root; database=crud_demo_db;"

        Try
            conn.Open()
            MessageBox.Show("Connection Successful")
        Catch ex As MySqlException
            MessageBox.Show("Connection Failed: " & ex.Message)
            conn.Close()
        End Try


    End Sub
End Class
