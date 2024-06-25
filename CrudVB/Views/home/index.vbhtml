@Code
    ViewData("Title") = "Pagina Inicial"
End Code

<div class="container">
    <div class="jumbotron">
        <h1>Bem Vindo ao Crud!</h1>
        <p class="lead">Este projeto visa em criar novos usuarios , com a possibilidade de Editar, Excluir seu cadastro.</p>
        @* Utilizando ActionLink para criar um link para a página de login *@
        <a href="@Url.Action("login", "Gerenciador")" class="btn btn-primary">Ir para Login</a>
    </div>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Tecnologias Utilizadas</h2>
        <p>ASP.NET MVC</p>
        <p>Entity Framework</p>
        <p>Razor Views</p>
        <p>Bootstrap (para o layout responsivo)</p>
    </div>
    <div class="col-md-4">
        <h2>Funcionalidades Principais</h2>
        <p>Registro de novos usuários</p>
        <p>Login de usuários existentes</p>
        <p>Listagem de credenciais de autenticação</p>
        <p>Edição e exclusão de credenciais de usuários</p>
    </div>
    <div class="col-md-4">
        <h2>GitHub</h2>
        <p>Caso tenha interesse em ver mais projetos como este acesse:</p>
        <p><a class="btn btn-default" href="https://github.com/Caique1030">Clique Aqui &raquo;</a></p>
    </div>
</div>
