Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )

        routes.MapRoute(
            name:="Autenticacao",
            url:="Autenticacao/{action}/{id}",
            defaults:=New With {.controller = "Gerenciador", .action = "Login", .id = UrlParameter.Optional}
        )
        routes.MapRoute(
            name:="GerenciadorIndex",
            url:="Gerenciador/Index",
            defaults:=New With {.controller = "Gerenciador", .action = "Index"}
        )
    End Sub
End Module
