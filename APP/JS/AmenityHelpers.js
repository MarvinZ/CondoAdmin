angular
  .module('AmenityApp')
  .factory('alert', function ($uibModal) {

      function show(action, event) {
          return $uibModal.open({
              templateUrl: '/Content/Templates/modalContent.html',
              controller: function () {
                  var vm = this;
                  vm.action = action;
                  vm.event = event;
              },
              controllerAs: 'vm'
          });
      }

      return {
          show: show
      };

  })
.factory('alert2', function ($uibModal) {

    function show(action, event) {
        return $uibModal.open({
            templateUrl: '/Content/Templates/newRSVmodalContent.html',
            controller: function ($scope, $uibModalInstance) {
                var vm = this;
                vm.action = action;
                vm.event = event;
                
                $scope.open = function ($event) {
                    $event.preventDefault();
                    $event.stopPropagation();

                    $scope.opened = true;
                };

            },
            controllerAs: 'vm'
        });
    }

    return {
        show: show
    };

});