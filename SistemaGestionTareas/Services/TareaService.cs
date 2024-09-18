using SistemaGestionTareas.Data;
using SistemaGestionTareas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGestionTareas.Services
{
    public class TareaService : ITareaService
    {
        private readonly TaskManagerContext _context;

        public TareaService(TaskManagerContext context)
        {
            _context = context;
        }

        public Tarea CreateTarea(Tarea nuevaTarea)
        {
            try
            {
                if (nuevaTarea == null)
                {
                    throw new ArgumentNullException("La tarea no puede ser nula.");
                }
                else
                {
                    nuevaTarea.FechaCreacion = DateTime.Now;
                }

                _context.Tareas.Add(nuevaTarea);
                _context.SaveChanges();
                return nuevaTarea;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la tarea.", ex);
            }
        }

        public void DeleteTarea(int id)
        {
            try
            {
                var tarea = _context.Tareas.Find(id);
                if (tarea == null)
                {
                    throw new KeyNotFoundException("No se encontró la tarea con el ID especificado.");
                }

                _context.Tareas.Remove(tarea);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la tarea.", ex);
            }
        }

        public IEnumerable<Tarea> GetListTareas()
        {
            try
            {
                return _context.Tareas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las tareas.", ex);
            }
        }

        public Tarea GetTarea(int id)
        {
            try
            {
                return _context.Tareas.Find(id);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la tarea.", ex);
            }
        }

        public Tarea UpdateTarea(int id, Tarea tareaActualizada)
        {
            try
            {
                var tarea = _context.Tareas.Find(id);
                if(tarea == null)
                {
                    throw new KeyNotFoundException("No se encontró la tarea con el ID especificado.");
                }

                tarea.Titulo = tareaActualizada.Titulo;
                tarea.Descripcion = tareaActualizada.Descripcion;
                tarea.Estado = tareaActualizada.Estado;

                _context.Entry(tarea).State = EntityState.Modified;
                _context.SaveChanges();
                return tarea;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la tarea.", ex);
            }
        }
    }
}