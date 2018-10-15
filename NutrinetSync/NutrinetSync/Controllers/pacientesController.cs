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

        // GET: pacientes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "pacienteid,nombres,apellidop,apellidom,fechanac,sexo,estadocivil,telefonos,correo,referente,calle,numext,numint,colonia,localidad,municipio,ciudad,ciudadorigen,estado,pais,nombrepadre,nombremadre,ultimaconsulta,peso,talla")] paciente paciente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.paciente.Add(paciente);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(paciente);
        //}

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
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: pacientes/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    paciente paciente = db.paciente.Find(id);
        //    if (paciente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(paciente);
        //}

        // POST: pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "pacienteid,nombres,apellidop,apellidom,fechanac,sexo,estadocivil,telefonos,correo,referente,calle,numext,numint,colonia,localidad,municipio,ciudad,ciudadorigen,estado,pais,nombrepadre,nombremadre,ultimaconsulta,peso,talla")] paciente paciente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(paciente).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(paciente);
        //}

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
