using ExamenProgreso3.Interfaces;
using ExamenProgreso3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenProgreso3.ViewModels
{
    public class PaginaConsultaViewModel
    {
        private readonly IPaisRepositoy _paisRepository;
        private PaisDB _pais;
        private string _nombre;

        public PaginaConsultaViewModel(IPaisRepositoy paisRepository)
        {
            _paisRepository = paisRepository;
            BuscarPaisCommand = new Command(async () => await BuscarPais());
            LimpiarCommand = new Command(Limpiar);
        }
        public string NombrePais
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        public PaisDB Pais
        {
            get => _pais;
            set
            {
                _pais = value;
                OnPropertyChanged();
            }
        }

        public ICommand BuscarPaisCommand { get; }
        public ICommand LimpiarCommand { get; }

        private async Task BuscarPais()
        {
            await _paisRepository.PaisAPI(NombrePais);
            Pais = _paisRepository.GetPaisFromDb(NombrePais);
        }

        private void Limpiar()
        {
            NombrePais = string.Empty;
            Pais = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
