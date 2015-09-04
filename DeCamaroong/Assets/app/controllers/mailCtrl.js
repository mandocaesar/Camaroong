angular.module('mail', ['ui.bootstrap'])
    .controller('mailCtrl', ['$scope', '$http', '$window', '$routeParams', '$rootScope', '$modal', function ($scope, $http, $window, $routeParams, $rootScope, $modal, $modalInstance) {
        $scope.ID = $routeParams.ID;
        $scope.mail = {};
        $scope.modal = {};

        $scope.getMail = function (ID) {
            $http.get('/api/WsMail/GetMail?id=' + ID)
            .success(function (data, status, headers, config) {
                $scope.mail = data;
            }).error(function (s) { console.log(s) });
        }

        $scope.getAllMail = function () {
            $http.get('/api/WsMail/GetAllMail').success(function (data) {
                $scope.mails = data;
                console.log($scope.mails);
            }).error(function (s) { console.log(s) });
        }

        if (!$rootScope.loggedIn) {
            window.location = '#/signin';
        } else {
            $scope.getAllMail();
        }

        $scope.view = function (index) {
            $rootScope.viewMail = $scope.mails[index];
            console.log($rootScope.viewMail);
           $rootScope.modal =  $modal.open({
                animation: true,
                templateUrl: 'modalmail.html',
                controller: 'mailCtrl',
                size: 'lg'
            });

        };

        $scope.ok = function () {
            $rootScope.modal.close();
        }
    }]);