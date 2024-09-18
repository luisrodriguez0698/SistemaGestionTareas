using SistemaGestionTareas.Models;
using SistemaGestionTareas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace SistemaGestionTareas.Controllers
{
    [RoutePrefix("api/tareas")]
    public class TareasController : ApiController
    {
        private readonly ITareaService _tareaService;

        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        // GET: api/tareas
        [HttpGet]
        public IHttpActionResult GetListTareas()
        {
            try
            {
                var tareas = _tareaService.GetListTareas();
                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/tareas
        [HttpPost]
        public IHttpActionResult CreateTarea([FromBody] Tarea nuevaTarea)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tarea = _tareaService.CreateTarea(nuevaTarea);
                return Created(new Uri(Request.RequestUri + "/" + tarea.Id), tarea);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/tareas/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetTarea(int id)
        {
            try
            {
                var tarea = _tareaService.GetTarea(id);
                return Ok(tarea);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/tareas/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateTarea(int id, [FromBody] Tarea tareaActualizada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tarea = _tareaService.UpdateTarea(id, tareaActualizada);
                return Ok(tarea);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/tareas/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteTarea(int id)
        {
            try
            {
                _tareaService.DeleteTarea(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
