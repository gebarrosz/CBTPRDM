// Dupla: Luiz Felipe Gonçalves da Silva e Geovanna Barros de Assunção
// CBTPRDM - Trabalho Prático 03
using Rastreio.Views;

namespace Rastreio;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ResultadoPage), typeof(ResultadoPage));
    }
}
