using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo no puede superar los 100 caracteres")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un número positivo.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
