angular.module('signIn', ['ngCookies'])
    .controller('signInCtrl', ['$scope' ,'$rootScope', '$http', '$cookies', '$cookieStore', '$location', '$routeParams', function ($scope, $rootScope, $http, $cookies, $cookieStore, $location, $routeParams) {
        $scope.message = $routeParams.message;
        $scope.isHome = false;
        $scope.signIn = function () {
            $scope.showMessage = false;
            var params = "grant_type=password&username=" + $scope.username + "&password=" + $scope.password;
            $http({
                url: '/Token',
                method: "POST",
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                data: params
            })
            .success(function (data, status, headers, config) {
                console.log(data);
                console.log(status);

                $http.defaults.headers.common.Authorization = "Bearer " + data.access_token;
                $http.defaults.headers.common.RefreshToken = data.refresh_token;
                
                $cookieStore.put('_Token', data.access_token);
                $location.path("/blogmanager");
            })
            .error(function (data, status, headers, config) {
                console.log(data);
                console.log(status);

                $scope.message = data.error_description.replace(/["']{1}/gi, "");
                $scope.showMessage = true;
            });
        }
    }]);