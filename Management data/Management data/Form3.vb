Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Form3
    Dim DataAdapter As MySqlDataAdapter
    Dim Dset As DataSet
    Dim Source1 As New BindingSource




    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection("server=127.0.0.1; username=root ;password=''; database=systemdatabase;")
        Try
            conn.Open()

            Dset = New DataSet
            DataAdapter = New MySqlDataAdapter("SELECT * FROM student_information", conn)
            DataAdapter.Fill(Dset, "student_information")

            If Dset.Tables.Count > 0 Then
                Dim View As New DataView(Dset.Tables(0))
                Source1.DataSource = View
                DataGridView1.DataSource = Source1
            End If

            If conn.State = ConnectionState.Open Then
                MessageBox.Show("Connected")
            Else
                MessageBox.Show("Not connected")
            End If
        Catch ex As Exception
            MessageBox.Show("Not Connected")
        Finally
            conn.Close()

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection("server=127.0.0.1; username=root; password=''; database=systemdatabase; port=3306;")

        Dset = New DataSet
        DataAdapter = New MySqlDataAdapter("SELECT * FROM student_information", conn)
        DataAdapter.Fill(Dset, "student_information")
        Try
            conn.Open()
            Dim query As String = "INSERT INTO student_information ( First name:, MIddle name:,Last name:, Age, Phone no., Email:, LRN:, Year Level:, Home Address:, Date of Birth:)  VALUES (@First name:, @MIddle name:, @Last name:, @Age, @Phone no., @Email:, @ LRN:, @Year Level:, @Home Address:, @Date of Birth:)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@First name:", TextBox1.Text)
            cmd.Parameters.AddWithValue("@MIddle name:", TextBox2.Text)
            cmd.Parameters.AddWithValue("@Last name:", TextBox3.Text)
            cmd.Parameters.AddWithValue("@Age", TextBox4.Text)
            cmd.Parameters.AddWithValue("@Phone no.", TextBox5.Text)
            cmd.Parameters.AddWithValue("@Email:", TextBox9.Text)
            cmd.Parameters.AddWithValue("@LRN:", TextBox8.Text)
            cmd.Parameters.AddWithValue("@Year Level:", TextBox7.Text)
            cmd.Parameters.AddWithValue("@Home Address:", TextBox6.Text)
            cmd.Parameters.AddWithValue("@Date of Birth:", DataPickerView1.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Record saved succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim form4 As New Form4()
        form4.DataGridView1Public.DataSource = Source1
        form4.Show()
    End Sub
End Class