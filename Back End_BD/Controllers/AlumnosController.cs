using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Back_End_BD.Models;


namespace Back_End_BD.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using(AlumnoDBContext dbAlumno=new AlumnoDBContext())
            {
                return View(dbAlumno.Alumnos.ToList());
            }
            
        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDBContext dbAlumno = new AlumnoDBContext())
            {
                Alumnos alumnos = dbAlumno.Alumnos.Find(id);

                if(alumnos== null)
                {
                    return HttpNotFound();
                }
                return View(alumnos);
            }

        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Alumnos alum)
        {
           using (AlumnoDBContext dbAlumno = new AlumnoDBContext())
            {
                dbAlumno.Alumnos.Add(alum);
                dbAlumno.SaveChanges();
            }
           return RedirectToAction("Index");

        }

        
        public ActionResult Edit(int? id)
        {
            using (AlumnoDBContext dbAlumno = new AlumnoDBContext())
            {
                return View(dbAlumno.Alumnos.Where(x=>x.Id==id).FirstOrDefault());
            }
            

        }


        [HttpPost]
        public ActionResult Edit(Alumnos alum)
        {
            using (AlumnoDBContext dbAlumno = new AlumnoDBContext())
            {
                dbAlumno.Entry(alum).State=EntityState.Modified;
                dbAlumno.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDBContext dbAlumno = new AlumnoDBContext())
            {
                return View(dbAlumno.Alumnos.Where(XmlSiteMapProvider => XmlSiteMapProvider.Id == id).FirstOrDefault());
            } 
        }



        [HttpPost]

        public ActionResult Delete(Alumnos alum, int? id)
        {
            using (AlumnoDBContext dbAlumno = new AlumnoDBContext())
            {
                Alumnos al= dbAlumno.Alumnos.Where(x=>x.Id==id).FirstOrDefault();
                dbAlumno.Alumnos.Remove(al);
                dbAlumno.SaveChanges();
            }
            return RedirectToAction("Index");
               
        }





    }
}