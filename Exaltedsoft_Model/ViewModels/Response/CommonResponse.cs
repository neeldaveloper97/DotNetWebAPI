﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaltedsoft_Model.ViewModels.Response
{
    public class CommonResponse<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
