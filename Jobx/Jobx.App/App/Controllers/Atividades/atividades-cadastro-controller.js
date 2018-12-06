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
    }
);