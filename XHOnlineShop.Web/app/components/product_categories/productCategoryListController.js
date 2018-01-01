(function (app) {
    
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService','notificationService'];
    function productCategoryListController($scope, apiService, notificationService) {
        
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProductCategories = getListProductCategories;
        $scope.keyword = '';
        $scope.search = search;
        function search() {
            getListProductCategories();
        }
        
        function getListProductCategories(page) {
            page = page || 0; //nếu bằng null thì thay bằng 0
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 4
                }
            }
            
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount==0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi nào!')
                }
                else {
                    notificationService.displaySuccess('Tìm thấy ' + result.data.TotalCount+ ' bản ghi.')
                }
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
                
            }, function () {
                console.log("Load product category failed!");
            });
        }
        $scope.getListProductCategories();   
    }
   
})(angular.module('xhonlineshop.product_categories'));
