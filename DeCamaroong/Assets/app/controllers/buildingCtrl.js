﻿angular.module('building', ['ui.bootstrap', 'flow'])
    .controller('buildingCtrl', ['$scope', '$http', '$window', '$routeParams', '$rootScope', function ($scope, $http, $window, $routeParams, $rootScope) {
        $scope.ID = $routeParams.Id;
        $rootScope.selectedId = 0;
        $scope.building = {};
        $scope.building.Images = [];
        $scope.modal = {};
        $scope.obj = {};
        $scope.images = [];

        $scope.delete = function () {
            var postUrl = '../api/WSBuilding/DeleteBulding';
            $http.post(postUrl, item)
                .success(function (data, status, headers, config) {
                    //Modal
                }).error(function (data, status, headers, config) {
                    //Modal
                });
        }

        $scope.getBuilding = function (Id) {

            $scope.building = {};
            $http.get('/api/WsBuilding/GetBuilding?Id=' + Id).success(function (data) {
                $scope.building = data;

            }).error(function (s) { console.log(s) });
        }

        $scope.getBuildings = function () {
            $http.get('/api/WsBuilding/GetAllBuilding').success(function (data) {
                $scope.buildings = data;

            }).error(function (s) { console.log(s) });
        }


       

        if (!$rootScope.loggedIn) {
           
            if ($scope.ID != null) {
                $scope.getBuilding($scope.ID);
            } else {
                //window.location = '#/signin';
            }
        } else {
            $scope.getBuildings();
        }

        $scope.AddNew = function () {
            window.location = '#/addBuilding';
        }

        $scope.view = function (index) {
            window.location = '#/addBuilding/' + $scope.buildings[index].ID;
        };

        $scope.ok = function () {
            $rootScope.modal.close();
        }

        
    }]);