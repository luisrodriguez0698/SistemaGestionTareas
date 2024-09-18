
app.controller('TareasController', function ($scope, $http, $location, $routeParams, tareasService) {
    $scope.tareas = [];
    $scope.nuevaTarea = {};
    $scope.editarTarea = {};
    $scope.alert = null;
    $scope.isLoading = true;

    // Mostrar alertas
    function showAlert(type, message) {
        $scope.alert = { type: type, message: message };
        setTimeout(function () {
            $scope.alert = null;
            $scope.$apply();
        }, 3000);
    }

    // Obtener todas las tareas
    tareasService.getTareas().then(function (response) {
        $scope.tareas = response.data;
        $scope.isLoading = false; // Oculta el loader
    });

    // Crear una nueva tarea
    $scope.crearTarea = function () {
        tareasService.crearTarea($scope.nuevaTarea).then(function (response) {
            $location.path("/");
            Swal.fire({
                title: "Tarea creada!",
                text: "Tarea creada con éxito!",
                icon: "success"
            });
        }).catch(function (error) {
            showAlert('danger', 'Error al crear la tarea.');
        });
    };

    // Cargar una tarea para editar
    if ($routeParams.id) {
        tareasService.getTareaById($routeParams.id).then(function (response) {
            $scope.editarTarea = response.data;
        });
    }

    // Editar una tarea
    $scope.actualizarTarea = function () {
        tareasService.editarTarea($scope.editarTarea).then(function (response) {
            $location.path("/");
            Swal.fire({
                title: "Tarea actualizada!",
                text: "Tarea actualizada con éxito!",
                icon: "success"
            });
        }).catch(function (error) {
            showAlert('danger', 'Error al actualizar la tarea.');
        });
    };

    // Eliminar una tarea
    $scope.eliminarTarea = function (id) {
        Swal.fire({
            title: '¿Estás seguro?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, eliminar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                tareasService.eliminarTarea(id).then(function () {
                    $scope.tareas = $scope.tareas.filter(t => t.Id !== id);
                    showAlert('success', 'Tarea eliminada con éxito.');
                }).catch(function (error) {
                    showAlert('danger', 'Error al eliminar la tarea.');
                });
            }
        });
    };
});
