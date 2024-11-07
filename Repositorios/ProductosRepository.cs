using System;
using System.Collections.Generic;
using System.Data;
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
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("$descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("$precio", producto.Precio);

            command.ExecuteNonQuery();

        }

        public void EliminarProductoPorId(int id)
        {
            var queryString = @"
            DELETE FROM Productos
            WHERE idProducto = $id;
            ";
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("$id", id);

            command.ExecuteNonQuery();
        }

        public List<Productos> ListarProductos()
        {
            var productos = new List<Productos>();

            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open(); 
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Productos";

            using(var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    productos.Add(new Productos {
                        idProductos = reader.GetInt32(0),
                        Descripcion = reader.GetString(1),
                        Precio      = reader.GetInt32(2)
                    });
                }
            }

            return productos;
        }

        public void ModificarProducto(int id, Productos producto)
        {
            var queryString = @"UPDATE Productos SET Descripcion = $descripcion, Precio = $precio WHERE idProducto = @id";
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command =  new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue($"descripcion", producto.Descripcion);
            command.Parameters.AddWithValue($"precio", producto.Precio);
            command.Parameters.AddWithValue($"id", id);

            command.ExecuteNonQuery();

        }

        public Productos ObtenerProductosPorId(int id)
        {
            var queryString = @"SELECT * FROM Productos WHERE idProducto = @id";
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue(@"id", id);
            using var reader  = command.ExecuteReader();
            
                if(reader.Read())
                {
                    return new Productos{
                        idProductos = reader.GetInt32(0),
                        Descripcion = reader.GetString(1), 
                        Precio = reader.GetInt32(2)
                    };
                }
            
            return null;
        }

        

    }
}