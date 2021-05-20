using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaWeb.Entidades
{
    public class NuevoVehiculoClass
    {
        public int IdVehiculo { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Placa")]
        public string Placa { get; set; }
        [Required]
        [Display(Name = "Dueno")]
        public string Dueno { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }
    }
}