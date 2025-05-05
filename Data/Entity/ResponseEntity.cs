using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Data.Entity
{
    public class ResponseEntity
    {
        public string? Message { get; set; }
        public bool Ok { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object? Body { get; set; }
        public List<string>? Errors { get; set; }
    }
}
