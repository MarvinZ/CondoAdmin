(function () {
    'use strict';

    angular.module('AmenityApp').controller('AmenityController', AmenityController);

    function AmenityController(moment, alert, alert2, calendarConfig, $http,$uibModal) {
        //angular
        //  .module('app') //you will need to declare your module with the dependencies ['mwl.calendar', 'ui.bootstrap', 'ngAnimate']
        //  .controller('CalendarController', function (moment, alert, calendarConfig) {

        var vm = this;
        var dataService = $http;
        vm.isCalendarVisible = true;

        vm.amenities = [
            { "Id": 1, "Name": "Piscina" },
            { "Id": 2, "Name": "Rancho 1" },
            { "Id": 3, "Name": "Cancha de Tenis" }
        ];
        vm.selectedAmenity = 0;



        //These variables MUST be set as a minimum for the calendar to work
        vm.calendarView = 'month';
        vm.viewDate = new Date();
        var actions = [
            {
                label: '<i class=\'glyphicon glyphicon-pencil\'></i>',
                onClick: function (args) {
                    alert.show('Edited', args.calendarEvent);
                }
            }, {
                label: '<i class=\'glyphicon glyphicon-remove\'></i>',
                onClick: function (args) {
                    alert.show('Deleted', args.calendarEvent);
                }
            }
        ];

        vm.calendarNewEventEnd =
        {
            title: 'HardCoded',
            color: calendarConfig.colorTypes.warning,
            //startsAt: moment().startOf('week').subtract(2, 'days').add(8, 'hours').toDate(),
            //endsAt: moment().startOf('week').add(1, 'week').add(9, 'hours').toDate(),
            startsAt: moment().startOf('hour').toDate(),
            endsAt: moment().add(2, 'hour').toDate(),
            draggable: true,
            resizable: true,
            actions: actions
        };
        vm.events = [
             //{
             //    title: 'HardCoded',
             //    color: calendarConfig.colorTypes.warning,
             //    //startsAt: moment().startOf('week').subtract(2, 'days').add(8, 'hours').toDate(),
             //    //endsAt: moment().startOf('week').add(1, 'week').add(9, 'hours').toDate(),
             //    startsAt: moment().startOf('hour').toDate(),
             //    endsAt: moment().add(2, 'hour').toDate(),
             //    draggable: true,
             //    resizable: true,
             //    actions: actions
             //}
            // ,
            //{
            //    title: 'An event',
            //    color: calendarConfig.colorTypes.warning,
            //    startsAt: moment().startOf('week').subtract(2, 'days').add(8, 'hours').toDate(),
            //    endsAt: moment().startOf('week').add(1, 'week').add(9, 'hours').toDate(),
            //    draggable: true,
            //    resizable: true,
            //    actions: actions
            //}, {
            //    title: '<i class="glyphicon glyphicon-asterisk"></i> <span class="text-primary">Another event</span>, with a <i>html</i> title',
            //    color: calendarConfig.colorTypes.info,
            //    startsAt: moment().subtract(1, 'day').toDate(),
            //    endsAt: moment().add(5, 'days').toDate(),
            //    draggable: true,
            //    resizable: true,
            //    actions: actions
            //}, {
            //    title: 'This is a really long event title that occurs on every year',
            //    color: calendarConfig.colorTypes.important,
            //    startsAt: moment().startOf('day').add(7, 'hours').toDate(),
            //    endsAt: moment().startOf('day').add(19, 'hours').toDate(),
            //    recursOn: 'year',
            //    draggable: true,
            //    resizable: true,
            //    actions: actions
            //}
        ];

        vm.isCellOpen = true;
        vm.openTest = function () {
            $uibModal.open({
                templateUrl: '/Content/Templates/modalContent2.html',
                controller: 'ModalInstanceCtrl'
            });
          
        };

        vm.addEvent = function () {

            alert2.show('Clicked', vm.calendarNewEventEnd);
            //vm.events.push({
            //    title: 'New event',
            //    startsAt: moment().startOf('day').toDate(),
            //    endsAt: moment().endOf('day').toDate(),
            //    color: calendarConfig.colorTypes.important,
            //    draggable: true,
            //    resizable: true
            //});
        };

        vm.selectedItemChanged = function () {
            getReservationsByAmenityId(vm.selectedAmenity);
            //vm.isCalendarVisible = true;
        };

        function getReservationsByAmenityId(id) {
            //alert("getting the member list!");
            // Call Web API to get a product
            dataService.get("http://localhost:11618/api/AmenityReservations/GetAllReservationsByAmenityId/" + id)
              .then(function (result) {
                  // Display product
                  vm.events = result.data;
              }, function (error) {
                  handleException(error);
              });
        }


        vm.eventClicked = function (event) {
            alert.show('Clicked', event);
        };


        vm.eventEdited = function (event) {
            alert.show('Edited', event);
        };

        vm.eventDeleted = function (event) {
            alert.show('Deleted', event);
        };

        vm.eventTimesChanged = function (event) {
            alert.show('Dropped or resized', event);
        };

        vm.toggle = function ($event, field, event) {
            $event.preventDefault();
            $event.stopPropagation();
            event[field] = !event[field];
        };

        function handleException(error) {
            vm.uiState.isValid = false;
            var msg = {
                property: 'Error',
                message: ''
            };

            vm.uiState.messages = [];

            switch (error.status) {
                case 400:   // 'Bad Request'
                    // Model state errors
                    var errors = error.data.ModelState;
                    //                    debugger;

                    // Loop through and get all 
                    // validation errors
                    for (var key in errors) {
                        for (var i = 0; i < errors[key].length;
                                i++) {
                            addValidationMessage(key,
                                        errors[key][i]);
                        }
                    }

                    break;

                case 404:  // 'Not Found'
                    msg.message = 'The product you were ' +
                                  'requesting could not be found';
                    vm.uiState.messages.push(msg);

                    break;

                case 500:  // 'Internal Error'
                    msg.message =
                      error.data.ExceptionMessage;
                    vm.uiState.messages.push(msg);

                    break;

                default:
                    msg.message = 'Status: ' +
                                error.status +
                                ' - Error Message: ' +
                                error.statusText;
                    vm.uiState.messages.push(msg);

                    break;
            }
        }

    }
})();
