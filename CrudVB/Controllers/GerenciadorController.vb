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
            Return View() ' Retorna um objeto do tipo Autenticacao para a view Login
        End Function

        ' POST: Gerenciador/Login
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Login(ByVal autenticacao As Autenticacao) As ActionResult
            If ModelState.IsValid Then
                ' Procura pela autenticação do usuário
                Dim usuarioAutenticado = db.Usuarios.FirstOrDefault(Function(u) u.Email = autenticacao.Email AndAlso u.Senha = autenticacao.Senha)

                If usuarioAutenticado IsNot Nothing Then
                    ' Define o cookie de autenticação com o ID do usuário
                    FormsAuthentication.SetAuthCookie(usuarioAutenticado.Id.ToString(), False)
                    Return RedirectToAction("Index", "Gerenciador")
                Else
                    ModelState.AddModelError("", "Email ou senha inválidos.")
                End If
            End If

            ' Se houver erros de validação ou autenticação, retorna para a view com o modelo de autenticação
            Return View(autenticacao)
        End Function


        ' GET: Gerenciador/Registrar
        Function Registrar() As ActionResult
            Return View(New Usuario()) ' Retorna um objeto do tipo Usuario para a view Registrar
        End Function

        ' POST: Gerenciador/Registrar
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Registrar(ByVal usuario As Usuario) As ActionResult
            ' Verifica se o email já está cadastrado
            Dim usuarioExistente = db.Usuarios.FirstOrDefault(Function(u) u.Email = usuario.Email)
            If usuarioExistente IsNot Nothing Then
                ModelState.AddModelError("Email", "Este email já está cadastrado.")
            End If

            If ModelState.IsValid Then
                ' Adiciona o novo usuário ao contexto do Entity Framework
                db.Usuarios.Add(usuario)
                db.SaveChanges()

                ' Redireciona para a página desejada após o registro bem-sucedido
                FormsAuthentication.SetAuthCookie(usuario.Id.ToString(), False)
                Return RedirectToAction("index", "Gerenciador")
            End If

            ' Se houver erros de validação, retorna para a view com o modelo de usuário
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

            ' Verifica se o usuário está autenticado e se tem permissão para editar o perfil
            Dim userId = GetCurrentUserId()
            If userId Is Nothing OrElse id <> userId Then
                Return RedirectToAction("Login")
            End If

            ' Busca o usuário pelo ID
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
                ' Atualiza o usuário no contexto do Entity Framework
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

            ' Verifica se o usuário está autenticado e se tem permissão para deletar o perfil
            Dim userId = GetCurrentUserId()
            If userId Is Nothing OrElse id <> userId Then
                Return RedirectToAction("Login")
            End If

            ' Busca o usuário pelo ID
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
            ' Busca o usuário pelo ID
            Dim usuario As Usuario = db.Usuarios.Find(id)
            If usuario Is Nothing Then
                Return HttpNotFound()
            End If

            ' Remove o usuário do contexto do Entity Framework
            db.Usuarios.Remove(usuario)
            db.SaveChanges()

            ' Caso o usuário excluído seja o próprio que está logado, desloga ele
            If usuario.Id = GetCurrentUserId() Then
                FormsAuthentication.SignOut()
            End If

            Return RedirectToAction("Login")
        End Function

        ' GET: Gerenciador/Index
        <Authorize>
        Function Index() As ActionResult
            ' Obtém o ID do usuário atualmente logado
            Dim userId = GetCurrentUserId()

            ' Verifica se o ID do usuário é válido
            If userId Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            ' Consulta o usuário no banco de dados
            Dim usuario As Usuario = db.Usuarios.Find(userId)

            ' Verifica se o usuário foi encontrado
            If usuario Is Nothing Then
                Return HttpNotFound()
            End If

            ' Retorna a View Index com o modelo do usuário
            Return View(usuario)
        End Function

        ' Método para obter o ID do usuário atualmente logado
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
