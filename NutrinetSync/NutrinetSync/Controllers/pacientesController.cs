using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NutrinetSync.ModeloSys;

namespace NutrinetSync.Controllers
{
    public class pacientesController : Controller
    {
        private nutrinetEntities db = new nutrinetEntities();

        // GET: pacientes
        public ActionResult Index()
        {
            return View(db.paciente.ToList());
        }

        // GET: pacientes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        //GET: pacientes/Historia
        public ActionResult Historia(long? pacienteid)
        {
            if (pacienteid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historias historia = db.historias.Where(h => h.pacienteid == pacienteid).FirstOrDefault();
            paciente paciente = db.paciente.Find(pacienteid);
            if (historia == null)
            {
                return HttpNotFound();
            }

            //Obtiene y guarda la informacion del paciente actual en en ViewBag
            ViewBag.NombreCompleto = paciente.nombres + " " + paciente.apellidop + " " + paciente.apellidom;
            ViewBag.Edad = Edad(paciente.fechanac);
            ViewBag.Sexo = paciente.sexo;

            return View(historia);
        }

        //POST: pacientes/Historia/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Historia([Bind(Include = "historiaid,pacienteid,historia")] historias historialpaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historialpaciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Informacion", new { id = historialpaciente.pacienteid });
            }
            return View(historialpaciente);
        }

        // GET: pacientes/Informacion
        public ActionResult Informacion(long? id)
        {
            if (id == null)
            {
                //Se notifica que es alta
                ViewBag.Message = "alta";

                return View();
            }

            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }

            //Se notifica que es modificacion
            ViewBag.Message = "modificacion";
            ViewBag.id = id;

            return View(paciente);
        }

        //POST: pacientes/Informacion/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Informacion([Bind(Include = "pacienteid,nombres,apellidop,apellidom,fechanac,sexo,estadocivil,telefonos,correo,referente,calle,numext,numint,colonia,localidad,municipio,ciudad,ciudadorigen,estado,pais,nombrepadre,nombremadre,ultimaconsulta,peso,talla")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                if (paciente.pacienteid > 0)
                {
                    db.Entry(paciente).State = EntityState.Modified;
                }
                else
                {
                    db.paciente.Add(paciente);

                    //Si es alta, se crea tambien el registro de historia
                    historias historia = new historias();
                    historia.pacienteid = paciente.pacienteid;
                    historia.historia = "";

                    db.historias.Add(historia);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: pacientes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            paciente paciente = db.paciente.Find(id);
            db.paciente.Remove(paciente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public int Edad(DateTime FechaNacimiento)
        {
            int edad = DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1;

            return edad;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
