/// <reference path="../../bower_components/angular/angular.js" />
//khai báo module
var myApp = angular.module("myModule", []);
//khai báo controller thuộc module vừa khai báo
myApp.controller("myController", myController);
myApp.directive("shoPyDirective", shopDirective);
function myController($scope) {
    $scope.num = 1;
    $scope.checkNumber = function () {
        $scope.message = checkNumber($scope.num);
    }
}
function checkNumber(input) {
    if (input % 2 == 0) { return "Đây là số chẵn"; }
    else { return "Đây là số lẻ"; }
}
function shopDirective() {
    return {
        templateUrl: "/Templates/directivePage.html"
    }
}