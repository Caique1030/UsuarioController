@Imports Microsoft.AspNet.Identity
@Imports CrudVB.Controllers

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Sistema de Usuario</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Crud Caique", "index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav"></ul>
                @If Request.Path.Contains("Gerenciador/Login") Then
                    @<ul class="nav navbar-nav navbar-right">
                        <li>@Html.ActionLink("Pagina Inicial", "index", "home", routeValues:=Nothing, htmlAttributes:=New With {.id = "homeLink"})</li>
                    </ul>

                Else
                    @If Request.IsAuthenticated Then
                        Using Html.BeginForm("Logout", "Gerenciador", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
                            @Html.AntiForgeryToken()
                            @<ul class="nav navbar-nav navbar-right">
                                <li><a href="javascript:document.getElementById('logoutForm').submit()">Log off</a></li>
                            </ul>
                        End Using
                    Else
                        @<ul class="nav navbar-nav navbar-right">
                            <li>@Html.ActionLink("Contato", "contact", "Home", routeValues:=Nothing, htmlAttributes:=New With {.id = "contactLink"})</li>
                            <li>@Html.ActionLink("Sobre", "about", "Home", routeValues:=Nothing, htmlAttributes:=New With {.id = "aboutLink"})</li>
                            <li>@Html.ActionLink("Registrar", "registrar", "Gerenciador", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink"})</li>
                            <li>@Html.ActionLink("Login", "login", "Gerenciador", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
                        </ul>
                    End If
                End If
            </div>
        </div>
    </div>

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Caique Junior Da Silva</p>
        </footer>
    </div>

    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    @RenderSection("scripts", required:=False)
</body>
</html>
