using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto login)
    {
        var token = await _authService.LoginAsync(login);
        return Ok(token);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto register)
    {
        var token = await _authService.ResgisterAsync(register);
        return Ok(token);
    }
}
