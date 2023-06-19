using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Pongpan.Helper
{
    public class APIResponse<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Messege { get; set; }

        //T คือ Class ที่สามารถเก็บข้อมูลอะไรก็ได้ 
        public T Data { get; set; }

    }

}