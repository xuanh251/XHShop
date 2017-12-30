(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService'];
    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.getListProductCategories = getListProductCategories;
        function getListProductCategories() {
            apiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log("Load product category failed!");
            });
        }
        $scope.getListProductCategories();
    }
})(angular.module('xhonlineshop.product_categories'));