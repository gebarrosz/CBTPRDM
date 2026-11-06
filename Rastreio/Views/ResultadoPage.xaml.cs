// Dupla: Luiz Felipe Gonçalves da Silva e Geovanna Barros de Assunção
// CBTPRDM - Trabalho Prático 03
using Rastreio.ViewModels;

namespace Rastreio.Views;

public partial class ResultadoPage : ContentPage
{
    public ResultadoPage(ResultadoViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
