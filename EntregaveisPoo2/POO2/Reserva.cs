using SistemaReservaHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaHotel
{
    public class Reserva
    {
        public Pessoa Hospede { get; set; }
        public Suite Suite { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public Reserva(Pessoa hospede, Suite suite, DateTime dataInicio, DateTime dataFim)
        {
            Hospede = hospede;
            Suite = suite;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public double CalcularValorTotal()
        {
            TimeSpan duracaoReserva = DataFim - DataInicio;
            double valorTotal = duracaoReserva.TotalDays * Suite.ValorDiaria;

            if (duracaoReserva.TotalDays > 10)
            {
                valorTotal *= 0.9;
            }

            return valorTotal;
        }
    }
}
