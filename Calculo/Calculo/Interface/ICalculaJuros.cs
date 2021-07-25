using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculo.Interface
{
    public interface ICalculaJuros
    {
        Task<Double> CalcularJuros(double ValorInicial, int Mes);

    }
}
