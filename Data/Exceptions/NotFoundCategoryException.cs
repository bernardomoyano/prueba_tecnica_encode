using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;

namespace Data.Exceptions
{
    public class NotFoundCategoryException : CustomHttpException
    {
        public NotFoundCategoryException()
            : base($"categoria no econtrada", HttpStatusCode.BadRequest)
        {
        }
    }
}
