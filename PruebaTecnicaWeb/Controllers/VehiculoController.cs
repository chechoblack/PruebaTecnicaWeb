using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnicaWeb.Entidades;
using PruebaTecnicaWeb.AccesoDatos;
namespace PruebaTecnicaWeb.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Index()
        {
            List<VehiculoClass> lst;
            using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
            {
                lst = (from d in db.Vehiculo
                       select new VehiculoClass
                       {
                           IdVehiculo = d.ID_Vehiculo,
                           Placa = d.Placa,
                           Dueno = d.Dueno,
                           Marca = d.Marca

                       }).ToList();

            }
            return View(lst);
        }
    }
}