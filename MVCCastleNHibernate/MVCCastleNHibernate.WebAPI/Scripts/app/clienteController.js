(function () {
    'use strict';

    var app = angular.module('app', []);
    app.controller('clienteController', ['$scope', '$http', clienteController]);

    app.directive('telefoneDir', TelefoneDir);

    //Diretiva para mascará de telefone
    function TelefoneDir() {
        return {
            link: function (scope, element, attrs) {
                var options = {
                    onKeyPress: function (val, e, field, options) {
                        putMask();
                    }
                }

                $(element).mask('(00) 00000-0000', options);

                function putMask() {
                    var mask;
                    var cleanVal = element[0].value.replace(/\D/g, '');
                    if (cleanVal.length > 10) {
                        mask = "(00) 00000-0000";
                    } else {
                        mask = "(00) 0000-00009";
                    }
                    $(element).mask(mask, options);
                }
            }
        }
    }

    function clienteController($scope, $http) {

        $scope.loading = true;
        $scope.addMode = false;

        $http.get('/api/Cliente/Get/').success(function (data) {
            $scope.clientes = data;
            $scope.loading = false;
        })
            .error(function () {
                $scope.error = "Erro ao carregar os dados dos clientes!";
                $scope.loading = false;
            });

        $scope.toggleEdit = function () {
            this.cliente.editMode = !this.cliente.editMode;
        };

        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        //Adiciona Cliente
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/Cliente/AddEdit/', this.novoCliente).success(function (data) {
                swal("Sucesso", "Cliente Adicionado!!", "success");
                $scope.addMode = false;
                $scope.clientes.push(data);
                $scope.loading = false;
                $scope.novoCliente = null;
            }).error(function (data) {
                $scope.error = "Erro! " + data;
                $scope.loading = false;
            });
        };

        //Edita Cliente
        $scope.save = function () {
            $scope.loading = true;
            var cliente = this.cliente;
            $http.post('/api/Cliente/AddEdit/', this.cliente).success(function (data) {
                swal("Sucesso", "Cliente Editadp!!", "success");
                cliente.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "Erro! " + data;
                $scope.loading = false;
            });
        };

        //Excluí Cliente
        $scope.deleteCliente = function () {
            $scope.loading = true;
            var id = this.cliente.Id;
            $http.get('/api/Cliente/Delete/' + id).success(function (data) {
                swal("Sucesso", "Cliente Excluído!!", "success");
                $.each($scope.clientes, function (i) {
                    if ($scope.clientes[i].Id === id) {
                        $scope.clientes.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "Erro! " + data;
                $scope.loading = false;
            });
        };
    }
})();