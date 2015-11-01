(function() {

    var booksController = function ($scope, $filter, localBooksService) {
        $scope.message = "Hello From Books Controller";
        this.greeting = "This is a greeting message using a controller syntax.";
        $scope.books = [];

        $scope.fetchBooks = function () {
            $scope.books = localBooksService.books;
        }



    }

    angular.module('modangulartest').controller('booksController', ["$scope", "$filter", "localBooksService", booksController]);


}());




