using System;
using System.Collections.Generic;

namespace PizzeriaApi.Models
{
    public partial class Administrator
    {
        public int IdAdmin { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string AdresEmail { get; set; }
    }
}
