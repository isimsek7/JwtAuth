using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuth.Dtos;
using JwtAuth.Interfaces;
using JwtAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtAuth.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        public AccountsController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signinManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signinManager;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.Select(u => new
            {
                u.Email,
                HashedPassword = u.PasswordHash
            }).ToList();

            return Ok(users);
        }

        // POST api/values
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName=appUser.UserName,
                                Email=appUser.Email,
                                Token=_tokenService.CreateToken(appUser)
                                
                            });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user is null)
                return Unauthorized("Invalid User!");
            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if (result.Succeeded)
                return Unauthorized("Username/Password not found!");
            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
                );
        }
    }
}

