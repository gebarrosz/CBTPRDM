// Dupla: Luiz Felipe Gonçalves da Silva e Geovanna Barros de Assunção
// CBTPRDM - Trabalho Prático 03
namespace Rastreio.Models;

public class EventoRastreio
{
    public DateTime Data { get; set; }
    public string Local { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string DataTexto => Data.ToString("dd/MM/yyyy HH:mm");
}

public class Pacote
{
    public string Id { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTime DataEnvio { get; set; }
    public DateTime PrevisaoEntrega { get; set; }
    public string LocalizacaoAtual { get; set; } = "";
    public List<EventoRastreio> Historico { get; set; } = new();

    public string DataEnvioTexto => DataEnvio.ToString("dd/MM/yyyy");
    public string PrevisaoTexto => PrevisaoEntrega.ToString("dd/MM/yyyy");
}
