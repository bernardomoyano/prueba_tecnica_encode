using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dto;

namespace Data.Parameters.Category
{
    public class GetAllCategoriesResponse
    {
        public List<CategoryDto> Categories { get; set; }
    }
}
