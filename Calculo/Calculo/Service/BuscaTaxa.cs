using Calculo.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Calculo.Service
{
    public class BuscaTaxa : IBuscaTaxa
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BuscaTaxa(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<double> PegaTaxa()
        {
            var urlTaxa = "https://localhost:5001";

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(urlTaxa);

            client.DefaultRequestHeaders.Clear();

            client.Timeout = TimeSpan.FromSeconds(10);

            using (var res = await client.GetAsync("/taxajuros"))
            {
                using (var content = res.Content)
                {
                    var retorno = await content.ReadAsStringAsync();

                    var retornoDeserealizado = JsonConvert.DeserializeObject<double>(retorno);

                    return retornoDeserealizado;
                }
            }
        }
    }
}
