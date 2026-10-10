
namespace igreja_cristo_net_api.Models;

public class ContatoCongregacao
{
    public long CongregacaoId { get; set; }

    public string? NomeContato { get; set; }

    public string? Funcao { get; set; }

    public string? TelefoneOriginal { get; set; }

    public string? TelefonePadronizado { get; set; }

    public string? Operadora { get; set; }

    public string? Email { get; set; }

    public string? Observacoes { get; set; }

    public string? Estado { get; set; }

    public string? Uf { get; set; }

    public string? Cidade { get; set; }

    public string? Congregacao { get; set; }
}
