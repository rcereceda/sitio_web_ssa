using System;
using System.Collections.Generic;
using System.Data.Entity.Database;

namespace SitioWeb.Models
{
    public class SitioWebInitializer : DropCreateDatabaseIfModelChanges<SitioWebEntities>
    {
        protected override void Seed(SitioWebEntities context)
        {
            var categorias = new List<Categoria> { 
 
                 new Categoria { Nombre = "Noticias"} 
                 
             };

            categorias.ForEach(d => context.Categorias.Add(d));

            var noticias = new List<Noticia> { 
 
                 new Noticia { Titulo = "Exitosa Participación del Servicio de Salud Atacama en Plaza Gobierno en Terreno",  
                             Slug = "exitosa-participacion-del-servicio-de-salud-atacama-en-plaza-gobierno-en-terreno",
                             Fecha=DateTime.Parse("2011-3-29"),  
                             Imagen="/Content/img/img_Noticias/DSC09404.JPG",
                             Texto="<p>Con la presencia de diversos servicios públicos se realizó la primera “<strong>Plaza Gobierno en Terreno”</strong> en la comuna de Copiapó. Esta estuvo ubicada en calle Lastarria, sector feria. El Programa <em>Plaza Gobierno en Terreno</em>, responde a la necesidad de implementar medidas tendientes a facilitar la difusión y el acceso fácil y oportuno de todos los habitantes de la comuna sobre el conocimiento de las principales políticas, planes, programas y prestaciones que otorgan los servicios e instituciones públicas.</p>", 
                             CategoriaId=1}, 
 
                 new Noticia { Titulo = "Los Tachuelas visitaron a los niños y niñas del Hospital Regional de Copiapó",  
                             Slug = "los-tachuelas-visitaron-a-los-ninos-y-ninas-del-hospital-regional-de-copiapo",
                             Fecha=DateTime.Parse("2011-4-5"),  
                             Imagen="/Content/img/img_Noticias/DSC09498.JPG",
                             Texto="<p>En una iniciativa encabezada por el Gobierno Regional, el Seremi de Gobierno, y del Diputado Carlos Vilches en conjunto con la compañía de Circo “Los Tachuelas”, se gestionó una visita al Servicio de Pediatría del Hospital Regional de Copiapó, todo ello enmarcado en las políticas de responsabilidad social del Gobierno del Presidente Sebastián Piñera y de mencionada compañía circense, con los niños y niñas de Chile.</p>", 
                             CategoriaId=1},  
             };

            noticias.ForEach(d => context.Noticias.Add(d));
            
        }

    }
}