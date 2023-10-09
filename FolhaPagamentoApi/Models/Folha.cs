using FolhaPagamentoApi.Controllers;
using FolhaPagamentoApi.Models;

namespace FolhaPagamentoApi;
public class Folha
{
    public int FolhaId { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public Funcionario? Funcionario { get; set; }
}
