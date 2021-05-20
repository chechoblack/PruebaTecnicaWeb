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
        public ActionResult EditarVehiculo(int id)
        {
            VehiculoClass model = new VehiculoClass();
            using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
            {
                var pVehiculo = db.Vehiculo.Find(id);
                model.Placa = pVehiculo.Placa;
                model.Dueno = pVehiculo.Dueno;
                model.Marca = pVehiculo.Marca;
                model.IdVehiculo = pVehiculo.ID_Vehiculo;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditarVehiculo(NuevoVehiculoClass model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
                    {
                        var pVehiculo = db.Vehiculo.Find(model.IdVehiculo);
                        pVehiculo.Placa = model.Placa;
                        pVehiculo.Dueno = model.Dueno;
                        pVehiculo.Marca = model.Marca;
                        pVehiculo.ID_Vehiculo = model.IdVehiculo;

                        db.Entry(pVehiculo).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Vehiculo");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult EliminarVehiculo(int id)
        {
            VehiculoClass model = new VehiculoClass();
            using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
            {

                var pVehiculo = db.Vehiculo.Find(id);
                db.Vehiculo.Remove(pVehiculo);
                db.SaveChanges();

                return Redirect("~/Vehiculo");

            }
        }
    }
}