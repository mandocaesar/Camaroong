angular.module('home', [])
    .controller('homeCtrl',['$scope','$http','$window', function ($scope, $http, $window) {
        $scope.alert = function () {
            alert("WOW");
        }
        
        $scope.getList = function () {
            $http.get('/api/WS_Blog/GetUserBlogItems')
                .success(function (data, status, headers, config) {
                    console.log(data);
                    $scope.blogList = data;
                });
        }

        $scope.getList();

       
    }]);