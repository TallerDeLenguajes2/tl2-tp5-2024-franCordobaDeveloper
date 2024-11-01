using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp5_2024_franCordobaDeveloper.models
{
    public class PresupuestosDetalle
    {
        public required Productos producto {get; set;}
        public int cantidad { get; set; }
    }
}