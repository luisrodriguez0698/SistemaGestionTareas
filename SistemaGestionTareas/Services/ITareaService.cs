using SistemaGestionTareas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTareas.Services
{
    public interface ITareaService
    {
        IEnumerable<Tarea> GetListTareas();
        Tarea CreateTarea(Tarea tarea);
        Tarea GetTarea(int id);
        Tarea UpdateTarea(int id, Tarea tarea);
        void DeleteTarea(int id);
    }
}
