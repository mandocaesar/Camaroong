angular.module('home', ['ui.bootstrap', 'ngScrollTo'])
    .controller('homeCtrl', ['$scope', '$http', '$window', '$rootScope', '$modal', '$anchorScroll', '$location',
        function ($scope, $http, $window, $rootScope, $modal, $anchorScroll, $location) {
            $scope.mail = {};
            $scope.group = [];
            $scope.galleries = [];

            $scope.loadGalleries = function () {
                $http.get('/api/WSGallery/GetGallery')
                    .success(function (data, status, headers, config) {
                        $scope.galleries = data;
                        $('#pageloader').hide();
                    }).error(function (s) {  });

            }

            $scope.getList = function () {
                $http.get('/api/WS_Blog/GetUserBlogItemsHome')
                    .success(function (data, status, headers, config) {
                        $scope.blogList = data;
                    });
            };

            $scope.getContent = function (index) {

                if ((index) > ($scope.galleries.length)) {
                    var idx = (index) - ($scope.galleries.length);
                    return $scope.galleries[idx-1].Content;
                } else {

                    return $scope.galleries[index-1].Content;
                }
            }

            $scope.postMail = function () {
                console.log($scope.mail);
                $http.post('/api/WsMail/PostMail', $scope.mail)
                    .success(function (data, status, headers, config) {
                        $rootScope.modal = $modal.open({
                            animation: true,
                            templateUrl: 'thanks.html',
                            controller: 'homeCtrl',
                            size: 'lg'
                        });
                        $scope.mail = {};
                    });
            };

            $scope.getBuildings = function () {

                $http.get('/api/WsBuilding/GetTopBuilding?number=10').success(function (data) {
                    $rootScope.buildings = data;
                    // $rootScope.building = data[0];
                    $scope.buildingsTop = data;
                    $scope.building = $rootScope.buildings[1];


                }).error(function (s) { console.log(s) });

            }

            $scope.ok = function () {
                $rootScope.modal.close();
            }

            $scope.getDetail = function (index) {
                window.location.href = "#/viewBuilding?Id=" + index;
            };

            $scope.getList();
            $scope.getBuildings();
            $scope.loadGalleries();


        }]);