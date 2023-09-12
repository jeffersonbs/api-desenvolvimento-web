using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_desenvolvimento_web.DTO;
using api_desenvolvimento_web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api_desenvolvimento_web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AuthController(
            IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;

        }
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] CriarUsuarioDTO criarusuariodto)
        {
            var model = _mapper.Map<CriarUsuarioModel>(criarusuariodto);

            var UsuarioExiste = await _userManager.FindByEmailAsync(model.Email);

            if (UsuarioExiste is not null)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new RespostaModel { Success = false, Message = "Usuário já existe!" }
                );

            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                UserName = model.NomeUsuario
            };

            var resultado = await _userManager.CreateAsync(user, model.Senha);

            if (!resultado.Succeeded)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new RespostaModel { Success = false, Message = "Erro ao criar usuário" }
                );

            return Ok(new RespostaModel { Message = "Usuário criado com sucesso!" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO logindto)
        {
            var model = _mapper.Map<LoginModel>(logindto);

            var usuario = await _userManager.FindByNameAsync(model.NomeUsuario);

            if (usuario is not null && await _userManager.CheckPasswordAsync(usuario, model.Senha))
            {

                var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, usuario.UserName),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var userRoles = await _userManager.GetRolesAsync(usuario);

                foreach (var userRole in userRoles)
                    authClaims.Add(new(ClaimTypes.Role, userRole));

                return Ok(new RespostaModel { Data = ObterToken(authClaims) });
            }

            return Unauthorized();
        }

        [HttpPost("resetar-senha")]
        public async Task<IActionResult> ResetarSenha([FromBody] ResetarSenhaModel resetarsenhadto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, data = ModelState });
            }

            var resetarsenha = _mapper.Map<ResetarSenhaModel>(resetarsenhadto);

            var usuario = await _userManager.FindByNameAsync(resetarsenha.NomeUsuario);

            var resultadoLogin = await _userManager.CheckPasswordAsync(usuario, resetarsenha.SenhaAntiga);

            if (!resultadoLogin)
            {
                return BadRequest(new { success = false, message = "Usuario ou senha errado!" });
            }

            var resultadoChange = await _userManager.ChangePasswordAsync(usuario, resetarsenha.SenhaAntiga, resetarsenha.NovaSenha);

            if (resultadoChange.Succeeded)
            {
                return Ok(new
                {
                    success = true,
                    message = "Senha alterada com sucesso!",
                });
            }

            return BadRequest(new
            {
                success = false,
                erros = resultadoChange.Errors,
            });
        }

        [Authorize]
        [HttpGet("token-e-valido")]
        public IActionResult TokenEValido() 
        {
            return Ok();
        }

        private TokenModel ObterToken(List<Claim> authClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JWT").GetSection("Secret").Value);

            var claimsidentity = new ClaimsIdentity();

            claimsidentity.AddClaims(authClaims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsidentity,
                Issuer = _configuration.GetSection("JWT").GetSection("ValidIssuer").Value,
                Audience = _configuration.GetSection("JWT").GetSection("ValidAudience").Value,
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration.GetSection("JWT").GetSection("ExpirationHours").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new()
            {
                Token = tokenHandler.WriteToken(token),
                ValidTo = token.ValidTo
            };
        }
    }
}
