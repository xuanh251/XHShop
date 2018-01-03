(function () {
    angular.module('xhonlineshop.products', ['xhonlineshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        }).state('add_products', {
            url: "/add_products",
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        }).state('edit_product', {
            url: "/edit_product/:id",
            templateUrl: "/app/components/products/productEditView.html",
            controller: "productEditController"
        });
    }
})();