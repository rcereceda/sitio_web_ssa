using System.Data.Entity;

namespace SitioWeb.Models
{
    public class SitioWebEntities : DbContext
    {
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }       
    }
}