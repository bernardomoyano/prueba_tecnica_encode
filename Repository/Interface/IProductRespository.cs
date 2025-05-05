using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
using Data.Helpers;

namespace Repository.Interface
{
    public interface IProductRespository : ICrudRepository<Product>
    {
    }
}
