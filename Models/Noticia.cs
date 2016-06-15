using System;
using System.Runtime.Serialization;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SitioWeb.Models
{
    public class Noticia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el título")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [StringLength(100)]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese la imagen")]
        [StringLength(100)]
        [HiddenInput(DisplayValue = false)]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "Ingrese la noticia")]
        [StringLength(Int32.MaxValue)]
        [AllowHtml]
        public string Texto { get; set; }

        [Required(ErrorMessage = "Ingrese la categoría")]
        [Range(1, 5, ErrorMessage = "La categoría debe estar entre 1 y 5")]
        public int CategoriaId { get; set; }

        virtual public Categoria Categoria { get; set; }        
    }    
}