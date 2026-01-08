using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request,CancellationToken cancellationToken)
    {
        var result = await _authService.GetTokenAsync(request.Email, request.Password,cancellationToken);

        return result is null ? BadRequest("Invalid Email/Password") : Ok(result);
    }
}
