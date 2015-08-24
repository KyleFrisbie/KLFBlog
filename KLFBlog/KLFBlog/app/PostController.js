(function () {
    angular.module("klfBlog")
    .controller('PostController', PostController);

    PostController.$inject = ['$scope'];
    function PostController($scope) {
        $scope.isCollapsed = true;
    };
}());