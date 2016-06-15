using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SitioWeb.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese la Categoría")]
        [StringLength(25)]
        public string Nombre { get; set; }

        public List<Noticia> Noticias { get; set; }
    }
}