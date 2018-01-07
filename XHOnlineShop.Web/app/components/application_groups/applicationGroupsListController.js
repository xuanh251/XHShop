(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getListProductCategories = getListProductCategories;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;
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
            apiService.del('/api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Đã xoá thành công ' + result.data + ' bản ghi.');
                getListProductCategories();
            }, function (error) {
                notificationService.displayError('Xảy ra lỗi, chưa xoá được.');
            })
        }
        function selectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                })
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false;
            }
        }
        $scope.$watch('productCategories', function (newVal, oldVal) {
            var checked = $filter('filter')(newVal, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn chắc chắn muốn xoá?').then(function () {
                var config = {
                    params: {
                        id: id,
                    }
                }
                apiService.del('/api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Xoá thành công!');
                    getListProductCategories();
                }, function () {
                    notificationService.displayError('Xoá không thành công!');
                })
            })
        }
        function search() {
            getListProductCategories();
        }

        function getListProductCategories(page) {
            page = page || 0; //nếu bằng null thì thay bằng 0
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }

            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi nào!')
                }
                else {
                    notificationService.displaySuccess('Tìm thấy ' + result.data.TotalCount + ' bản ghi.')
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
