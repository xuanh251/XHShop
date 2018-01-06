﻿/// <reference path="../assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('xhonlineshop', ['xhonlineshop.products', 'xhonlineshop.product_categories', 'xhonlineshop.common'])
        .config(config)
        .config(configAuth);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract: true
            }).state('login', {
                url: "/login",
                templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
    }
    function configAuth($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {
                    return config;
                },
                requestError: function (rejection) {
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    return response;
                },
                responseError: function (rejection) {
                    if (rejection.status = "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            }
        })
    }
})();