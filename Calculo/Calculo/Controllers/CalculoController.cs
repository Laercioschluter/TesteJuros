using Calculo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly ICalculaJuros _calculaJuros;
        public CalculoController(ICalculaJuros calculaJuros)
        {
            _calculaJuros = calculaJuros;
        }


        [HttpGet]
        public async Task<double> GetCalculaJuros(double ValorInicial, int Mes)
        {
            return await _calculaJuros.CalcularJuros(ValorInicial, Mes);
        }

        [HttpGet("/showmethecode")]
        public string showmethecode()
        {
            return "https://github.com/Laercioschluter/";
        }

    }
}
