﻿(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true) {
                return 'Kích hoạt';
            }
            else {
                return 'Khoá';
            }
        }
    });
})(angular.module('xhonlineshop.common'));