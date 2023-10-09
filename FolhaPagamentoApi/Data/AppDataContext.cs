using Microsoft.EntityFrameworkCore;
namespace FolhaPagamentoApi.Models;
public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
        
    }
    //Classes que vão se tornar tabelas no banco
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Folha> Folhas { get; set; }
}
