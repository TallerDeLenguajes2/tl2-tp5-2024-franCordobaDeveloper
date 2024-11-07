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
            throw new NotImplementedException();
        }

        public void CrearPresupuesto(Presupuestos presupuesto)
        {
            var queryString = @"
            ";
            using SqliteConnection connection = new SqliteConnection(CadenaDeConexion);
            connection.Open();
            var command = new SqliteCommand(queryString, connection);


            command.ExecuteNonQuery();
        }

        public void EliminarPresupuesto(int id)
        {
            throw new NotImplementedException();
        }

        public List<Presupuestos> ListarPresupuestos()
        {
            throw new NotImplementedException();
        }

        public void ModificarPresupuesto(int id, Presupuestos presupuesto)
        {
            throw new NotImplementedException();
        }
    }
}