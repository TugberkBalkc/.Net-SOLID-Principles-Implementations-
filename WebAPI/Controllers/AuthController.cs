using Business.Abstract.AuthServices;
using Entities.Dto_s;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthCotroller : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;

        public AuthCotroller
            (IAuthenticationService authenticationService,
             IAuthorizationService authorizationService)
        {
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var loginResult = _authenticationService.Login(userForLoginDto);
           
            if (!loginResult.Success)
            {
                return BadRequest(loginResult.Message); 
            }

            var result = _authorizationService.CreateAccessToken(loginResult.Data);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userNotExists = _authenticationService.UserExists(userForRegisterDto.Email);
            if (!userNotExists.Success)
            {
                return BadRequest(userNotExists.Message);
            }
            var registerResult = _authenticationService.Register(userForRegisterDto);
            var result = _authorizationService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
