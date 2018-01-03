/// <reference path="../../shared/services/notificationservice.js" />
/// <reference path="../../../assets/admin/libs/moment/moment.js" />
/// <reference path="../../shared/services/apiservice.js" />
(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService']
    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            Status: true,
            HomeFlag: true,
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px',
            uiColor: '#ffffff'
        }
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }
        $scope.AddProduct = AddProduct;
        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post('/api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm vào!');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Có lỗi xảy ra, chưa thêm được!');
            });
        }
        function loadParent() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log("Can't load parent!")
            })
        }
        $scope.moreImages = [];
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }
        loadParent();
    }
})(angular.module('xhonlineshop.products'))