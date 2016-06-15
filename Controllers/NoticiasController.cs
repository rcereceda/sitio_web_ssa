using SitioWeb.Models;
using System.Linq;
using System;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc.Examples;
using System.Collections.Generic;

using SitioWeb.Helpers;

namespace SitioWeb.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class NoticiasController : Controller
    {
        SitioWebEntities db = new SitioWebEntities();

        private List<SelectListItem> GetCategorias()
        {
            var categorias = db.Categorias
                             .OrderByDescending(m => m.Nombre)
                             .Select(m => new
                             {                                
                                Nombre = m.Nombre,
                                Value = m.Id
                             });

            var _categorias = categorias.AsEnumerable()
                              .Select(m => new SelectListItem 
                              {
                                  Text = m.Nombre,
                                  Value = m.Value.ToString()                                
                              });

            return _categorias.ToList();
        }

        public ActionResult Index(int? page)
        {
            const int pageSize = 10;

            var noticias = db.Noticias                
                .OrderByDescending(m => m.Fecha);

            var paginated = new PaginatedList<Noticia>(noticias, page ?? 0, pageSize);

            return View(paginated);
        }
        
        // 
        // GET: /Noticias/Create
        [ValidateInput(false)]
        [CultureAwareAction]
        public ActionResult Create(string editor)
        {            
            if (editor != null)
            {
                ViewData["editor"] = editor;
                ViewData["value"] = HttpUtility.HtmlEncode(editor.IndentHtml());
            }

            ViewData["fecha"] = DateTime.Today;
            ViewData["categorias"] = GetCategorias();

            return View();
        }
        
        // 
        // POST: /Noticias/Create

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Noticia newNoticia)
        {            
            if (ModelState.IsValid)
            {
                newNoticia.Slug = TitleHelper.URLFriendly(newNoticia.Titulo);
                db.Noticias.Add(newNoticia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(newNoticia);
            }
        }

        // 
        // GET: /Noticias/Details 

        public ActionResult Details(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
                return RedirectToAction("Index");
            return View("Details", noticia);
        }

        // 
        // GET: /Noticias/Edit 

        public ActionResult Edit(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
                return RedirectToAction("Index");

            ViewData["fecha"] = noticia.Fecha;
            ViewData["categorias"] = GetCategorias();

            return View(noticia);
        }

        // 
        // POST: /Noticias/Edit 

        [HttpPost]        
        public ActionResult Edit(Noticia model)
        {
            try
            {
                var noticia = db.Noticias.Find(model.Id);

                UpdateModel(noticia);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = model.Id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Falló");
            }

            return View(model);
        }

        // 
        // GET: /Noticias/Delete

        public ActionResult Delete(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
                return RedirectToAction("Index");
            return View(noticia);
        }

        // 
        // POST: /Noticias/Delete 

        [HttpPost]
        public RedirectToRouteResult Delete(int id, FormCollection collection)
        {
            Noticia noticia = db.Noticias.Find(id);
            db.Noticias.Remove(noticia);
            db.SaveChanges();

            return RedirectToAction("Index");
        }        
    }
}