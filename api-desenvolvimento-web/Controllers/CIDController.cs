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
    public class CIDController : Controller
    {
        private readonly ICIDRepository _cidrepository;
        private readonly IMapper _mapper;
        public CIDController(ICIDRepository cidrepository,
            IMapper mapper)
        {
            _cidrepository = cidrepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listarcids")]
        public async Task<IActionResult> ObterCIDs()
        {
            var cids = await _cidrepository.ListarCID();

            return Ok(cids);
        }

        [HttpGet]
        [Route("obtercid")]
        public async Task<IActionResult> ObterCID(int id)
        {
            var cid = await _cidrepository.ObterCIDPorId(id);

            if (cid == null)
            {
                return NotFound();
            }

            return Ok(cid);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(CriarCID cid)
        {
            var model = _mapper.Map<CID>(cid);
            _cidrepository.Adicionar(model);

            return Ok(model);
        }

        [HttpPut]
        [Route("atualizarcid")]
        public async Task<IActionResult> AtualizarCID(AtualizarCID cid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cidentidade = await _cidrepository.ObterCIDPorId((int)cid.Id);

            if (cidentidade == null)
            {
                return BadRequest();
            }

            cidentidade.NomeDoenca = cidentidade.NomeDoenca ?? cidentidade.NomeDoenca;
            cidentidade.CodCID = cidentidade.CodCID ?? cidentidade.CodCID;
            
            _cidrepository.Atualizar(cidentidade);

            return Ok(cidentidade);
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            var cid = await _cidrepository.ObterCIDPorId(id);
            if (cid == null)
            {
                return NotFound();
            }

            _cidrepository.Deletar(cid);
            return Ok();
        }
    }

}
