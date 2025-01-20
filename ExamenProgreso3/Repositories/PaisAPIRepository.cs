using ExamenProgreso3.Interfaces;
using ExamenProgreso3.Models;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ExamenProgreso3.Repositories
{
    public class PaisAPIRepository : IPaisRepositoy
    {
        public async Task<Pais> Pais(string nombrePais)
        {
            var pais = new Pais();
            var client = new HttpClient();
            string url = "https://restcountries.com/v3.1/name/" + nombrePais + "?fields=name,region,maps";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(url);
            if (respuesta.IsSuccessStatusCode)
            {
                var responseBody = await respuesta.Content.ReadAsStringAsync();
                JsonNode node = JsonNode.Parse(responseBody);
                JsonNode resultado = JsonNode.Parse(responseBody);
                pais = JsonConvert.DeserializeObject<Pais>(resultado.ToString());
                return pais;
            }
            return null;
            
        }
    }
}
