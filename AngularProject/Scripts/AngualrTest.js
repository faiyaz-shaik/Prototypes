
//angular module with the same name  as the app.
var modangulartest = angular.module("modangulartest", []);

//module ----->  controllers, serviecs, directives and filters.
modangulartest.controller("atCtrl", ["$scope", function ($scope) {
    $scope.message = "Hello World";
}])
