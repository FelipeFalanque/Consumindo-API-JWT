using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApiJWT.ViewsModels;

namespace WebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("GetToken")]
        public ActionResult GetToken([FromBody]LoginViewModel loginVM)
        {
            if (loginVM.Email == "teste" && loginVM.Password == "teste")
            {
                string chaveSecreta = "MinhaChaveUltraSecreta";

                var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));

                var credenciais = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);

                //Add Claims
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                claims.Add(new Claim("OutroTipo", "OutroValor"));

                var token = new JwtSecurityToken(
                    issuer: "user.teste",
                    audience: "readers",
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credenciais,
                    claims : claims
                    );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest();
        }
    }
}