using api_desenvolvimento_web.DTO;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Business.Interfaces;
using Projeto.Business.Models;
using Projeto.Data.Context;
using Projeto.Data.Repository;

namespace api_desenvolvimento_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienterepository;
        private readonly IMapper _mapper;
        public PacienteController(IPacienteRepository pacienterepository
            , IMapper mapper)
        {
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
                return NotFound();
            }

            return Ok(paciente);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(CriarPacienteDTO paciente)
        {
            var model = _mapper.Map<Paciente>(paciente);
            _pacienterepository.Adicionar(model);

            return Created("Paciente cadastrado com sucesso",paciente);
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
                return NotFound();
            }

            _pacienterepository.Deletar(paciente);
            return Ok();
        }
        [HttpPost]
        [Route("atualizarendereco")]
        public async Task<IActionResult> CadastrarEndereco(AtualizarEnderecoDTO endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enderecoentidade = await _pacienterepository.ObterEnderecoPorId((int)endereco.Id);

            if (enderecoentidade == null)
            {
                return BadRequest();
            }

            enderecoentidade.Logradouro = endereco.Logradouro ?? enderecoentidade.Logradouro;
            enderecoentidade.Numero = endereco.Numero ?? enderecoentidade.Numero;
            enderecoentidade.Complemento = endereco.Complemento ?? enderecoentidade.Complemento;
            enderecoentidade.Cep = endereco.Cep ?? enderecoentidade.Cep;
            enderecoentidade.Bairro = endereco.Bairro ?? enderecoentidade.Bairro;
            enderecoentidade.Cidade = endereco.Cidade ?? enderecoentidade.Cidade;
            enderecoentidade.Estado = endereco.Estado ?? enderecoentidade.Estado;
            enderecoentidade.Paciente = endereco.Paciente ?? enderecoentidade.Paciente;

            _pacienterepository.AtualizarEndereco(enderecoentidade);

            return Ok(enderecoentidade);
        }
    }
}
