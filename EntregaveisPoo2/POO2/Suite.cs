using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaHotel
{
    public class Suite
    {
        public int Capacidade { get; set; }
        public double ValorDiaria { get; set; }

        public Suite(int capacidade, double valorDiaria)
        {
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
    }
}
