using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dto;

namespace Data.Parameters.Product
{
    public class GetAllProductsResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}
