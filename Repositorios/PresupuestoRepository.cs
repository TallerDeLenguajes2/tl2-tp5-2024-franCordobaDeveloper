using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using tl2_tp5_2024_franCordobaDeveloper.models;
using tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces;

namespace tl2_tp5_2024_franCordobaDeveloper.Repositorios
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private readonly string CadenaDeConexion;

        public PresupuestoRepository(string cadenaDeConexion)
        {
            this.CadenaDeConexion = cadenaDeConexion;
        }

        public void AgregarProductoAlPresupuesto(int idPresupuesto, PresupuestosDetalle detalle)
        {
            var queryString = @"
                INSERT INTO PresupuestosDetalle (IdPresupuesto, idProducto, Cantidad)
                VALUES ($idPresupuesto, $idProducto, $cantidad)
            ";
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue("$idPresupuesto", idPresupuesto);
            command.Parameters.AddWithValue("$idProducto", detalle.Producto.idProductos);
            command.Parameters.AddWithValue("$cantidad", detalle.Cantidad);  // Cambiado `cantidad` a `Cantidad`

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

            command.Parameters.AddWithValue("$nombreDestinatario", presupuesto.NombreDestinatario);
            command.Parameters.AddWithValue("$fechaCreacion", presupuesto.FechaCreacion);

            command.ExecuteNonQuery();
        }

        public void EliminarPresupuesto(int id)
        {
            var queryString = @"
            DELETE FROM Presupuestos
            WHERE IdPresupuesto = $id;
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

        public Presupuestos? ObtenerPresupuestoPorId(int id)  // Agregado `?` para permitir nulo
        {
            var queryString = @"
                SELECT * FROM Presupuestos WHERE IdPresupuesto = $id
            ";

            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            if(reader.Read())
            {
                return new Presupuestos{
                    IdPresupuesto = reader.GetInt32(0),
                    NombreDestinatario = reader.GetString(1),
                    FechaCreacion = reader.GetDateTime(2), 
                    detalle = ObtenerPresupuestoDetalle(reader.GetInt32(0))
                };
            }

            return null;
        }

        public void ModificarPresupuesto(int id, Presupuestos presupuesto)
        {
            var queryString = @"UPDATE Presupuestos SET
                NombreDestinatario = $nombreDestinatario,
                FechaCreacion      = $fechaCreacion
                WHERE IdPresupuesto = $id
                ";

            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$nombreDestinatario", presupuesto.NombreDestinatario);
            command.Parameters.AddWithValue("$fechaCreacion", presupuesto.FechaCreacion);

            command.ExecuteNonQuery();
        }

        private List<PresupuestosDetalle> ObtenerPresupuestoDetalle(int idPresupuesto)
        {
            var detalles = new List<PresupuestosDetalle>();

            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM PresupuestosDetalle WHERE IdPresupuesto = $idPresupuesto";
            command.Parameters.AddWithValue("$idPresupuesto", idPresupuesto);

            using(var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    detalles.Add(new PresupuestosDetalle {
                        Producto = new ProductosRepository(CadenaDeConexion).ObtenerProductosPorId(reader.GetInt32(1))!,
                        Cantidad = reader.GetInt32(2)
                    });
                }
            }

            return detalles;
        }
    }
}
