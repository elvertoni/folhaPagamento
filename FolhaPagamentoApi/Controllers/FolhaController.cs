using System.Text.Json.Serialization;
using FolhaPagamentoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FolhaPagamentoApi.Controllers
{
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
                var folhas = _context.Folhas.ToList();
                return Ok(folhas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/folha/cadastrar
        // POST: api/folha/cadastrar
        // POST: api/folha/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Folha folha)
        {
            try
            {
                if (folha.FuncionarioId > 0) // Certifique-se de que o FuncionarioId seja válido
                {
                    var funcionario = _context.Funcionarios.FirstOrDefault(f => f.FuncionarioId == folha.FuncionarioId);

                    if (funcionario != null)
                    {
                        // Associe o funcionário à folha
                        folha.Funcionario = funcionario;

                        _context.Add(folha);
                        _context.SaveChanges();
                        return Created("", folha);
                    }
                    else
                    {
                        return BadRequest("Funcionario não encontrado");
                    }
                }
                else
                {
                    return BadRequest("FuncionarioId não especificado corretamente");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        // GET: api/folha/buscar/{cpf}/{mes}/{ano}
        [HttpGet]
        [Route("buscar/{cpf}/{mes}/{ano}")]
        public IActionResult Buscar([FromRoute] string cpf, [FromRoute] int mes, [FromRoute] int ano)
        {
            try
            {
                var funcionario = _context.Funcionarios.FirstOrDefault(f => f.CPF == cpf);

                if (funcionario != null)
                {
                    var folhaEncontrada = _context.Folhas.FirstOrDefault(f =>
                        f.FuncionarioId == funcionario.FuncionarioId &&
                        f.Mes == mes &&
                        f.Ano == ano
                    );

                    if (folhaEncontrada != null)
                    {
                        return Ok(folhaEncontrada);
                    }
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
