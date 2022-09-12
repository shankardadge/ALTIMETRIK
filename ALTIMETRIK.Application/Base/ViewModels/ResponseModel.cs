using System;
using System.Collections.Generic;
using System.Text;

namespace ALTIMETRIK.Application.Base.ViewModels
{
    public class ResponseModel<T>
    {
        public T Response { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public int ResponseCode { get; set; }
    }
}
