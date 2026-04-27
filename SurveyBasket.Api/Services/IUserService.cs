namespace SurveyBasket.Api.Services;

public interface IUserService
{
    Task<Result<UserResponse>> AddAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleStatusAsync(string id, CancellationToken cancellationToken = default);
    Task<Result> UnlockedUserAsync(string id, CancellationToken cancellationToken = default);
    Task<Result<UserProfileResponse>> GetProfileAsync(string userId);
    Task<Result<UserResponse>> GetByIdAsync(string id);
    Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request);
    Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request);
    Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default);
}
