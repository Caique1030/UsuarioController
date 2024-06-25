@ModelType CrudVB.Usuario

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
</head>
<body>
    <div class="container">
        <h2>Dashboard</h2>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Bem-vindo, @Model.Nome</h3>
            </div>
            <div class="panel-body">
                <p><strong>Email:</strong> @Model.Email</p>
                <!-- Adicione mais detalhes do usuário aqui, se necessário -->
            </div>
        </div>
        <div>
            <a href="@Url.Action("Editar", New With {.id = Model.Id})" class="btn btn-primary">Editar</a> |
            <a href="@Url.Action("Deletar", New With {.id = Model.Id})" class="btn btn-danger" onclick="return confirm('Tem certeza que deseja excluir sua conta?')">Excluir</a> |
            @Html.ActionLink("Logout", "Logout", "Gerenciador", Nothing, New With {.class = "btn btn-default"})
        </div>
    </div>
    <script src="~/Scripts/jquery-3.6.0.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
