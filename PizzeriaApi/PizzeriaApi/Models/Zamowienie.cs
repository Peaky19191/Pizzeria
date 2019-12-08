using System;
using System.Collections.Generic;

namespace PizzeriaApi.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienie { get; set; }
        public int StanIdStan { get; set; }
        public int DostawcaIdDostawcy { get; set; }
        public int PromocjaIdPromocja { get; set; }
        public int PizzaIdPizza { get; set; }
        public int CenaZamownienia { get; set; }
        public int NrTel { get; set; }
        public string AdresEmail { get; set; }
    }
}
