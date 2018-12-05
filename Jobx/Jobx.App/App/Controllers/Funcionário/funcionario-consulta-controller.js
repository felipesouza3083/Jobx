app.controller(
    'funcionario-consulta-controller',
    function ($scope, $http, $window) {

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

        $scope.atualizarFuncionario = function (id) {
            alert(id);
        };
    }
);