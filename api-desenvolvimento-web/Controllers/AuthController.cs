using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api_desenvolvimento_web.Models;
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

        public AuthController(
            IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] CriarUsuarioModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.NomeUsuario);

            if (userExists is not null)
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

            var result = await _userManager.CreateAsync(user, model.Senha);

            if (!result.Succeeded)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new RespostaModel { Success = false, Message = "Erro ao criar usuário" }
                );

            return Ok(new RespostaModel { Message = "Usuário criado com sucesso!" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.NomeUsuario);

            if (user is not null && await _userManager.CheckPasswordAsync(user, model.Senha))
            {

                var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.UserName),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var userRole in userRoles)
                    authClaims.Add(new(ClaimTypes.Role, userRole));

                return Ok(new RespostaModel { Data = ObterToken(authClaims) });
            }

            return Unauthorized();
        }

        private TokenModel ObterToken(List<Claim> authClaims)
        {
            //var authSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            //var token = new JwtSecurityToken(
            //    issuer: _configuration["JWT:ValidIssuer"],
            //    audience: _configuration["JWT:ValidAudience"],
            //    expires: DateTime.Now.AddHours(1),
            //    claims: authClaims,
            //    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            //);

            //return new()
            //{
            //    Token = new JwtSecurityTokenHandler().WriteToken(token),
            //    ValidTo = token.ValidTo
            //};

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

            //return tokenHandler.WriteToken(token);
        }
    }
}
