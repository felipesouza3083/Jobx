app.controller(
    'atividades-cadastro-controller',
    function ($scope, $http, $window) {

        $scope.atividade = {
            Nome: '', DataAtividade: '', IdFuncionario: 0
        };

        $scope.consultaFuncionario = function () {

            $http({
                method: 'GET',
                url: 'http://localhost:50787/jobx/funcionario/listartodosfuncionarios',
                headers: {
                    'Authorization': 'Bearer ' + $window.sessionStorage.token
                },
                data: ''
            }).then(function (d) {

                $scope.funcionarios = d.data;
            }).catch(function (e) {

                $scope.mensagem = e.data;
            });
        };
        $scope.funcionarios = $scope.consultaFuncionario();

        $scope.cadastrarAtividade = function () {
            $scope.mensagem = "Processando o cadastro...";

            var dados = $scope.atividade;
            $http({
                method: 'POST',
                url: 'http://localhost:50787/jobx/atividade/cadastraratividade',
                headers: {
                    'Authorization': 'Bearer ' + $window.sessionStorage.token
                },
                data: dados
            }).then(function (d) {
                $scope.mensagem = d.data;

                $scope.atividade = {
                    Nome: '', DataAtividade: '', IdFuncionario: 0
                };
            }).catch(function (e) {
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