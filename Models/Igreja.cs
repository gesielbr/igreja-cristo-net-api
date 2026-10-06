namespace igreja_cristo_net_api.Models;

public class Igreja
{
    public long Id { get; set; }

    public string? Pais { get; set; }

    public string? Estado { get; set; }

    public string? Uf { get; set; }

    public string? Regiao { get; set; }

    public string? Cidade { get; set; }

    public string? TipoLocalidade { get; set; }

    public string? NomeCongregacao { get; set; }

    public string? EnderecoLogradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public int? QuantidadeMembros { get; set; }

    public string? Observacoes { get; set; }
}