angular.module('blogManager', ['textAngular'])
    .controller('blogManagerCtrl', ['$scope', '$http', function ($scope, $http) {
        $scope.isHome = false;
        $scope.blogTitle = "";
        $scope.blogContent = "";

        $scope.getList = function ()
        {
            $http.get('/api/WS_Blog/GetUserBlogItems')
                .success(function (data, status, headers, config) {
                    console.log(data);
                    $scope.blogList = data;
                });
        }

        $scope.postItem = function()
        {
            item =
                {
                    Title: $scope.blogTitle,
                    Content : $scope.blogContent
                };

            if ($scope.newTaskText != '') {
                $http.post('/api/WS_Blog/PostBlogItem', item)
                    .success(function (data, status, headers, config) {
                        $scope.newTaskText = '';
                        $scope.getList();
                    });
            }
        }

        $scope.complete = function(index)
        {
            $http.post('/api/WS_Blog/CompleteBlogItem/' + $scope.todoList[index].id)
                .success(function (data, status, headers, config) {
                    $scope.getList();
                });
        }

        $scope.delete = function(index)
        {
            $http.post('/api/WS_Blog/DeleteBlogItem/' + $scope.todoList[index].id)
                .success(function (data, status, headers, config) {
                    $scope.getList();
                });
        }

        //Get the current user's list when the page loads.
        $scope.getList();
    }]);