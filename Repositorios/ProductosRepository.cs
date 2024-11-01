using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp5_2024_franCordobaDeveloper.models;
using tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces;

namespace tl2_tp5_2024_franCordobaDeveloper.Repositorios
{
    public class ProductosRepository : IProductoRepository
    {

                                                                                                         
        public void CrearProducto(Productos producto)
        {
            var queryString = ""; 
        }

        public void EliminarProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Productos> ListarProductos()
        {
            throw new NotImplementedException();
        }

        public void ModificarProducto(int id, Productos producto)
        {
            throw new NotImplementedException();
        }

        public Productos ObtenerProductosPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}