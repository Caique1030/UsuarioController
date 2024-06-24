Imports System.Data.Entity
Imports System.Data.Entity.Migrations

Public Class Configuration
    Inherits DbMigrationsConfiguration(Of UserContext)

    Public Sub New()
        AutomaticMigrationsEnabled = True
        AutomaticMigrationDataLossAllowed = True
    End Sub

    Protected Overrides Sub Seed(context As UserContext)
        ' Aqui você pode adicionar dados iniciais ao banco de dados, se necessário
    End Sub
End Class
