// Dupla: Luiz Felipe Gonçalves da Silva e Geovanna Barros de Assunção
// CBTPRDM - Trabalho Prático 03
using Rastreio.Models;

namespace Rastreio.Services;

// Simula uma API de rastreamento com dados fictícios.
public class RastreioService
{
    private readonly Dictionary<string, Pacote> _base;

    public RastreioService()
    {
        var hoje = DateTime.Today;
        _base = new(StringComparer.OrdinalIgnoreCase)
        {
            ["BR123456789"] = new Pacote
            {
                Id = "BR123456789",
                Status = "Em trânsito",
                DataEnvio = hoje.AddDays(-3),
                PrevisaoEntrega = hoje.AddDays(2),
                LocalizacaoAtual = "Centro de Distribuição - Campinas/SP",
                Historico = new()
                {
                    new() { Data = hoje.AddDays(-1).AddHours(14), Local = "Campinas/SP", Descricao = "Objeto chegou ao centro de distribuição" },
                    new() { Data = hoje.AddDays(-2).AddHours(9),  Local = "São Paulo/SP", Descricao = "Objeto em trânsito" },
                    new() { Data = hoje.AddDays(-3).AddHours(16), Local = "Cubatão/SP", Descricao = "Objeto postado" },
                }
            },
            ["BR987654321"] = new Pacote
            {
                Id = "BR987654321",
                Status = "Entregue",
                DataEnvio = hoje.AddDays(-7),
                PrevisaoEntrega = hoje.AddDays(-1),
                LocalizacaoAtual = "Entregue ao destinatário - Santos/SP",
                Historico = new()
                {
                    new() { Data = hoje.AddDays(-1).AddHours(11), Local = "Santos/SP", Descricao = "Objeto entregue ao destinatário" },
                    new() { Data = hoje.AddDays(-1).AddHours(8),  Local = "Santos/SP", Descricao = "Objeto saiu para entrega" },
                    new() { Data = hoje.AddDays(-4).AddHours(13), Local = "São Paulo/SP", Descricao = "Objeto em trânsito" },
                    new() { Data = hoje.AddDays(-7).AddHours(10), Local = "Curitiba/PR", Descricao = "Objeto postado" },
                }
            },
            ["BR555000111"] = new Pacote
            {
                Id = "BR555000111",
                Status = "Saiu para entrega",
                DataEnvio = hoje.AddDays(-2),
                PrevisaoEntrega = hoje,
                LocalizacaoAtual = "Unidade de Entrega - Guarujá/SP",
                Historico = new()
                {
                    new() { Data = hoje.AddHours(7), Local = "Guarujá/SP", Descricao = "Objeto saiu para entrega ao destinatário" },
                    new() { Data = hoje.AddDays(-1).AddHours(18), Local = "Santos/SP", Descricao = "Objeto em trânsito" },
                    new() { Data = hoje.AddDays(-2).AddHours(15), Local = "Rio de Janeiro/RJ", Descricao = "Objeto postado" },
                }
            },
        };
    }

    public async Task<Pacote?> BuscarAsync(string codigo)
    {
        await Task.Delay(800); // simula latência de rede
        return _base.TryGetValue(codigo.Trim(), out var p) ? p : null;
    }
}
