angular.module('home', ['ui.bootstrap'])
    .controller('homeCtrl', ['$scope', '$http', '$window', '$rootScope','$modal', function ($scope, $http, $window, $rootScope,$modal) {
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
        $scope.ok = function () {
            $rootScope.modal.close();
        }

        $scope.getList();


    }]);