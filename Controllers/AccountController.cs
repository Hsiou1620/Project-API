using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using game_shop.Models;
using game_shop.Dtos.Account;
using Microsoft.AspNetCore.Http.HttpResults;
using game_shop.Services;
using Azure.Identity;

namespace game_shop.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {

                var user = await _accountService.LoginAsync(loginDto);
                return Ok(user);

                } 
            catch (UnauthorizedAccessException ex)
                {
                    return Unauthorized(ex.Message);
                } 
            catch (Exception ex)
                {
                return StatusCode(500, ex.Message);
                }
        }  

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupDto signupDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = await _accountService.SignupAsync(signupDto);

                return Ok(user);
            } 
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
