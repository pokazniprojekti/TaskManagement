
var TaskControllers1 = angular.module("TaskControllers1", ['ui.calendar']);

TaskControllers1.controller('CalendarController', ['$scope', 'uiCalendarConfig', '$http',

    function ($scope, uiCalendarConfig, $http) {
        $scope.SelectedEvent = null;
        var isFirstTime = true;

        $scope.events = [];
        $scope.eventSources = [$scope.events];
        //get the events data from server 
        $http.get('/Home/GetEventsData', {
            cache: true,
            params: {}
        }).then(function (data) {
            //get and push events data to calendar here
            $scope.events.slice(0, $scope.events.length);
            angular.forEach(data.data, function (value) {
                $scope.events.push({
                    title: value.TaskName,
                    description: value.Description,
                    start: new Date(parseInt(value.StartDate.substr(6))),
                    end: new Date(parseInt(value.EndDate.substr(6))),
                    //allDay: 1,
                    stick: true
                });
            });
        });
        //Calender configration in angular
        $scope.uiConfig = {
            calendar: {
                height: 450,
                editable: true,
                displayEventTime: false,
                header: {
                    left: 'Day and Monthly calendar Events',
                    center: 'title',
                    right: 'today prev,next'
                },
                eventClick: function (event) {
                    $scope.SelectedEvent = event;
                },
                eventAfterAllRender: function () {
                    if ($scope.events.length > 0 && isFirstTime) {
                        uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', $scope.events[0].start);
                        isFirstTime = false;
                    }
                }
            }
        };
    }]);

    
    