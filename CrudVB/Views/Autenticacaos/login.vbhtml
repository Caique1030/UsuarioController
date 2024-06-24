﻿@ModelType CrudVB.Autenticacao

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Bem Vindo! </title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
</head>
<body>
    <div class="container">
        <h2>Faça o Login</h2>

        @Html.BeginForm("login", "Autenticacaos", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()

        <div Class="form-group">
                @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "col-md-2 control-label"})
                <div Class="col-md-10">
                @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div Class="form-group">
                @Html.LabelFor(Function(model) model.Senha, htmlAttributes:=New With {.class = "col-md-2 control-label"})
                <div Class="col-md-10">
                @Html.PasswordFor(Function(model) model.Senha, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Senha, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div Class="form-group">
                <div Class="col-md-offset-2 col-md-10">
                    <Button type = "submit" Class="btn btn-default">Login</button>
                    @Html.ActionLink("Registre-se", "registrar", "Autenticacaos", Nothing, New With {.class = "btn btn-default"})
                </div>
            </div>
    </div>

    <script src="~/Scripts/jquery-3.6.0.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>