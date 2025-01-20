using ExamenProgreso3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgreso3.Interfaces
{
    public interface IPaisRepositoy
    {
        Task PaisAPI(string nombrePais);
        void UpdatePaisDb(PaisDB paisDB);
    }
}
