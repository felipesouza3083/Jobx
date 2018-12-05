app.controller(
    'funcionario-cadastro-controller',
    function ($scope, $http, $window) {
        $scope.funcionario = {
            Matricula: '', Nome: '', Telefone: '', DataNascimento: ''
        };

        $scope.cadastrarFuncionario = function () {
            $scope.mensagem = "Processando requisição, por favor aguarde.";
            debugger;
            var dados = $scope.funcionario;

            $http({
                method: "POST",
                url: 'http://localhost:50787/jobx/funcionario/cadastrarfuncionario',
                data: dados,
                headers: { 'Authorization': 'Bearer ' + $window.sessionStorage.token }
            })
                .then(function (d) {
                    $scope.mensagem = d.data;

                    $scope.funcionario = {
                        Matricula: '', Nome: '', Telefone: '', DataNascimento: ''
                    };
                })
                .catch(function (e) {
                    if (e.status === 400) {
                        $scope.erros = e.data;

                        $scope.mensagem = "";
                    }
                    else {
                        $scope.mensagem = e.data;
                    }
                });
        };
    }
);