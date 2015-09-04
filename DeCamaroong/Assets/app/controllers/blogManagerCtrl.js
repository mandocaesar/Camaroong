angular.module('blogManager', ['textAngular'])
    .controller('blogManagerCtrl', ['$scope', '$http', '$timeout', '$rootScope', function ($scope, $http, $timeout, $rootScope) {
        $scope.isHome = false;
        $scope.blogTitle = "";
        $scope.blogContent = "";
        $scope.item = {};
        $scope.selectedId = 0;
        $scope.isShowAlert = false;
        $scope.isedit = false;
        $scope.message = "";

        $scope.getList = function ()
        {
            $http.get('/api/WS_Blog/GetUserBlogItems')
                .success(function (data, status, headers, config) {
                    console.log(data);
                    $scope.blogList = data;
                });
        }

        $scope.cancelEdit = function () {
            $scope.selectedId = 0;
            $scope.blogContent = "";
            $scope.blogTitle = "";
            $scope.isedit = false;
        }

        $scope.select = function (id) {
            $scope.selectedId = id;
            $scope.isedit = true;
            angular.forEach($scope.blogList, function (value, key) {
                if (value.ID == id)
                {
                    $scope.item = value;
                    $scope.blogTitle = $scope.item.Title;
                    $scope.blogContent = $scope.item.Content;
                }
            });
        }

        $scope.postItem = function()
        {
            var postUrl = '/api/WS_Blog/PostBlogItem';
            item =
                {
                    Title: $scope.blogTitle,
                    Content: $scope.blogContent
                };
            if ($scope.selectedId != 0) {
                postUrl = '/api/WS_Blog/UpdatePostItem';
                item = $scope.item;
                $scope.item.Title = $scope.blogTitle;
                $scope.item.Content = $scope.blogContent;
            }

            if ($scope.newTaskText != '') {
                $http.post(postUrl, item)
                    .success(function (data, status, headers, config) {
                        $scope.newTaskText = '';
                        $scope.item = {};
                        $scope.selectedId = 0;
                        $scope.getList();
                        $scope.showAlert(item.Title + " has beed added", "success");
                    })
                .error(function (data, status, headers, config) {
                    $scope.showAlert(status, "error");
                });
            }
        }


        $scope.delete = function(index)
        {
            $http.post('/api/WS_Blog/DeleteBlogItem/' + index)
                .success(function (data, status, headers, config) {
                    $scope.getList();
                });
        }

        $scope.showAlert = function (message, type) {
            $scope.isShowAlert = true;
            $scope.type = 'alert-' + type;
            $timeout(function () {
                $scope.message = message;
                $scope.isShowAlert = false;
            }, 3000);
        }

        if (!$rootScope.loggedIn) {
            window.location = '#/signin';

        } else {
            //Get the current user's list when the page loads.
            $scope.getList();
        }
    }]);