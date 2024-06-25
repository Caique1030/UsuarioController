Imports System.Data.Entity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class UserContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("DbUsuarios")
        Database.SetInitializer(Of UserContext)(New MigrateDatabaseToLatestVersion(Of UserContext, Configuration)())
    End Sub

    Public Property Usuarios As DbSet(Of Usuario)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
    End Sub
End Class
