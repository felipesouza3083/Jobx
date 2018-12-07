var app = angular.module('app', ['ngRoute']);

app.config(
    function ($routeProvider) {
        $routeProvider
            .when(
                '/funcionario/cadastro',
                {
                    templateUrl: '/App/Views/Funcionario/Cadastro.html',
                    controller: 'funcionario-cadastro-controller'
                }
            )
            .when(
                '/funcionario/consulta',
                {
                    templateUrl: '/App/Views/Funcionario/Consulta.html',
                    controller: 'funcionario-consulta-controller'
                }
            )
            .when(
                '/atividades/cadastro',
                {
                    templateUrl: '/App/Views/Atividades/cadastro.html',
                    controller:'atividades-cadastro-controller'
            }
        ).when(
            '/atividades/consulta',
            {
                templateUrl: '/App/Views/Atividades/consulta.html',
                controller: 'atividades-consulta-controller'
            }
        );
    }
);

app.config(function ($locationProvider) {
    $locationProvider.hashPrefix('');
});