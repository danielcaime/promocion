using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promociones.api.Responses
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            status = "success";
        }
        public T Data { get; set; }
        public string Message { get; set; }
        public string status { get; set; }
    }
}
