@ModelType CrudVB.Autenticacao

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editar Perfil - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <h2>Editar Perfil</h2>
            @Html.BeginForm()
            @Html.AntiForgeryToken()
        <div Class="form-horizontal">
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

                @Html.HiddenFor(Function(model) model.Id)

                <div Class="form-group">
                @Html.LabelFor(Function(model) model.Nome, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div Class="col-md-10">
                @Html.EditorFor(Function(model) model.Nome, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Nome, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div Class="form-group">
                @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div Class="col-md-10">
                @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div Class="form-group">
                @Html.LabelFor(Function(model) model.Senha, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div Class="col-md-10">
                @Html.EditorFor(Function(model) model.Senha, New With {.htmlAttributes = New With {.class = "form-control", .type = "password"}})
                @Html.ValidationMessageFor(Function(model) model.Senha, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div Class="form-group">
                    <div Class="col-md-offset-2 col-md-10">
                        <input type = "submit" value="Salvar" Class="btn btn-primary" />
                    @Html.ActionLink("Cancelar", "Index", "Dashboard", Nothing, New With {.class = "btn btn-default"})
                    </div>
                </div>
            </div>
    </div>
    <script src="~/Scripts/jquery-3.6.0.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
