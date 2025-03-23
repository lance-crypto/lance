Imports MySql.Data.MySqlClient
Public Class Form4
    Public Property DataGridView1Public As DataGridView
        Get
            Return DataGridView1
        End Get
        Set(value As DataGridView)
            DataGridView1 = value
        End Set
    End Property

    Dim conn As New MySqlConnection("server=127.0.0.1; username=root ;password=;database=systemdatabase")
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DataGridView1
            .Columns(0).Name = "LRN"
            .Columns(1).Name = "First Name"
            .Columns(2).Name = "Middle Name"
            .Columns(3).Name = "Last Name"
            .Columns(4).Name = "Age"
            .Columns(5).Name = "Email"
            .Columns(6).Name = "Phone Number"
            .Columns(7).Name = "Home Address"
            .Columns(8).Name = "Year Level"
        End With
    End Sub
End Class