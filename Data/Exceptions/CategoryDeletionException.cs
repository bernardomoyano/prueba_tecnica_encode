using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;

namespace Data.Exceptions
{
    public class CategoryDeletionException : CustomHttpException
    {
        public CategoryDeletionException(string categoryName)
            : base($"No se puede eliminar la categoría '{categoryName}'", HttpStatusCode.BadRequest)
        {
        }
    }
}
