using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tl2_tp5_2024_franCordobaDeveloper.models;
using tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces;

namespace tl2_tp5_2024_franCordobaDeveloper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresupuestoController : ControllerBase
    {

        private readonly IPresupuestoRepository _repository;

        public PresupuestoController(IPresupuestoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult CrearPresupuesto([FromBody] Presupuestos presupuestos)
        {
            _repository.CrearPresupuesto(presupuestos);
            return Ok();
        }

        [HttpPost("{id:int}/ProductoDetalle")]
        public IActionResult AgregarProductoYPresupuesto(int id,[FromBody] PresupuestosDetalle detalle)
        {
            _repository.AgregarProductoAlPresupuesto(id, detalle);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Presupuestos>> ListarPresupuestos()
        {
            return _repository.ListarPresupuestos();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Presupuestos> GetPresupuestoPorId(int id)
        {
            var presupuesto = _repository.ObtenerPresupuestoPorId(id);
            if (presupuesto == null) 
            { 
                return NotFound(); 
            } 
            
            return presupuesto;
        }

    }
}