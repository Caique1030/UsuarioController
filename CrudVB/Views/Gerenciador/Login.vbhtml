@ModelType CrudVB.Autenticacao

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Bem Vindo!</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" type="text/css"  />

</head>
<body>
    <div class="container">
        <h2>Realize seu Login</h2>

        @* Utilizando tag helper BeginForm para criar o formulário de login *@
        @Using Html.BeginForm("Login", "Gerenciador", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
            @* Utilizando tag helper AntiForgeryToken para prevenção de CSRF *@
            @Html.AntiForgeryToken()

            @* Inserindo form group para o campo de email *@
            @<div class="form-group">
                @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
                </div>
            </div>

            @* Inserindo form group para o campo de senha *@
            @<div class="form-group password-container">
                @Html.LabelFor(Function(model) model.Senha, htmlAttributes:=New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.PasswordFor(Function(model) model.Senha, New With {.class = "form-control", .id = "senha"})
                    <span class="toggle-password" onclick="togglePassword()">👁️</span>
                    @Html.ValidationMessageFor(Function(model) model.Senha, "", New With {.class = "text-danger"})
                </div>
            </div>

            @* Inserindo form group para os botões de login e registro *@
            @<div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <button type="submit" class="btn btn-default">Login</button>
                    @Html.ActionLink("Registre-se", "Registrar", "Gerenciador", Nothing, New With {.class = "btn btn-default"})
                </div>
            </div>
        End Using
    </div>
    <script src="~/Scripts/jquery-3.6.0.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script src="~/Scripts/togglePassword.js"></script>
</body>
</html>
