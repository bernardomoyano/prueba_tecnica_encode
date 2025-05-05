using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameters.Category
{
    public class PostCategoryRequest
    {
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; }
    }
}
