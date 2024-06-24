Imports System.ComponentModel.DataAnnotations

Public Class Autenticacao
    <Key>
    Public Property Id As Integer
    Public Property Nome As String
    <Required(ErrorMessage:="O campo Email é obrigatório.")>
    <EmailAddress(ErrorMessage:="O Email não é válido.")>
    <Display(Name:="Email")>
    Public Property Email As String

    <Required(ErrorMessage:="O campo Senha é obrigatório.")>
    <StringLength(100, ErrorMessage:="A {0} deve ter pelo menos {2} caracteres de comprimento.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Senha")>
    Public Property Senha As String
End Class


