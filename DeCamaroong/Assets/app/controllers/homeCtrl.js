angular.module('home', ['ui.bootstrap'])
    .controller('homeCtrl', ['$scope', '$http', '$window', '$rootScope', '$modal', function ($scope, $http, $window, $rootScope, $modal) {
        $scope.mail = {};

        $scope.getList = function () {
            $http.get('/api/WS_Blog/GetUserBlogItemsHome')
                .success(function (data, status, headers, config) {
                    console.log(data);
                    $scope.blogList = data;
                });
        };

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
                $scope.buildingsTop = data.splice(0, 4);
                $scope.buildingsBottom = data.splice(4, 8);
                console.log($rootScope.selectedId);
                if ($rootScope.selectedId !== 0) {
                    $scope.building = data[$rootScope.selectedId];
                    console.log($scope.building);
                }

            }).error(function (s) { console.log(s) });
        }

        $scope.ok = function () {
            $rootScope.modal.close();
        }

        $scope.getList();
        $scope.getBuildings();


    }]);