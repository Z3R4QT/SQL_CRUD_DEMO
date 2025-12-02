Imports System.Windows.Forms.VisualStyles
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

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        Dim Query As String = "SELECT * FROM crud_demo_db.`students_tbl`;"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=crud_demo_db;")
                Dim adapter As New MySqlDataAdapter(Query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table
                DataGridView1.Columns("id").Visible = False
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtName.Text = selectedRow.Cells("Name").Value.ToString()
            txtAge.Text = selectedRow.Cells("Age").Value.ToString()
            txtEmail.Text = selectedRow.Cells("Email").Value.ToString()
            txtHiddenID.Text = selectedRow.Cells("id").Value.ToString()
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim query As String = "UPDATE `crud_demo_db`.`students_tbl` 
                                SET `name` = @name, 
                                `age` = @age, 
                                `email` = @email 
                                WHERE (`id` = @id);"

        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=crud_demo_db;")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@age", CInt(txtAge.Text))
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                    cmd.Parameters.AddWithValue("@id", CInt(txtHiddenID.Text))
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Record updated successfully!")
                    txtName.Clear()
                    txtAge.Clear()
                    txtEmail.Clear()
                    txtHiddenID.Clear()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Dim query As String = "DELETE FROM `crud_demo_db`.`students_tbl` WHERE (`id` = @id);"
        Dim query As String = "UPDATE `crud_demo_db`.`students_tbl` 
                                SET is_deleted = 1
                                WHERE (`id` = @id);"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=crud_demo_db;")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", CInt(txtHiddenID.Text))
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Record deleted successfully!")
                    txtName.Clear()
                    txtAge.Clear()
                    txtEmail.Clear()
                    txtHiddenID.Clear()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
