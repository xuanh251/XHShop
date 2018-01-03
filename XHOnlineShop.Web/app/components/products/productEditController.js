/// <reference path="../../shared/services/notificationservice.js" />
/// <reference path="../../../assets/admin/libs/moment/moment.js" />
/// <reference path="../../shared/services/apiservice.js" />
(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService']
    function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }
        $scope.UpdateProduct = UpdateProduct;
        function loadProductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                notificationService.displayError(error);
            });
        }
        function UpdateProduct() {
            apiService.put('/api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công!');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Có lỗi xảy ra, cập nhật không thành công!');
            });
        }
        function loadParent() {
            apiService.get('/api/product/getallparents', null, function (result) {
                $scope.parents = result.data;
            }, function () {
                console.log("Can't load parent!")
            })
        }
        loadParent();
        loadProductDetail();
    }
})(angular.module('xhonlineshop.products'))