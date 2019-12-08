using System;
using System.Collections.Generic;

namespace PizzeriaApi.Models
{
    public partial class Skladnik
    {
        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }
        public int CenaSkladnika { get; set; }
    }
}
