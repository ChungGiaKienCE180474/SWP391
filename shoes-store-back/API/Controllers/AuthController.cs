﻿using API.DAO;
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
            try
            {
                if (registerDTO == null || registerDTO.AccountEmail.Equals("string") || registerDTO.Password.Equals("string"))
                {
                    return BadRequest(new { Message = "Register Fail" });
                }
                else
                {
                    var response = dao.Register(registerDTO);
                    return Ok(response);
                }
            }
            catch (Exception ex) {

                return StatusCode(500,new {Message = "Internal Server Error", Error = ex.Message});
            }
        }

        [HttpGet("get-profile")]
        public IActionResult GetProfileByID([FromQuery] int accountID)
        {
            var response = dao.GetProfileByID(accountID);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut("change-password")]
        public IActionResult ChangePassword([FromForm]ChangePasswordDTO changePasswordDTO)
        {
            var response = dao.ChangePassword(changePasswordDTO);
            if (response == null)
            {
                return BadRequest(new { Message = "Old password is incorrect" });
            }
            return Ok(new {Message = "Success Please Login With New Password",
                           AccountID = response.accountID,
                           NewPassword = response.NewPassword});
        }
    }
}
