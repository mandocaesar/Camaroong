angular.module('news', [])
    .controller('newsCtrl', ['$scope', '$http', '$window', '$routeParams', function ($scope, $http, $window, $routeParams) {
        $scope.ID = $routeParams.ID;
        console.log($scope.ID);

        $http.post('/api/WS_Blog/GetUserBlogItem?ID='+$scope.ID)
            .success(function (data, status, headers, config) {
                console.log(data);
                $scope.news = data;
            }).error(function (s) { console.log(s)});


    }]);