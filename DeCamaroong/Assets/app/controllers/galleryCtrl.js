angular.module('gallery', [])
    .controller('galleryCtrl', [
        '$scope', '$http', '$window', function($scope, $http, $window) {

            $http.get('/api/WSGallery/GetGallery')
                .success(function(data, status, headers, config) {
                    console.log(data);
                    $scope.galleries = data;
                }).error(function(s) { console.log(s) });

        }
    ])
    .controller('galleryCtrl', [
        '$scope', '$http', '$window', function($scope, $http, $window) {

            $http.get('/api/WSGallery/GetGallery')
                .success(function(data, status, headers, config) {
                    console.log(data);
                    $scope.galleries = data;
                }).error(function(s) { console.log(s) });

        }
    ]);