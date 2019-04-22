using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using JWTDemoWebApi.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("api/Auth/GetToken")]
        public ActionResult GetToken(LoginViewModel loginVM)
        {
            if (loginVM.Email == "teste" && loginVM.Password == "teste")
            {
                string chaveSecreta = "MinhaChaveUltraSecreta";

                var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));

                var credenciais = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(
                    issuer : "user.teste",
                    audience : "readers",
                    expires : DateTime.Now.AddMinutes(30),
                    signingCredentials : credenciais
                    );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("api/Auth/GetToken")]
        public ActionResult GetToken()
        {
            if (true)
            {
                string chaveSecreta = "MinhaChaveUltraSecreta";

                var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));

                var credenciais = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(
                    issuer: "user.teste",
                    audience: "readers",
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credenciais
                    );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest();
        }
    }
}