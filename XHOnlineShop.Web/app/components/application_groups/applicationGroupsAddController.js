/// <reference path="../../shared/services/notificationservice.js" />
/// <reference path="../../../assets/admin/libs/moment/moment.js" />
/// <reference path="../../shared/services/apiservice.js" />
(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject=['apiService','$scope','notificationService','$state','commonService']
    function productCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.productCategory = {
            Status: true,
            HomeFlag: true,
        }
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }
        $scope.AddProductCategory = AddProductCategory;
        function AddProductCategory() {
            apiService.post('/api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm vào!');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Có lỗi xảy ra, chưa thêm được!');
            });
        }
        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log("Can't load parentCategory!")
            })
        }
        loadParentCategory();
    }
})(angular.module('xhonlineshop.product_categories'))