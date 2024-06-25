Imports System.Data.Entity
Imports System.Net
Imports System.Web.Mvc
Imports System.Web.Security
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class GerenciadorController
        Inherits Controller

        Private db As New UserContext

        ' GET: Gerenciador/Login
        Function Login() As ActionResult
            Return View()
        End Function

        ' POST: Gerenciador/Login
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Login(ByVal autenticacao As Autenticacao) As ActionResult
            If ModelState.IsValid Then
                Dim usuarioAutenticado = db.Usuarios.FirstOrDefault(Function(u) u.Email = autenticacao.Email)

                If usuarioAutenticado IsNot Nothing Then
                    If usuarioAutenticado.Senha = autenticacao.Senha Then
                        FormsAuthentication.SetAuthCookie(usuarioAutenticado.Id.ToString(), False)
                        Return RedirectToAction("Index", "Gerenciador")
                    Else
                        ModelState.AddModelError("", "Senha incorreta.")
                    End If
                Else
                    ModelState.AddModelError("", "Usuário não cadastrado.")
                End If
            End If
            Return View(autenticacao)
        End Function



        ' GET: Gerenciador/Registrar
        Function Registrar() As ActionResult
            Return View(New Usuario())
        End Function

        ' POST: Gerenciador/Registrar
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Registrar(ByVal usuario As Usuario) As ActionResult
            Dim usuarioExistente = db.Usuarios.FirstOrDefault(Function(u) u.Email = usuario.Email)
            If usuarioExistente IsNot Nothing Then
                ModelState.AddModelError("Email", "Este email já está cadastrado.")
            End If

            If ModelState.IsValid Then
                db.Usuarios.Add(usuario)
                db.SaveChanges()
                FormsAuthentication.SetAuthCookie(usuario.Id.ToString(), False)
                Return RedirectToAction("index", "Gerenciador")
            End If
            Return View(usuario)
        End Function


        <Authorize>
        Function Logout() As ActionResult
            FormsAuthentication.SignOut()
            Return RedirectToAction("index", "Home")
        End Function

        ' GET: Gerenciador/Editar/5
        Function Editar(ByVal id As Integer?) As ActionResult
            If id Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim userId = GetCurrentUserId()
            If userId Is Nothing OrElse id <> userId Then
                Return RedirectToAction("Login")
            End If
            Dim usuario As Usuario = db.Usuarios.Find(id)
            If usuario Is Nothing Then
                Return HttpNotFound()
            End If

            Return View(usuario)
        End Function

        ' POST: Gerenciador/Editar/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Editar(ByVal usuario As Usuario) As ActionResult
            If ModelState.IsValid Then
                db.Entry(usuario).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(usuario)
        End Function

        ' GET: Gerenciador/Deletar/5
        Function Deletar(ByVal id As Integer?) As ActionResult
            If id Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim userId = GetCurrentUserId()
            If userId Is Nothing OrElse id <> userId Then
                Return RedirectToAction("Login")
            End If
            Dim usuario As Usuario = db.Usuarios.Find(id)
            If usuario Is Nothing Then
                Return HttpNotFound()
            End If

            Return View(usuario)
        End Function

        ' POST: Gerenciador/Deletar/5
        <HttpPost()>
        <ActionName("Deletar")>
        <ValidateAntiForgeryToken()>
        Function ConfirmDelete(ByVal id As Integer) As ActionResult
            Dim usuario As Usuario = db.Usuarios.Find(id)
            If usuario Is Nothing Then
                Return HttpNotFound()
            End If
            db.Usuarios.Remove(usuario)
            db.SaveChanges()
            If usuario.Id = GetCurrentUserId() Then
                FormsAuthentication.SignOut()
            End If

            Return RedirectToAction("Login")
        End Function

        ' GET: Gerenciador/Index
        <Authorize>
        Function Index() As ActionResult
            Dim userId = GetCurrentUserId()
            If userId Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuarios.Find(userId)
            If usuario Is Nothing Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        Private Function GetCurrentUserId() As Integer?
            Dim userId As Integer
            If User.Identity.IsAuthenticated AndAlso Integer.TryParse(User.Identity.Name, userId) Then
                Return userId
            End If
            Return Nothing
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class


End Namespace
