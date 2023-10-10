using System.Text.Json.Serialization;

namespace FolhaPagamentoApi.Models;

public class Funcionario
{
    public int FuncionarioId { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }

    [JsonIgnore]
    public List<Folha>? Folhas { get; set; } // Propriedade de navegação
}