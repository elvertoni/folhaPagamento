using FolhaPagamentoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FolhaPagamentoApi.Controllers;

[ApiController]
[Route("api/folha")]
public class FolhaController : ControllerBase
{
    private readonly AppDataContext _context;

    public FolhaController(AppDataContext context)
    {
        _context = context;
    }

    // GET: api/folha/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Folha> folhas = _context.Folhas.ToList();
            return Ok(folhas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/folha/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Folha folha)
    {
        try
        {
            _context.Add(folha);
            _context.SaveChanges();
            return Created("", folha);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

