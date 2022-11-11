using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Back_End_BD.Models;


namespace Back_End_BD.Controllers
{
    public class MaestrosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                return View(dbMaestro.Maestros.ToList());
            }

        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                Maestros maestros = dbMaestro.Maestros.Find(id);

                if (maestros == null)
                {
                    return HttpNotFound();
                }
                return View(maestros);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Maestros maes)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                dbMaestro.Maestros.Add(maes);
                dbMaestro.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                return View(dbMaestro.Maestros.Where(x => x.Matricula == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(Maestros maes)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                dbMaestro.Entry(maes).State = System.Data.Entity.EntityState.Modified;
                dbMaestro.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                return View(dbMaestro.Maestros.Where(x => x.Matricula == id).FirstOrDefault());
            }

        }

        [HttpPost]
        public ActionResult Delete(Maestros maes, int? id)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                Maestros ma = dbMaestro.Maestros.Where(x => x.Matricula == id).FirstOrDefault();
                dbMaestro.Maestros.Remove(ma);
                dbMaestro.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}