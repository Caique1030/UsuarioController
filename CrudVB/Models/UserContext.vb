
Imports System.Data.Entity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class UserContext
    Inherits IdentityDbContext(Of Usuario)

    Public Sub New()
        MyBase.New("UsuarioController")
        Database.SetInitializer(Of UserContext)(New MigrateDatabaseToLatestVersion(Of UserContext, Configuration)())
    End Sub

    Public Property Autenticacao As DbSet(Of Autenticacao)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
    End Sub
End Class


