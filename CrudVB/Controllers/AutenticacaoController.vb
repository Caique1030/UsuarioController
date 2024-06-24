Imports System.Data.Entity
Imports System.Net
Imports System.Web.Mvc
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class AutenticacaosController
        Inherits Controller

        Private db As New UserContext

        ' GET: Autenticacaos/login
        Function login() As ActionResult
            Return View("login")
        End Function

        ' POST: autenticacao/login
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function login(ByVal autenticacao As Autenticacao) As ActionResult
            If ModelState.IsValid Then
                Dim usuarioAutenticado = db.Autenticacao.FirstOrDefault(Function(u) u.Email = autenticacao.Email AndAlso u.Senha = autenticacao.Senha)
                If usuarioAutenticado IsNot Nothing Then
                    FormsAuthentication.SetAuthCookie(usuarioAutenticado.Id.ToString(), False)
                    Return RedirectToAction("index", "Dashboard")
                Else
                    ModelState.AddModelError("", "Email ou senha inválidos.")
                End If
            End If
            Return View(autenticacao)
        End Function

        ' GET: Autenticacaos/registrar
        Function registrar() As ActionResult
            Return View("registrar")
        End Function

        ' POST: autenticacao/registrar
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function registrar(<Bind(Include:="Id,Nome,Email,Senha")> ByVal autenticacao As Autenticacao) As ActionResult
            If ModelState.IsValid Then
                db.Autenticacao.Add(autenticacao)
                db.SaveChanges()
                Return RedirectToAction("index", "Dashboard")
            End If
            Return View(autenticacao)
        End Function

        ' GET: autenticacao/editar/5
        Function editar(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            ' Verifica se o usuário está logado
            Dim userId = GetCurrentUserId()
            If userId Is Nothing Then
                Return RedirectToAction("login")
            End If

            ' Verifica se o usuário tenta editar seu próprio cadastro
            If id <> userId Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            End If

            Dim autenticacao As Autenticacao = db.Autenticacao.Find(id)
            If IsNothing(autenticacao) Then
                Return HttpNotFound()
            End If
            Return View(autenticacao)
        End Function

        ' POST: autenticacao/editar/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function editar(<Bind(Include:="Id,Email,Senha")> ByVal autenticacao As Autenticacao) As ActionResult
            If ModelState.IsValid Then
                db.Entry(autenticacao).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("index", "Dashboard")
            End If
            Return View(autenticacao)
        End Function

        ' GET: autenticacao/excluir/5
        Function excluir(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            ' Verifica se o usuário está logado
            Dim userId = GetCurrentUserId()
            If userId Is Nothing Then
                Return RedirectToAction("login")
            End If

            ' Verifica se o usuário tenta excluir seu próprio cadastro
            If id <> userId Then
                Return New HttpStatusCodeResult(HttpStatusCode.Forbidden)
            End If

            Dim autenticacao As Autenticacao = db.Autenticacao.Find(id)
            If IsNothing(autenticacao) Then
                Return HttpNotFound()
            End If
            Return View(autenticacao)
        End Function

        ' POST: autenticacao/excluir/5
        <HttpPost()>
        <ActionName("excluir")>
        <ValidateAntiForgeryToken()>
        Function confirmarExcluir(ByVal id As Integer) As ActionResult
            Dim autenticacao As Autenticacao = db.Autenticacao.Find(id)
            db.Autenticacao.Remove(autenticacao)
            db.SaveChanges()

            ' Se excluir o próprio usuário, faz logout
            Dim userId = GetCurrentUserId()
            If autenticacao.Id = userId Then
                FormsAuthentication.SignOut()
            End If

            Return RedirectToAction("index", "Dashboard")
        End Function

        ' Método para obter o ID do usuário atualmente logado
        Private Function GetCurrentUserId() As Integer?
            Dim userId As Integer
            If User.Identity.IsAuthenticated AndAlso Integer.TryParse(User.Identity.Name, userId) Then
                Return userId
            End If
            Return Nothing
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
