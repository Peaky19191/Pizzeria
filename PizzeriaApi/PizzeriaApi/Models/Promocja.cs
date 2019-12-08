using System;
using System.Collections.Generic;

namespace PizzeriaApi.Models
{
    public partial class Promocja
    {
        public int IdPromocja { get; set; }
        public string Nazwa { get; set; }
        public int ProcentRabatu { get; set; }
    }
}
