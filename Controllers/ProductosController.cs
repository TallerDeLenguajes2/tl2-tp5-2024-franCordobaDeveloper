using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tl2_tp5_2024_franCordobaDeveloper.models;
using tl2_tp5_2024_franCordobaDeveloper.Repositorios;
using tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces;

namespace tl2_tp5_2024_franCordobaDeveloper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repository;
        
        public ProductosController(IProductoRepository repository)
        {
            _repository = repository;
        }

        
        [HttpPost]
        public IActionResult CrearProducto([FromBody] Productos producto)
        {
            _repository.CrearProducto(producto);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<List<Productos>> ListarProductos()
        {
            return _repository.ListarProductos();
        }

        [HttpPut("{id:int}")]
        public ActionResult ModificarProducto(int id, [FromBody] Productos producto)
        {
            _repository.ModificarProducto(id, producto);
            return Ok();
        }


    }
}