using Calculo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculo.Service
{
    public class CalculaJuros : ICalculaJuros
    {
        private IBuscaTaxa _buscaTaxa;

        public CalculaJuros(IBuscaTaxa buscaTaxa)
        {
            _buscaTaxa = buscaTaxa;
        }
        public async Task<double> CalcularJuros(double ValorInicial, int Mes)
        {
            var taxa = await _buscaTaxa.PegaTaxa();
            var Pontecial = Math.Pow((1 + taxa), Mes);
            var Result = ValorInicial * Pontecial;

            return await Task.Run(() => Math.Round(Result, 2));
        }
    }
}
