using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

using SitioWeb.Models;
using SitioWeb.Helpers;

namespace SitioWeb.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        SitioWebEntities db = new SitioWebEntities();        

        // 
        // GET: /Home/Index

        public ActionResult Index(int? page)
        {            
            const int pageSize = 5;            

            var noticias = db.Noticias
                .Where(m => m.CategoriaId == 1)
                .OrderByDescending(m => m.Fecha);

            var paginated = new PaginatedList<Noticia>(noticias, page ?? 0, pageSize);

            return View(paginated);
        }

        // 
        // GET: /Home/Conozcanos

        public ActionResult Conozcanos()
        {
            return View();            
        }

        // 
        // GET: /Home/Urgencia

        public ActionResult Urgencia()
        {
            return View();
        }

        // 
        // GET: /Home/Comunicaciones

        public ActionResult Comunicaciones()
        {
            return View();
        }

        // 
        // GET: /Home/Programas

        public ActionResult Programas()
        {
            return View();
        }

        // 
        // GET: /Home/IRA

        public ActionResult IRA()
        {
            return View();
        }

        // 
        // GET: /Home/Adulto

        public ActionResult Adulto()
        {
            return View();
        }

        // 
        // GET: /Home/SaludMental

        public ActionResult SaludMental()
        {
            return View();
        }

        // 
        // GET: /Home/Chagas

        public ActionResult Chagas()
        {
            return View();
        }

        // 
        // GET: /Home/Infantil

        public ActionResult Infantil()
        {
            return View();
        }

        // 
        // GET: /Home/Mujer

        public ActionResult Mujer()
        {
            return View();
        }

        // 
        // GET: /Home/ChileCrece

        public ActionResult ChileCrece()
        {
            return View();
        }

        // 
        // GET: /Home/VIH

        public ActionResult VIH()
        {
            return View();
        }

        // 
        // GET: /Home/Tuberculosis

        public ActionResult Tuberculosis()
        {
            return View();
        }

        // 
        // GET: /Home/Adolescente

        public ActionResult Adolescente()
        {
            return View();
        }

        // 
        // GET: /Home/CancerMamas

        public ActionResult CancerMamas()
        {
            return View();
        }

        // 
        // GET: /Home/CancerCervico

        public ActionResult CancerCervico()
        {
            return View();
        }

        // 
        // GET: /Home/Cardiovascular

        public ActionResult Cardiovascular()
        {
            return View();
        }

        // 
        // GET: /Home/Odontologico

        public ActionResult Odontologico()
        {
            return View();
        }

        // 
        // GET: /Home/Nutricion

        public ActionResult Nutricion()
        {
            return View();
        }

        // 
        // GET: /Home/PESPI

        public ActionResult PESPI()
        {
            return View();
        }

        // 
        // GET: /Home/SAPU

        public ActionResult SAPU()
        {
            return View();
        }

        // 
        // GET: /Home/Emergencia

        public ActionResult Emergencia()
        {
            return View();
        }

        // 
        // GET: /Home/SAMU

        public ActionResult SAMU()
        {
            return View();
        }


        // 
        // GET: /Home/COE

        public ActionResult COE()
        {
            return View();
        }        

        // 
        // GET: /Home/ComunicacionesRRPP

        public ActionResult ComunicacionesRRPP()
        {
            return View();
        }

        // 
        // GET: /Home/OIRS

        public ActionResult OIRS()
        {
            return View();
        }

        // 
        // GET: /Home/Participacion

        public ActionResult Participacion()
        {
            return View();
        }

        // 
        // GET: /Home/HospitalHuasco

        public ActionResult HospitalHuasco()
        {
            return View();
        }

        // 
        // GET: /Home/HospitalChanaral

        public ActionResult HospitalChanaral()
        {
            return View();
        }

        // 
        // GET: /Home/Inversiones

        public ActionResult Inversiones(int? page)
        {
            const int pageSize = 5;

            var noticias = db.Noticias
                .Where(m => m.CategoriaId == 2)
                .OrderByDescending(m => m.Fecha);

            var paginated = new PaginatedList<Noticia>(noticias, page ?? 0, pageSize);

            return View(paginated);
        }

        // 
        // GET: /Home/Noticias

        public ActionResult Noticias(int? year, int? month, int? day, int? page)
        {
            const int pageSize = 10;

            //int dayId = -1;
            //int monthId = -1;
            //int yearId = -1;

            var noticias = db.Noticias
                .Where(m => m.CategoriaId == 1);

            //if (int.TryParse(day, out dayId))
            if(day > 0)
                noticias = noticias.Where(m => m.Fecha.Day == day);
            //if (int.TryParse(month, out monthId))
            if (month > 0)
                noticias = noticias.Where(m => m.Fecha.Month == month);
            //if (int.TryParse(year, out yearId))
            if (year > 0)
                noticias = noticias.Where(m => m.Fecha.Year == year);

            noticias = noticias.OrderByDescending(m => m.Fecha);

            var paginated = new PaginatedList<Noticia>(noticias, page ?? 0, pageSize);            
            
            return View(paginated);
        }

        // 
        // GET: /Home/Leer

        public ActionResult Leer(string slug)
        {
            Noticia noticia = null;
            if (slug != "")
                noticia = db.Noticias.Single(m => m.Slug == slug);
            
            if (noticia == null)
                return RedirectToAction("Index");
            return View("Leer", noticia);
        }        
    }
}
