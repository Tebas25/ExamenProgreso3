using ExamenProgreso3.Interfaces;
using ExamenProgreso3.Models;
using System.Text.Json.Nodes;

namespace ExamenProgreso3.Repositories
{
    public class PaisRepository : IPaisRepositoy
    {
        public async Task PaisAPI(string nombrePais)
        {
            var pais = new PaisAPI();
            var client = new HttpClient();
            string url = "https://restcountries.com/v3.1/name/Ecuador?fields=name,region,maps";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(url);
            if (respuesta.IsSuccessStatusCode)
            {
                var responseBody = await respuesta.Content.ReadAsStringAsync();
                JsonNode node = JsonNode.Parse(responseBody);
                string nombreOficial = node["name"]["official"].ToString();
                string region = node["region"].ToString();
                string googleMaps = node["maps"]["googleMaps"].ToString();

                PaisDB Pais = new PaisDB()
                {
                    Name = nombreOficial,
                    Region = region,
                    Map = googleMaps
                };
                UpdatePaisDb(Pais);
            }
        }

        public void UpdatePaisDb(PaisDB paisDB)
        {
            throw new NotImplementedException();
        }
    }
}
