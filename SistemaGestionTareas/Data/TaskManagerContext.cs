using SistemaGestionTareas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGestionTareas.Data
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base("name=TaskManagerContext") { }

        public DbSet<Tarea> Tareas { get; set; }
    }
}