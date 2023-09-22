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
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoRepository _atendimentorepository;
        private readonly IMapper _mapper;
        public AtendimentoController(IAtendimentoRepository atendimentorepository,
            IMapper mapper)
        {
            _atendimentorepository = atendimentorepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listaratendimentos")]
        public async Task<IActionResult> ObterAtendimentos()
        {
            var atendimentos = await _atendimentorepository.ListarAtendimentos();

            return Ok(atendimentos);
        }

        [HttpGet]
        [Route("obteratendimento")]
        public async Task<IActionResult> ObterAtendimento(int id)
        {
            var atendimento = await _atendimentorepository.ObterAtendimentoPorId(id);

            if (atendimento == null)
            {
                return NotFound();
            }

            return Ok(atendimento);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(CriarAtendimentoDTO atendimento)
        {
            var model = _mapper.Map<Atendimento>(atendimento);
            _atendimentorepository.Adicionar(model);

            return Ok(model);
        }

        [HttpPut]
        [Route("atualizaratendimento")]
        public async Task<IActionResult> AtualizarAtendimento(AtualizarAtendimentoDTO atendimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var atendimentoentidade = await _atendimentorepository.ObterAtendimentoPorId((int)atendimento.Id);

            if (atendimentoentidade == null)
            {
                return BadRequest();
            }
            atendimentoentidade.Data = atendimento.Data ?? atendimentoentidade.Data;
            atendimentoentidade.NumeroCarteira = atendimento.NumeroCarteira ?? atendimentoentidade.NumeroCarteira;
            atendimentoentidade.PesoPaciente = atendimento.PesoPaciente ?? atendimentoentidade.PesoPaciente;
            atendimentoentidade.AlturaPaciente = atendimento.AlturaPaciente ?? atendimentoentidade.AlturaPaciente;
            atendimentoentidade.Aberto = atendimento.Aberto ?? atendimentoentidade.Aberto;
            atendimentoentidade.DataFim = atendimento.DataFim ?? atendimentoentidade.DataFim;
            atendimentoentidade.PacienteId = atendimento.PacienteId ?? atendimentoentidade.PacienteId;
            atendimentoentidade.ProfissionalId = atendimento.ProfissionalId ?? atendimentoentidade.ProfissionalId;


            _atendimentorepository.Atualizar(atendimentoentidade);

            return Ok(atendimentoentidade);
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            var atendimento = await _atendimentorepository.ObterAtendimentoPorId(id);
            if (atendimento == null)
            {
                return NotFound();
            }

            _atendimentorepository.Deletar(atendimento);
            return Ok();
        }
    }
}
