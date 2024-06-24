Imports System.Web.Mvc
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class DashboardController
        Inherits Controller

        Private db As New UserContext

        ' GET: Dashboard
        <Authorize>
        Function Index() As ActionResult
            
            Dim userId As String = User.Identity.GetUserId()


            Dim usuario As Autenticacao = db.Autenticacao.SingleOrDefault(Function(u) u.Id = userId)

            If usuario Is Nothing Then
                Return HttpNotFound()
            End If
            ' Retorna a view com os detalhes do usuário logado
            Return View(usuario)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
