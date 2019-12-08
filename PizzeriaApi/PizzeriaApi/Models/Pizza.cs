using System;
using System.Collections.Generic;

namespace PizzeriaApi.Models
{
    public partial class Pizza
    {
        public int IdPizza { get; set; }
        public int CiastoIdCiasta { get; set; }
        public string Nazwa { get; set; }
        public int CenaPizza { get; set; }
        public string RodzajPizzy { get; set; }
    }
}
