using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

        return result is null ? BadRequest("Invalid Email/Password") : Ok(result);
    }

    [HttpPut("refresh")]
    public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return result is null ? BadRequest("Invalid token") : Ok(result);
    }

    [HttpPut("revoked-refresh-token")]
    public async Task<IActionResult> RevokedRefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var isRevoked = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

        return isRevoked ? Ok() : BadRequest("Opretation Failed");
    }
}
