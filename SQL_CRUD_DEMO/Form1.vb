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

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        Dim query As String = "INSERT INTO crud_demo_db.`students_tbl` (Name, age, email) VALUES ( @name, @age, @email);"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=crud_demo_db;")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@age", CInt(txtAge.Text))
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Record Insert Successful!")
                    txtName.Clear()
                    txtAge.Clear()
                    txtEmail.Clear()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
