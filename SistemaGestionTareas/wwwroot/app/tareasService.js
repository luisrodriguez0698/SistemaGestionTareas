app.factory('tareasService', function ($http) {
    var apiUrl = '/api/tareas'; // URL base de la API

    return {
        getTareas: function () {
            return $http.get(apiUrl);
        },
        crearTarea: function (tarea) {
            return $http.post(apiUrl, tarea);
        },
        getTareaById: function (id) {
            return $http.get(apiUrl + '/' + id);
        },
        editarTarea: function (tarea) {
            return $http.put(apiUrl + '/' + tarea.Id, tarea);
        },
        eliminarTarea: function (id) {
            return $http.delete(apiUrl + '/' + id);
        }
    };
});
