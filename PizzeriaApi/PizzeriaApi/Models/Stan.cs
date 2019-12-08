using System;
using System.Collections.Generic;

namespace PizzeriaApi.Models
{
    public partial class Stan
    {
        public int IdStan { get; set; }
        public string Nazwa { get; set; }
        public TimeSpan PozostalyCzas { get; set; }
    }
}
