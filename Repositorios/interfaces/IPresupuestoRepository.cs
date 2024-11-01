using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp5_2024_franCordobaDeveloper.models;

namespace tl2_tp5_2024_franCordobaDeveloper.Repositorios.interfaces
{
    public interface IPresupuestoRepository
    {
        void CrearPresupuesto(Presupuestos presupuesto);
        void ModificarPresupuesto(int id, Presupuestos presupuesto);
        List<Presupuestos> ListarPresupuestos();
        void AgregarProductoAlPresupuesto(int idPresupuesto, PresupuestosDetalle detalle);
        void EliminarPresupuesto(int id);
    }
}