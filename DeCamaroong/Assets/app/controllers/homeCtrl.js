angular.module('home', [])
    .controller('homeCtrl',['$scope','$http','$window', function ($scope, $http, $window) {
        $scope.alert = function () {
            alert("WOW");
        }
        
        $scope.isHome = true;
       
    }]);