@ModelType CrudVB.Usuario

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Excluir Conta - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <h2>Excluir Conta</h2>
        <h3>Você tem certeza que deseja excluir sua conta?</h3>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">@Model.Nome</h3>
            </div>
            <div class="panel-body">
                <p><strong>Email:</strong> @Model.Email</p>
            </div>
        </div>
            @Html.BeginForm()
            @Html.AntiForgeryToken()
        <div Class="form-group">
                <input type = "submit" value="Excluir" Class="btn btn-danger" />
                @Html.ActionLink("Cancelar", "Index", "Gerenciador", Nothing, New With {.class = "btn btn-default"})
            </div>
      
    </div>
    <script src="~/Scripts/jquery-3.6.0.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
