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
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoRepository _diagnosticorepository;
        private readonly ICIDRepository _cidrepository;
        private readonly IMapper _mapper;
        public DiagnosticoController(IDiagnosticoRepository diagnosticorepository,
            ICIDRepository cidrepository,
            IMapper mapper)
        {
            _diagnosticorepository = diagnosticorepository;
            _cidrepository = cidrepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listardiagnosticos/{pagina}")]
        public async Task<IActionResult> ObterDiagnosticos(int pagina)
        {
            var numeropaginas = Math.Ceiling(_diagnosticorepository.NumeroDiagnosticos() / 10f);
            var diagnosticos = await _diagnosticorepository.ListarDiagnostico(pagina);

            var resposta = new ListarDiagnosticosDTO
            {
                Diagnosticos = diagnosticos,
                PaginaAtual = pagina,
                NumeroPaginas = (int)numeropaginas,
            };

            return Ok(resposta);
        }

        [HttpGet]
        [Route("obterdiagnostico")]
        public async Task<IActionResult> ObterDiagnostico(int id)
        {
            var diagnostico = await _diagnosticorepository.ObterDiagnosticoPorId(id);

            if (diagnostico == null)
            {
                return NotFound();
            }

            return Ok(diagnostico);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(CriarDiagnosticoDTO diagnostico)
        {
            var model = _mapper.Map<Diagnostico>(diagnostico);
            _diagnosticorepository.Adicionar(model);

            return Created("Diagnostico cadastrado com sucesso",model);
        }

        [HttpPut]
        [Route("atualizardiagnostico")]
        public async Task<IActionResult> AtualizarDiagnostico(AtualizarDiagnosticoDTO diagnostico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var diagnosticoentidade = await _diagnosticorepository.ObterDiagnosticoPorId((int)diagnostico.Id);

            if (diagnosticoentidade == null)
            {
                return BadRequest();
            }

            diagnosticoentidade.DataDiagnostico = diagnostico.DataDiagnostico ?? diagnosticoentidade.DataDiagnostico;

            _diagnosticorepository.Atualizar(diagnosticoentidade);

            return Ok(diagnosticoentidade);
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            var diagnostico = await _diagnosticorepository.ObterDiagnosticoPorId(id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            _diagnosticorepository.Deletar(diagnostico);
            return Ok();
        }

        [HttpPost("diagnosticocid")]
        public async Task<IActionResult> DiagnosticoCID(AdicionarDiagnosticoCIDDTO diagnosticocid)
        {
            var diagnostico = await _diagnosticorepository.ObterDiagnosticoPorId(diagnosticocid.DiagnosticoId);
            if (diagnostico == null)
            {
                return NotFound();
            }

            var cid = await _cidrepository.ObterCIDPorId(diagnosticocid.CIDId);

            if (cid == null)
            {
                return NotFound();
            }

            _diagnosticorepository.AdicionarDiagnosticoCID(diagnostico, cid);

            return NoContent();
        }

    }
}
