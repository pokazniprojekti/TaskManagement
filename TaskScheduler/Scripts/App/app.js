var TaskApp = angular.module('TaskApp', [
    'ngRoute',
    'TaskControllers',
    'TaskControllers1'
   
    
]);

TaskApp.config(['$routeProvider','$locationProvider', function ($routeProvider,$locationProvider) {
    $locationProvider.html5Mode(false).hashPrefix('!');

    $routeProvider.when('/list', {
        templateUrl: '/Task/List.html',
        controller: 'ListController'
    }).

        
    when('/create', {
        templateUrl: '/Task/Edit.html',
        controller: 'EditController'
    }).
    
    when('/edit/:id', {
        templateUrl: '/Task/Edit.html',
        controller: 'EditController'
    }).
    
    when('/delete/:id', {
        templateUrl: '/Task/Delete.html',
        controller: 'DeleteController'
    }).

    
    otherwise({
        redirectTo: '/list'
    });
    
}]);


