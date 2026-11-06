// Dupla: Luiz Felipe Gonçalves da Silva e Geovanna Barros de Assunção
// CBTPRDM - Trabalho Prático 03
using System.Windows.Input;
using Rastreio.Services;
using Rastreio.Views;

namespace Rastreio.ViewModels;

public class RastreioViewModel : ViewModelBase
{
    private readonly RastreioService _servico;
    private string _codigo = "";
    private string _mensagem = "";
    private bool _carregando;

    public RastreioViewModel(RastreioService servico)
    {
        _servico = servico;
        BuscarCommand = new Command(async () => await BuscarAsync(), () => !Carregando);
    }

    public string Codigo { get => _codigo; set => Set(ref _codigo, value); }
    public string Mensagem { get => _mensagem; set => Set(ref _mensagem, value); }

    public bool Carregando
    {
        get => _carregando;
        set { if (Set(ref _carregando, value)) ((Command)BuscarCommand).ChangeCanExecute(); }
    }

    public ICommand BuscarCommand { get; }

    private async Task BuscarAsync()
    {
        Mensagem = "";
        if (string.IsNullOrWhiteSpace(Codigo))
        {
            Mensagem = "Informe o código de rastreamento.";
            return;
        }

        Carregando = true;
        try
        {
            var pacote = await _servico.BuscarAsync(Codigo);
            if (pacote is null)
            {
                Mensagem = "Pacote não encontrado. Verifique o código.";
                return;
            }
            await Shell.Current.GoToAsync(nameof(ResultadoPage), new Dictionary<string, object> { ["Pacote"] = pacote });
        }
        finally
        {
            Carregando = false;
        }
    }
}
