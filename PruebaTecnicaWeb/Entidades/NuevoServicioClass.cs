using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaWeb.Entidades
{
    public class NuevoServicioClass
    {
        public int ID_Servicio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Monto { get; set; }
    }
}