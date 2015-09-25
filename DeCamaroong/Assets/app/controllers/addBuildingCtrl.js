angular.module('addBuilding', ['ui.bootstrap', 'flow', 'textAngular'])
    .controller('addBuildingCtrl', ['$scope', '$http', '$window', '$routeParams', '$rootScope', '$modal', function ($scope, $http, $window, $routeParams, $rootScope, $modal, $modalInstance) {
        $scope.ID = $routeParams.Id;
        $rootScope.selectedId = 0;
        $scope.building = {};
        $scope.building.Images = [];
        $scope.modal = {};
        $scope.obj = {};
        $scope.images = [];

        $scope.getBuilding = function (ID) {
            $http.get('/api/WsBuilding/GetBuilding?Id=' + ID)
            .success(function (data, status, headers, config) {
                $scope.building = data;
            }).error(function (s) { console.log(s) });
        }

        $scope.delete = function () {
            var postUrl = '../api/WSBuilding/DeleteBuilding';
            $http.post(postUrl, item)
                .success(function (data, status, headers, config) {
                    //Modal
                }).error(function (data, status, headers, config) {
                    //Modal
                });
        }

        $scope.deleteImage = function(id, imageIdx) {
            ////imageIdx = imageIdx + 1;
            var value = id + '-' + imageIdx;
            var postUrl = '../api/WSBuilding/DeleteImage?idx=' + value;
            
            console.log(value);
            var item = { idx: value };
            $http.get(postUrl)
                .success(function (data, status, headers, config) {
                    $scope.getBuilding($scope.ID);
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
            var postUrl = '/api/WSBuilding/PostBuilding';
            if ($scope.ID !== 0) {
                postUrl = '/api/WSBuilding/UpdateBuilding';
            }
            angular.forEach($scope.images, function (x, i) {
                $scope.building.Images.push({
                    Content: x,
                    MainImage: false
                });
            });

            console.log($scope.building);
            // $scope.building.Images = $flow.files;
            $http.post(postUrl, $scope.building)
                .success(function (data, status, headers, config) {
                    $scope.building = {};
                    $rootScope.selectedId = 0;
                    window.location = '#/building';

                }).error(function (data, status, headers, config) {
                    $scope.building = {};
                });
        }


        if (!$rootScope.loggedIn) {
            window.location = '#/signin';
        } else {
            if ($scope.ID != null) {
                $scope.getBuilding($scope.ID);
            }
        }

        $scope.ok = function () {
            $rootScope.modal.close();
        }
    }]);