using ExamenProgreso3.Interfaces;
using ExamenProgreso3.Models;

namespace ExamenProgreso3.Repositories
{
    public class PaisAPIRepository : IPaisRepositoy
    {
        public Task<Pais> Pais(string nombrePais)
        {
            string url = "https://restcountries.com/v3.1/name/" + nombrePais + "?fields=name,region,maps";

        }
    }
}
