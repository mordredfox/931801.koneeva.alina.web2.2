﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication2.Models
{
    public class Numbers
    {   
        public int ValueFirst { get; set; }
        public int ValueSecond { get; set; }
        public string Operation { get; set; }
    }
}
