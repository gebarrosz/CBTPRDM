// Dupla: Luiz Felipe Gonçalves da Silva e Geovanna Barros de Assunção
// CBTPRDM - Trabalho Prático 03
using System.Windows.Input;
using Rastreio.Models;

namespace Rastreio.ViewModels;

public class ResultadoViewModel : ViewModelBase, IQueryAttributable
{
    private Pacote? _pacote;

    public Pacote? Pacote { get => _pacote; private set => Set(ref _pacote, value); }

    public ICommand VoltarCommand { get; } = new Command(async () => await Shell.Current.GoToAsync(".."));

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Pacote", out var obj) && obj is Pacote p)
            Pacote = p;
    }
}
