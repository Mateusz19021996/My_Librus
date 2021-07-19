using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities
{
    public class Response
    {
        public string Message { get; set; }

        public Response(Exception e)
        {
            Message = e.Message;
        }
    }
}
