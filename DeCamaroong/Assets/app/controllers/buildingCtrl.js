angular.module('building', ['ui.bootstrap', 'flow'])
    .controller('buildingCtrl', ['$scope', '$http', '$window', '$routeParams', '$rootScope', '$modal', function ($scope, $http, $window, $routeParams, $rootScope, $modal, $modalInstance) {
        $scope.ID = $routeParams.Id;
        $rootScope.selectedId = 0;
        $scope.building = {};
        $scope.building.Images = [];
        $scope.modal = {};
        $scope.obj = {};
        $scope.images = [];

        //$scope.getBuilding = function (ID) {
        //    $http.get('/api/WsBuilding/GetBuilding?id=' + ID)
        //    .success(function (data, status, headers, config) {
        //        $scope.building = data;
        //    }).error(function (s) { console.log(s) });
        //}

        $scope.delete = function () {
            var postUrl = '../api/WSBuilding/DeleteBulding';
            $http.post(postUrl, item)
                .success(function (data, status, headers, config) {
                    //Modal
                }).error(function (data, status, headers, config) {
                    //Modal
                });
        }

        $scope.processFiles = function (files) {
            angular.forEach(files, function (flowFile, i) {
                var fileReader = new FileReader();
                fileReader.onload = function (event) {
                    var uri = event.target.result;
                    $scope.images[i] = uri;
                };
                fileReader.readAsDataURL(flowFile.file);
            });
        };

        $scope.postItem = function () {
            alert($scope.ID);
            var postUrl = '/api/WSBuilding/PostBuilding';
            if ($scope.ID !== 0) {
                postUrl = '/api/WSBuilding/UpdateBuilding';
            } else {
                angular.forEach($scope.images, function(x, i) {
                    $scope.building.Images.push({
                        Content: x,
                        MainImage: false
                    });
                });
            }

            console.log($scope.building);
            // $scope.building.Images = $flow.files;
            $http.post(postUrl, $scope.building)
                .success(function (data, status, headers, config) {
                    $scope.building = {};
                    $rootScope.ID = 0;
                    window.location = '#/building';

                }).error(function (data, status, headers, config) {
                    $scope.building = {};
                });
        }

        $scope.getBuildings = function () {

            $http.get('/api/WsBuilding/GetAllBuilding').success(function (data) {
                $scope.buildings = data;
                console.log($rootScope.selectedId);
                if ($rootScope.selectedId !== 0) {
                    $scope.building = data[$rootScope.selectedId];
                    console.log($scope.building);
                }
              
            }).error(function (s) { console.log(s) });
        }

        //if (!$rootScope.loggedIn) {
        //    //    window.location = '#/signin';
        //} else {
            $scope.getBuildings();
      //  }

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