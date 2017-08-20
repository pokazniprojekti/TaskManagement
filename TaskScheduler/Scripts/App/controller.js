
var TaskControllers = angular.module("TaskControllers", ['ngTable']);


TaskControllers.controller("ListController", ['$scope', '$http', '$filter', 'ngTableParams',
    function ($scope, $http, $filter, ngTableParams) {
        /*
        $scope.headers = [
           { column: "FirstName" },
           { column: "LastName" }
        ];*/

        $http.get('/api/workingtasks').success(function (data) {

            $scope.tableParams = new ngTableParams({
                page: 1,              // show first page
                count: 5,             // count per page
                sorting: {
                    Id: 'asc' // initial sorting
                }
            }, {
                total: data.length,
                getData: function ($defer, params) {


                    $scope.data = params.sorting() ? $filter('orderBy')(data, params.orderBy()) : data;
                    $scope.data = params.filter() ? $filter('filter')($scope.data, params.filter()) : $scope.data;
                    $scope.data = $scope.data.slice((params.page() - 1) * params.count(), params.page() * params.count());
                    $defer.resolve($scope.data);
                }



            });
        });
    }]
);




TaskControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
        function ($scope, $http, $routeParams, $location) {

            $scope.id = $routeParams.id;
            $http.get('/api/WorkingTasks/' + $routeParams.id).success(function (data) {
                $scope.Id = data.Id;
                $scope.Description = data.Description;
                $scope.IsActive = data.IsActive;
                $scope.Visibility = data.Visibility;
                $scope.TaskName = data.TaskName;
                $scope.StartDate = data.StartDate;
                $scope.EndDate = data.EndDate;
               
            });

            $scope.delete = function () {

                $http.delete('/api/WorkingTasks/' + $scope.id).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    $scope.error = "An error has occured while deleting task! " + data;
                });
            };
        }
]);



// this controller call the api method and display the record of selected employee
// in edit.html and provide an option for create and modify the employee and save the employee record


TaskControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {

        $http.get('/api/users').success(function (data) {
            $scope.employees = data;
        });

        $http.get('/api/active').success(function (data1) {
            $scope.activestate = data1;
        });

        $http.get('/api/visible').success(function (data2) {
            $scope.visible = data2;
        });

        $http.get('/api/reg').success(function (data3) {
            $scope.userid = data3;
        });

        $scope.id = 0;
        /*
        $scope.getStates = function () {
            var country = $scope.country;
            if (country) {
                $http.get('/api/country/' + country).success(function (data) {
                    $scope.states = data;
                });
            }
            else {
                $scope.states = null;
            }
        }*/

        $scope.save = function () {

            var obj = {
                Id: $scope.id,
                Description: $scope.Description,
                IsActive: $scope.IsActive,
                Assign: $scope.Assign,
                Visibility: $scope.Visibility,
                TaskName: $scope.TaskName,
                StartDate: $scope.StartDate,
                EndDate: $scope.EndDate,
                Users_Id: $scope.Users_Id

                
            };
            console.log(obj);
            if ($scope.id == 0) {

                $http.post('/api/WorkingTasks/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    $scope.error = "An error has occured while adding tasks! " + data.ExceptionMessage;
                });
            }
            else {

                $http.put('/api/WorkingTasks/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving Task! " + data.ExceptionMessage;
                });
            }
        }

        if ($routeParams.id) {

            $scope.id = $routeParams.id;
            $scope.title = "Edit Task";

            $http.get('/api/WorkingTasks/' + $routeParams.id).success(function (data) {
                $scope.Description = data.Description;
                $scope.IsActive = data.IsActive;
                $scope.Assign = data.Assign;
                $scope.Visibility = data.Visibility;
                $scope.TaskName = data.TaskName;
                $scope.StartDate = new Date(data.StartDate);
                $scope.EndDate = new Date(data.EndDate);
                $scope.Users_Id = data.Users_Id;
              
            });
        }
        else {
            $scope.title = "Create New Task";
        }
    }
]);

