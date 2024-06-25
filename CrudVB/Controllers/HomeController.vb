Imports System.Web.Mvc

Public Class HomeController
    Inherits Controller

    Function index() As ActionResult
        Return View()
    End Function

    Function about() As ActionResult
        ViewData("Message") = "Uma breve descrição sobre mim."

        Return View()
    End Function

    Function contact() As ActionResult
        ViewData("Message") = "Meus contatos."

        Return View()
    End Function


End Class
