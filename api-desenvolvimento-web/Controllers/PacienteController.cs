using api_desenvolvimento_web.DTO;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;
using Projeto.Business.Interfaces;
using Projeto.Business.Models;
using Projeto.Data.Context;
using Projeto.Data.Repository;

namespace api_desenvolvimento_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPacienteRepository _pacienterepository;
        private readonly IMapper _mapper;
        public PacienteController(ApplicationDbContext context
            ,IPacienteRepository pacienterepository
            , IMapper mapper)
        {
            _context = context;
            _pacienterepository = pacienterepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listarpacientes")]
        public async Task<IActionResult> ObterPacientes()
        {
            var pacientes = await _pacienterepository.ListarPacientes();

            return Ok(pacientes);
        }

        [HttpGet]
        [Route("obterpaciente")]
        public async Task<IActionResult> ObterPaciente(int id)
        {
            var paciente = await _pacienterepository.ObterPacientePorId(id);

            if(paciente == null)
            {
                return BadRequest();
            }

            return Ok(paciente);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(CriarPacienteDTO paciente)
        {
            var model = _mapper.Map<Paciente>(paciente);
            _pacienterepository.Adicionar(model);

            return Ok(paciente);
        }

        [HttpPut]
        [Route("atualizarpaciente")]
        public async Task<IActionResult> AtualizarPaciente(AtualizarPacienteDTO paciente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pacienteentidade = await _pacienterepository.ObterPacientePorId((int)paciente.Id);

            if(pacienteentidade == null)
            { 
                return BadRequest(); 
            }
            pacienteentidade.Nome = paciente.Nome ?? pacienteentidade.Nome;
            pacienteentidade.Sexo = paciente.Sexo ?? pacienteentidade.Sexo;
            pacienteentidade.DataNascimento = paciente.DataNascimento ?? pacienteentidade.DataNascimento;
            pacienteentidade.CPF = paciente.CPF ?? pacienteentidade.CPF;
            pacienteentidade.RG = paciente.RG ?? pacienteentidade.RG;
            pacienteentidade.UFRG = paciente.UFRG ?? pacienteentidade.UFRG;
            pacienteentidade.OrgaoEmissor = paciente.OrgaoEmissor ?? pacienteentidade.OrgaoEmissor;
            pacienteentidade.NomePai = paciente.NomePai ?? pacienteentidade.NomePai;
            pacienteentidade.NomeMae = paciente.NomeMae ?? pacienteentidade.NomeMae;
            pacienteentidade.NumeroFone = paciente.NumeroFone ?? pacienteentidade.NumeroFone;
            pacienteentidade.Endereco = paciente.Endereco ?? pacienteentidade.Endereco;
            pacienteentidade.EnderecoId = paciente.EnderecoId ?? pacienteentidade.EnderecoId;

            _pacienterepository.Atualizar(pacienteentidade);

            return Ok(pacienteentidade);
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            var paciente = await _pacienterepository.ObterPacientePorId(id);
            if(paciente == null)
            {
                return BadRequest();
            }

            _pacienterepository.Deletar(paciente);
            return Ok();
        }
    }
}
