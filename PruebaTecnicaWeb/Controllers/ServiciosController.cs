using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnicaWeb.Entidades;
using PruebaTecnicaWeb.AccesoDatos;
namespace PruebaTecnicaWeb.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: Servicios
        public ActionResult Index()
        {
            List<ServicioClass> lst;
            using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
            {
                lst = (from d in db.Servicios
                       select new ServicioClass
                       {
                           ID_Servicio = d.ID_Servicio,
                           Descripcion = d.Descripcion,
                           Monto = d.Monto

                       }).ToList();

            }
            return View(lst);
        }
        public ActionResult NuevoServicio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoServicio(NuevoServicioClass model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
                    {
                        var pServicio = new Servicios();
                        pServicio.Descripcion = model.Descripcion;
                        pServicio.Monto = model.Monto;

                        db.Servicios.Add(pServicio);
                        db.SaveChanges();
                    }
                    return Redirect("~/Servicios");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult EditarServicio(int id)
        {
            ServicioClass model = new ServicioClass();
            using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
            {
                var pServicio = db.Servicios.Find(id);
                model.Descripcion = pServicio.Descripcion;
                model.Monto = pServicio.Monto;
                model.ID_Servicio = pServicio.ID_Servicio;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditarServicio(ServicioClass model)
        {
            try
            {            
                if (ModelState.IsValid)
                {
                    using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
                    {
                        var pServicio = db.Servicios.Find(model.ID_Servicio);
                        pServicio.Descripcion = model.Descripcion;
                        pServicio.Monto = model.Monto;
                        pServicio.ID_Servicio = model.ID_Servicio;

                        db.Entry(pServicio).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Servicios");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult EliminarServicio(int id)
        {
            ServicioClass model = new ServicioClass();
            using (PruebaTecnicaEntities db = new PruebaTecnicaEntities())
            {
                
                var pServicio = db.Servicios.Find(id);
                db.Servicios.Remove(pServicio);
                db.SaveChanges();

                return Redirect("~/Servicios");

            }
            return View(model);
        }
    }
}