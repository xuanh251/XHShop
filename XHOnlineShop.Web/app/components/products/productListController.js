(function (app) {
    app.controller('productListController', productListController);
    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProducts = getListProducts;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProduct = deleteProduct;
        $scope.isAll = false;
        $scope.selectAll = selectAll;
        $scope.deleteMulti = deleteMulti;
        function deleteMulti() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            })
            var config = {
                params: {
                    listId: JSON.stringify(listId),
                }
            }
            apiService.del('/api/product/deletemulti', config, function (result) {
                notificationService.displaySuccess('Đã xoá thành công ' + result.data + ' bản ghi.');
                getListProducts();
            }, function (error) {
                notificationService.displayError('Xảy ra lỗi, chưa xoá được.');
            })
        }
        function selectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                })
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false;
            }
        }
        $scope.$watch('products', function (newVal, oldVal) {
            var checked = $filter('filter')(newVal, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn chắc chắn muốn xoá?').then(function () {
                var config = {
                    params: {
                        id: id,
                    }
                }
                apiService.del('/api/product/delete', config, function () {
                    notificationService.displaySuccess('Xoá thành công!');
                    getListProducts();
                }, function () {
                    notificationService.displayError('Xoá không thành công!');
                })
            })
        }
        function search() {
            getListProducts();
        }

        function getListProducts(page) {
            page = page || 0; //nếu bằng null thì thay bằng 0
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }

            apiService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi nào!')
                }
                else {
                    notificationService.displaySuccess('Tìm thấy ' + result.data.TotalCount + ' bản ghi.')
                }
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;

            }, function () {
                console.log("Load product failed!");
            });
        }
        $scope.getListProducts();
    }

})(angular.module('xhonlineshop.products'));
