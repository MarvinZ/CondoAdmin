(function () {
    'use strict';

    angular.module('app').controller('CondoController', CondoController);

    function CondoController($http) {
        var vm = this;
        var dataService = $http;

        // Hook up public events

        vm.addGeneralCharge = addPayment;
        vm.processGeneralCharge = processPayment;
        vm.viewTransactions = viewTransactions;
        vm.cancelClick = cancelClick;
        

        vm.condoId = 1;
        vm.testId = 9999999;
       

        vm.transactions = [
            {
                "Id": 1,
                "Description": "Agua Enero",
                "Amount": 4975,
                "Type": "Charge",
                "Date": "1/1/2020"
            },
            {
                "Id": 2,
                "Description": "Agua Febrero",
                "Amount": 2500,
                "Type": "Charge",
                "Date": "1/1/2020"
            },
            {
                "Id": 3,
                "Description": "Cuota Enero",
                "Amount": 1111,
                "Type": "Charge",
                "Date": "1/1/2020"
            },
            {
                "Id": 3,
                "Description": "Pago Cuota Enero",
                "Amount": 1111,
                "Type": "Payment",
                "Date": "1/1/2020"
            }
        ];

      
        vm.payment = {
            CondoId: 1,
            Amount: 0,
            Description: "",
            CreatedBy: "postmanHardCodedUser"
        };


        var pageMode = {
            MAIN: 'Main',
            PAYMENT: 'Payment',
            TRANSACTIONS: 'Transactions'

        };

        vm.uiState = {
            mode: pageMode.MAIN,
            isMainAreaVisible: true,
            isViewTransactionsVisible: true,
            isAddPaymentVisible: false,
            isValid: true,
            messages: []
        };


        function cancelClick() {
            setUIState(pageMode.MAIN);
        }

      

        function processPayment(someObject) {
            dataService.post(
                "http://localhost:11618/api/Transactions/CreateCondoCharge",
                vm.payment)
              .then(function (result) {
                  // Update product object
                  vm.payment = result.data;

                  //// Add Product to Array
                  //vm.surveys.push(vm.survey);
                //  getMemberList();
                  //setUIState(pageMode.MAIN);
              }, function (error) {
                  handleException(error);
              });
            // alert("general charge success!!");
            // console.log(someObject);

           

            setUIState(pageMode.MAIN);
        }


        //change view functions
     

        function addPayment(id) {
            vm.testId = id;
            setUIState(pageMode.PAYMENT);
        }
      
        function viewTransactions(id) {
            vm.testId = id;
            setUIState(pageMode.MAIN);
        }

        function validateData() {
            // Fix up date (IE 11 bug workaround)
            //vm.product.IntroductionDate =
            //        vm.product.IntroductionDate.
            //        replace(/\u200E/g, '');

            vm.uiState.messages = [];

            //if (vm.product.IntroductionDate != null) {
            //    if (isNaN(Date.parse(
            //          vm.product.IntroductionDate))) {
            //        addValidationMessage('IntroductionDate',
            //          'Invalid Introduction Date');
            //    }
            //}

            //if (vm.product.Url.
            //  toLowerCase().indexOf("microsoft") >= 0) {
            //    addValidationMessage('url', 'URL can not contain the words\'microsoft\'.');
            //}

            vm.uiState.isValid = (vm.uiState.messages.length == 0);

            return vm.uiState.isValid;
        }

        function setUIState(state) {
            vm.uiState.mode = state;

            vm.uiState.isDetailAreaVisible = (state === pageMode.MAIN);
            vm.uiState.isAddPaymentVisible = (state === pageMode.PAYMENT);
            vm.uiState.isViewTransactionsVisible = (state === pageMode.MAIN);//TRANSACTIONS
        }

        function initEntity() {
            return {
                Id: 0,
                Name: ''
            };
        }

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


        //execute on load
        viewTransactions(1);
    }
})();