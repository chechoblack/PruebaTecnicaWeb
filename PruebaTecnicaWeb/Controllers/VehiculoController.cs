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
        
        public ActionResult NuevoVehiculo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoVehiculo(NuevoVehiculoClass model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(PruebaTecnicaEntities db = new PruebaTecnicaEntities())
                    {
                        var pVehiculo = new Vehiculo();
                        pVehiculo.Placa = model.Placa;
                        pVehiculo.Dueno = model.Dueno;
                        pVehiculo.Marca = model.Marca;

                        db.Vehiculo.Add(pVehiculo);
                        db.SaveChanges();                    
                    }
                    return Redirect("~/Vehiculo");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}