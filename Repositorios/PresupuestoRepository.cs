using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using tl2_tp5_2024_franCordobaDeveloper.models;
using tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces;

namespace tl2_tp5_2024_franCordobaDeveloper.Repositorios
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private readonly string CadenaDeConexion = "Data Source=db/Tienda.db;Cache=Shared";                                                                               
        public void AgregarProductoAlPresupuesto(int idPresupuesto, PresupuestosDetalle detalle)
        {
            string queryString = @"
                INSERT INTO PresupuestoDetalle (idPresupuesto, idProducto, Cantidad)
                VALUES ($idPresupuesto, $idProducto, $cantidad)
            ";
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue($"idPresupuesto", idPresupuesto);
            command.Parameters.AddWithValue($"idProducto", detalle.Producto.idProductos);
            command.Parameters.AddWithValue($"cantidad", detalle.cantidad);

            command.ExecuteNonQuery();
        }

        public void CrearPresupuesto(Presupuestos presupuesto)
        {
            var queryString = @"
                INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion)
                VALUES($nombreDestinatario, $fechaCreacion)
            ";
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue($"nombreDestinatario", presupuesto.NombreDestinatario);
            command.Parameters.AddWithValue($"fechaCreacion", presupuesto.FechaCreacion);

            command.ExecuteNonQuery();
        }

        public void EliminarPresupuesto(int id)
        {
            var queryString = @"
            DELETE FROM Presupuestos
            WHERE   IdPresupuesto = @id;
            ";
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue("$id", id);

            command.ExecuteNonQuery();
        }

        public List<Presupuestos> ListarPresupuestos()
        {
            var presupuestos = new List<Presupuestos>();

            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Presupuestos";


            using(var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    presupuestos.Add(new Presupuestos {
                        IdPresupuesto      = reader.GetInt32(0),
                        NombreDestinatario = reader.GetString(1),
                        FechaCreacion      = reader.GetDateTime(2),
                        detalle            = ObtenerPresupuestoDetalle(reader.GetInt32(0))
                    });
                }
            }

            return presupuestos;
        }

        public void ModificarPresupuesto(int id, Presupuestos presupuesto)
        {
            var queryString = @"UPDATE Presupuestos SET
                IdPresupuesto      = $idPresupuesto, 
                NombreDestinatario = $nombreDestinatario,
                FechaCreacion      = $fechaCreacion
                WHERE idPresupuesto = @id
                ";

            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue($"idPresupuesto", id);
            command.Parameters.AddWithValue($"nombreDestinatario", presupuesto.NombreDestinatario);
            command.Parameters.AddWithValue($"fechaCreacion", presupuesto.FechaCreacion);
            

            command.ExecuteNonQuery();
        }

        private List<PresupuestosDetalle> ObtenerPresupuestoDetalle(int idPresupuesto)
        {
            var detalles = new List<PresupuestosDetalle>();

            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM PresupuestoDetalle WHERE IdPresupuesto = $idPresupuesto";
            command.Parameters.AddWithValue($"IdPresupuesto", idPresupuesto);

            using(var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    detalles.Add(new PresupuestosDetalle {
                        Producto = new ProductosRepository(CadenaDeConexion).ObtenerProductosPorId(reader.GetInt32(1)),
                        cantidad = reader.GetInt32(2)
                    });
                }
            }

            return detalles;
        }
    }
}