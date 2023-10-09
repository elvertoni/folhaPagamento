using Microsoft.AspNetCore.Mvc;
using MinhaWebApi.Data;
using MinhaWebApi.Models;
using System.Linq;

namespace FolhaPagamentoApi.Controllers;

{
    [ApiController]
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {
    private readonly AppDataContext _ctx;

    public FuncionarioController(AppDataContext ctx)
    {
        _ctx = ctx;
    }

    // POST: api/funcionario/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Funcionario funcionario)
    {
        _ctx.Funcionarios.Add(funcionario);
        _ctx.SaveChanges();
        return Created("", funcionario);
    }

    // GET: api/funcionario/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        var funcionarios = _ctx.Funcionarios.ToList();
        if (funcionarios.Count == 0)
        {
            return NotFound();
        }
        return Ok(funcionarios);
    }

}

public class Funcionario
{
}