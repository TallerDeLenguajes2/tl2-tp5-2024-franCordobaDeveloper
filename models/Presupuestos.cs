using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp5_2024_franCordobaDeveloper.models
{
    public class Presupuestos
    {
        public int IdPresupuesto { get; set; }
        public required string nombreDestinatario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public required List<PresupuestosDetalle>  detalle { get; set; }

        // Metodos

        public decimal MontoPresupuesto ()
        {
           return detalle.Sum(d => d.producto.Precio * d.cantidad);
        }

        public decimal MontoPresupuestoConIva()
        {
            return MontoPresupuesto() * 1.21M; // con el subfijo M convierto el numero en dicimal
        }

        public int CantidadProductos()
        {
            return detalle.Sum(p => p.cantidad); // Sum lo utilizo para sumar todos los elementos de una coleccion
        }
    }
}