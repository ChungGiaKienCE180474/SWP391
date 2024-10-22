using API.DAO;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        private readonly AuthenicationDAO dao;
        public AuthController(AuthenicationDAO dao) { 
            this.dao = dao;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginDTO account)
        {
            var response = dao.Login(account.AccountEmail,account.Password);
            if (response != null)
            {
                return Ok(new {message = "Login Success", data = response});
            }
            return NotFound("Account Not Found");
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO registerDTO)
        {
            if (registerDTO == null || registerDTO.AccountEmail.Equals("string") || registerDTO.Password.Equals("string"))
            {
                return BadRequest(new {Message = "Register Fail"});
            }
            else
            {
                var response = dao.Register(registerDTO);
                return Ok(response);
            }
        }
    }
}
