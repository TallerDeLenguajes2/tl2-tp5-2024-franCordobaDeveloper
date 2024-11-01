using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using tl2_tp5_2024_franCordobaDeveloper.models;
using tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces;

namespace tl2_tp5_2024_franCordobaDeveloper.Repositorios
{
    public class ProductosRepository : IProductoRepository
    {

        private readonly string CadenaDeConexion = "Data Source=db/Tienda.db;Cache=Shared";                                                                                    
        public void CrearProducto(Productos producto)
        {
            var queryString = @"
                INSERT INTO Productos (Descripcion, Precio)
                Values($descripcion, $precio) "; 
            using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
            {
                var command = new SqliteCommand(queryString, connection);
                command.Parameters.AddWithValue("$descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("$precio", producto.Precio);
        
                connection.Open();
                command.ExecuteNonQuery();
            }
            
        }

        public void EliminarProductoPorId(int id)
        {
            var queryString = @"
            DELETE FROM Productos
            WHERE idProducto = $id;
            ";
            
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