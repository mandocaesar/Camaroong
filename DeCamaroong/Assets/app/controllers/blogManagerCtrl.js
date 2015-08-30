angular.module('blogManager', ['textAngular'])
    .controller('blogManagerCtrl', ['$scope', '$http', function ($scope, $http) {
        $scope.isHome = false;
        $scope.blogTitle = "";
        $scope.blogContent = "";
        $scope.item = {};
        $scope.selectedId = 0;

        $scope.getList = function ()
        {
            $http.get('/api/WS_Blog/GetUserBlogItems')
                .success(function (data, status, headers, config) {
                    console.log(data);
                    $scope.blogList = data;
                });
        }

        $scope.select = function (id) {
            $scope.selectedId = id;
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

                console.log(item);
                alert(postUrl);
            }

            

            if ($scope.newTaskText != '') {
                $http.post(postUrl, item)
                    .success(function (data, status, headers, config) {
                        $scope.newTaskText = '';
                        $scope.item = {};
                        $scope.selectedId = 0;
                        $scope.getList();
                    });
            }
        }


        $scope.delete = function(index)
        {
            $http.post('/api/WS_Blog/DeleteBlogItem/' + $scope.blogList[index].ID)
                .success(function (data, status, headers, config) {
                    $scope.getList();
                });
        }

        //Get the current user's list when the page loads.
        $scope.getList();
    }]);