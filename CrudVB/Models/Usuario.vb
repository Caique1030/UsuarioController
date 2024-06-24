Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class Usuario
    Inherits IdentityUser
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Overrides Property Id As String
        Get
            Return MyBase.Id
        End Get
        Set(value As String)
            MyBase.Id = value
        End Set
    End Property

    <Required(ErrorMessage:="O campo Nome é obrigatório.")>
    Public Property Nome As String

    <Required(ErrorMessage:="O campo Email é obrigatório.")>
    <EmailAddress(ErrorMessage:="O Email não é válido.")>
    Public Overrides Property Email As String
        Get
            Return MyBase.Email
        End Get
        Set(value As String)
            MyBase.Email = value
        End Set
    End Property

    <Required(ErrorMessage:="O campo Senha é obrigatório.")>
    <StringLength(100, ErrorMessage:="A {0} deve ter pelo menos {2} caracteres de comprimento.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Senha")>
    Public Property Senha As String
End Class
