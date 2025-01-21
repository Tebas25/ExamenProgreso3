using ExamenProgreso3.Repositories;
using ExamenProgreso3.ViewModels;

namespace ExamenProgreso3.Views;

public partial class PaginaConsulta : ContentPage
{
	public PaginaConsulta()
	{
		InitializeComponent();
        BindingContext = new PaginaConsultaViewModel(new PaisRepository());
	}
}