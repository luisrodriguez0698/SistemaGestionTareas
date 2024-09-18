var app = angular.module('taskManagerApp', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "wwwroot/app/views/listaTareas.html",
            controller: "TareasController"
        })
        .when("/crear", {
            templateUrl: "wwwroot/app/views/crearTarea.html",
            controller: "TareasController"
        })
        .when("/editar/:id", {
            templateUrl: "wwwroot/app/views/editarTarea.html",
            controller: "TareasController"
        })
        .otherwise({
            redirectTo: "/"
        });
});
