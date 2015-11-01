(function () {

    var localBooksService = function () {
        var _books = [
            { ID: 1, BookName: "My First Book", AuthorName: "Test Author 1", ISBN: "Test 1" },
            { ID: 2, BookName: "Safura has this", AuthorName: "Test Author 2", ISBN: "TEST2" },
            { ID: 3, BookName: "Zaynab read this book", AuthorName: "Test Author 3", ISBN: "TEST3" },
            { ID: 4, BookName: "Can you tear this", AuthorName: "Test Author 4", ISBN: "TEST4" },
            { ID: 5, BookName: "Hello, I am good", AuthorName: "Test Author 5", ISBN: "TEST5" }
        ];

        return {
            books: _books
        };

    }

    angular.module('modangulartest').factory('localBooksService', [localBooksService]);

}());
