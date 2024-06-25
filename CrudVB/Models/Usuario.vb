Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Usuario
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property Id As Integer

    Public Property Nome As String
    Public Property Email As String
    Public Property Senha As String
End Class
