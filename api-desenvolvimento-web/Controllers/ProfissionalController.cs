using api_desenvolvimento_web.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Business.Interfaces;
using Projeto.Business.Models;
using Projeto.Data.Repository;

namespace api_desenvolvimento_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _profissionalrepository;
        private readonly IMapper _mapper;
        public ProfissionalController(IProfissionalRepository profissionalrepository,
            IMapper mapper)
        {
            _profissionalrepository = profissionalrepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listarprofissionais")]
        public async Task<IActionResult> ObterProfissionais()
        {
            var profissionais = await _profissionalrepository.ListarProfissional();

            return Ok(profissionais);
        }

        [HttpGet]
        [Route("obterprofissional")]
        public async Task<IActionResult> ObterProfissional(int id)
        {
            var profissional = await _profissionalrepository.ObterProfissionalPorId(id);

            if (profissional == null)
            {
                return NotFound();
            }

            return Ok(profissional);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(CriarProfissionalDTO profissional)
        {
            var model = _mapper.Map<Profissional>(profissional);
            _profissionalrepository.Adicionar(model);

            return Created("Profissional cadastrado com sucesso",profissional);
        }

        [HttpPut]
        [Route("atualizarprofissional")]
        public async Task<IActionResult> AtualizarProfissional(AtualizarProfissionalDTO profissional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var profissionalentidade = await _profissionalrepository.ObterProfissionalPorId((int)profissional.Id);

            if (profissionalentidade == null)
            {
                return BadRequest();
            }
            profissionalentidade.Nome = profissional.Nome ?? profissionalentidade.Nome;
            profissionalentidade.NumeroConselho = profissional.NumeroConselho ?? profissionalentidade.NumeroConselho;
            profissionalentidade.UFConselho = profissional.UFConselho ?? profissionalentidade.UFConselho;
            profissionalentidade.Especialidade = profissional.Especialidade ?? profissionalentidade.Especialidade;

            _profissionalrepository.Atualizar(profissionalentidade);

            return Ok(profissionalentidade);
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            var profissional = await _profissionalrepository.ObterProfissionalPorId(id);
            if (profissional == null)
            {
                return NotFound();
            }

            _profissionalrepository.Deletar(profissional);
            return Ok();
        }
    }
}
