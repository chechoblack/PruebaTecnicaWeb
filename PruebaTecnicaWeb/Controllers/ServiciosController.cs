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
    }
}