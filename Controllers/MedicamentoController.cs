using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBulaFinal.DTOs;
using ProjetoBulaFinal.Models;
using ProjetoBulaFinal.Repositorio.Interfaces;
using ProjetoBulaFinal.Servicos;

namespace ProjetoBulaFinal.Controllers
{
    [Route("medicamentos")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private IServico<Medicamento> _servico;
        public MedicamentoController(IServico<Medicamento> servico)
        {
            _servico = servico;
        }

        // GET: Medicamentos

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var medicamento = await _servico.TodosAsync();
            return StatusCode(200, medicamento);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var medicamento = (await _servico.TodosAsync()).Find(c => c.Id == id);

            return StatusCode(200, medicamento);
        }

        // POST: Medicamentos
        [HttpPost("")]
        [Authorize(Roles = "anvisa,laboratorio")]
        public async Task<IActionResult> Create([FromBody] MedicamentoDTO medicamentoDTO)
        {
            var medicamento = BuilderServico<Medicamento>.Builder(medicamentoDTO);
            await _servico.IncluirAsync(medicamento);
            return StatusCode(201, medicamento);
        }


        // PUT: Medicamentos/"id"
        [HttpPut("{id}")]
        [Authorize(Roles = "anvisa,laboratorio")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Medicamento medicamento)
        {
            if (id != medicamento.Id)
            {
                return StatusCode(400, new
                {
                    Mensagem = "O Id do medicamento precisa bater com o id da URL"
                });
            }

            var medicamentoDb = await _servico.AtualizarAsync(medicamento);

            return StatusCode(200, medicamentoDb);
        }

        // DELETE: Medicamentos/"id"
        [HttpDelete("{id}")]
        [Authorize(Roles = "anvisa")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var medicamentoDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
            if (medicamentoDb is null)
            {
                return StatusCode(404, new
                {
                    Mensagem = "O medicamento informado não existe"
                });
            }

            await _servico.ApagarAsync(medicamentoDb);

            return StatusCode(204);
        }
    }
}
