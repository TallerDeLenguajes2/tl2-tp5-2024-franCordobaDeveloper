using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp5_2024_franCordobaDeveloper.models;

namespace tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces
{
    public interface IProductoRepository
    {
        void CrearProducto(Productos producto);
        void ModificarProducto(int id, Productos producto);
        List<Productos> ListarProductos();
        Productos ObtenerProductosPorId(int id);
        void EliminarProductoPorId(int id);

    }
}