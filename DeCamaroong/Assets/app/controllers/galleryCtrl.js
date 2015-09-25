angular.module('gallery', ['ui.bootstrap', 'flow', 'angularGrid', 'bootstrapLightbox'])
    .controller('galleryCtrl', [
        '$scope', '$rootScope', '$http', '$window', '$filter', 'Lightbox', function ($scope, $rootScope, $http, $window, $filter, Lightbox) {

            $scope.images = [];
            $scope.galleries = [];
            $scope.tempGalleries = [];
            $scope.obj = {};

            $scope.load = function () {
                $http.get('/api/WSGallery/GetGallery')
                    .success(function (data, status, headers, config) {
                        // $scope.obj = {};

                        $scope.galleries = data;
                    }).error(function (s) { console.log(s) });
            }

            $scope.processFiles = function (files) {
                angular.forEach(files, function (flowFile, i) {
                    var fileReader = new FileReader();
                    fileReader.onload = function (event) {
                        var uri = event.target.result;
                        var gallery = {};
                        gallery.Name = flowFile.name;
                        gallery.Content = uri;
                        gallery.CreatedDate = $filter('date')(new Date(), "dd/MM/yyyy");
                        $scope.tempGalleries.push(gallery);
                    };
                    fileReader.readAsDataURL(flowFile.file);
                });
                //files = [];

            };


            $scope.Save = function () {
                $http.post('/api/WSGallery/Add', $scope.tempGalleries)
                    .success(function (data, status, headers, config) {
                        $scope.load();
                        $scope.obj.flow.files = [];
                        console.log(Flow.files);
                        $scope.tempGalleries = [];
                    }).error(function (s) { console.log(s) });;
            }

            $scope.Delete = function (ID) {

                $http.get('/api/WSGallery/Delete?ID=' + ID).success(
                    function (d, s, h, c) {
                        $scope.load();
                    });
            };

            $scope.openLightboxModal = function (index) {
                Lightbox.openModal($scope.galleries, index);
            };

            $scope.load();
        }
    ]);