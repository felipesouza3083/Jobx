app.controller('cadController',
    function ($scope, $http) {
        $scope.consultaperfis = function () {

            $http.get('http://localhost:50787/jobx/perfil/listartodosperfis')
                .then(function (d) {
                $scope.perfis = d.data;
            }).catch(function (e) {
                $scope.mensagem = e.data;
            });
        };

        $scope.perfis = $scope.consultaperfis();
        
        $scope.usuario = {
            Nome: '',
            Email: '',
            Foto: '',
            Senha: '',
            ConfirmarSenha: '',
            IdPerfil: 0
        };

        $scope.cadastrarusuario = function () {
            $scope.mensagem = 'Processando seu cadastro...';

            var dados = $scope.usuario;

            $http.post('http://localhost:50787/jobx/usuario/cadastrarusuario',
                dados)
                .then(function (d) {

                    $scope.mensagem = d.data;

                    $scope.usuario = {
                        Nome: '',
                        Email: '',
                        Foto: '',
                        Senha: '',
                        ConfirmarSenha: '',
                        IdPerfil: 0
                    };
                })
                .catch(function (e) {
                    if (e.status === 400) {
                        //erro de validação..
                        //Armazenando o JSON com as validações..
                        $scope.erros = e.data;
                        $scope.mensagem = "";
                    } else {
                        //mensagem de erro..
                        $scope.mensagem = e.data;
                    }
                });
        };

        var dados = new FormData();
        $scope.getTheFiles = function ($files) {
            angular.forEach($files, function (value, key) {
                dados.append(key, value);
            });
        };

        $scope.uploadFiles = function () {
            var request = {
                method: 'POST',
                url: 'http://localhost:50787/jobx/usuario/uploadfoto',
                data: dados,
                headers: {
                    'Content-Type': undefined
                }
            };
            $http(request)
                .success(function (d) {
                    $scope.mensagem = d;
                })
                .error(function (e) {
                    $scope.mensagem = e;
                });
        };
    }
)