(function (app) {
    app.factory('apiService', apiService);
    apiService.$inject = ['$http']
    function apiService($http) {
        return {
            get: get
        }
        function get(url, para, success, failure) {
            $http.get(url, para).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    };
    app.controller('datCtrl', function ($scope) {
        $scope.today = new Date();
    });
})(angular.module('xhonlineshop.common'))