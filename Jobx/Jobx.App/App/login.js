//criando o controller de autenticação..
app.controller('authController',
    function ($scope, $http, $window) {

        //criando a função para autenticar o usuario..
        $scope.autenticar = function () {

            //exibir mensagem..
            $scope.mensagem = "Autenticando usuario, aguarde.";

            //resgatar os dados da página e monta-los para envio..
            var dados = "grant_type=password" + "&username=" + $scope.model.email + "&password=" + $scope.model.senha;

            //fazer chamada ao serviço..
            $http.post("http://localhost:50787/jobx/token", dados,
                {
                    header: { 'Content-Type': 'application/x-www-form-urlencoded' }
                })
                .then(function successCallback(msg) {
                    debugger;
                    //gravar o token em sessão..
                    $window.sessionStorage.token = msg.data.access_token;

                    //redirecionar..
                    $window.location.href = "/index.html";
                },
                function errorCallback(e) {
                    $scope.mensagem = "Acesso Negado";
                });
        };
    });