using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
