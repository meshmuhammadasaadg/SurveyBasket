using SurveyBasket.Api.Abstractions.DataSeeding;

namespace SurveyBasket.Api.Services;

public class UserService(UserManager<ApplicationUser> userManager,
    IRoleService roleService,
    ApplicationDbContext context) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IRoleService _roleService = roleService;
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await (from u in _context.Users
               join ur in _context.UserRoles
               on u.Id equals ur.UserId
               join r in _context.Roles
               on ur.RoleId equals r.Id into roles
               where roles.Any(c => c.Name != DefaultRoles.Member.Name)
               select new
               {
                   u.Id,
                   u.FirstName,
                   u.LastName,
                   u.Email,
                   u.IsDisabled,
                   Roles = roles.Select(c => c.Name!).ToList()
               }
                )
                .GroupBy(u => new { u.Id, u.FirstName, u.LastName, u.Email, u.IsDisabled })
                .Select(u => new UserResponse
                (
                    u.Key.Id,
                    u.Key.FirstName,
                    u.Key.LastName,
                    u.Key.Email,
                    u.Key.IsDisabled,
                    u.SelectMany(x => x.Roles)
                ))
                .ToListAsync(cancellationToken);


    public async Task<Result<UserResponse>> GetByIdAsync(string id)
    {
        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure<UserResponse>(UserErrors.NotFound(id));

        var userRoles = await _userManager.GetRolesAsync(user);

        var response = (user, userRoles).Adapt<UserResponse>();

        return Result.Success(response);
    }

    public async Task<Result<UserResponse>> AddAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var emailIsExists = await _userManager.Users.AnyAsync(c => c.Email == request.Email, cancellationToken);

        if (emailIsExists)
            return Result.Failure<UserResponse>(UserErrors.DuplicatedEmail);

        var allowedRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

        if (request.Roles.Except(allowedRoles.Select(c => c.Name)).Any())
            return Result.Failure<UserResponse>(UserErrors.InvalidRoles);

        var user = request.Adapt<ApplicationUser>();

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var error = result.Errors.First();

            return Result.Failure<UserResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        await _userManager.AddToRolesAsync(user, request.Roles);

        var response = (user, request.Roles).Adapt<UserResponse>();

        return Result.Success(response);
    }

    public async Task<Result> UpdateAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure(UserErrors.NotFound(id));

        var emailIsExists = await _userManager.Users.AnyAsync(c => c.Email == request.Email && c.Id != id, cancellationToken);

        if (emailIsExists)
            return Result.Failure(UserErrors.DuplicatedEmail);

        var allowedRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

        if (request.Roles.Except(allowedRoles.Select(c => c.Name)).Any())
            return Result.Failure(UserErrors.InvalidRoles);

        user = request.Adapt(user);

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            var error = result.Errors.First();

            return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        await _context.UserRoles
            .Where(c => c.UserId == id)
            .ExecuteDeleteAsync(cancellationToken);

        await _userManager.AddToRolesAsync(user, request.Roles);

        return Result.Success();
    }

    public async Task<Result> ToggleStatusAsync(string id, CancellationToken cancellationToken = default)
    {
        var affectedRows = await _userManager.Users
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(c => c.IsDisabled, x => !x.IsDisabled)
            , cancellationToken);

        if (affectedRows == 0)
            return Result.Failure(UserErrors.NotFound(id));

        return Result.Success();
    }

    public async Task<Result> UnlockedUserAsync(string id, CancellationToken cancellationToken = default)
    {
        //var affectedRows = await _userManager.Users
        //    .Where(c => c.Id == id)
        //    .ExecuteUpdateAsync(s => s
        //    .SetProperty(c => c.LockoutEnd, DateTime.UtcNow) 
        //    .SetProperty(c => c.AccessFailedCount, 0),
        //    cancellationToken);

        //if (affectedRows == 0)
        //    return Result.Failure(UserErrors.NotFound(id));

        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure(UserErrors.NotFound(id));

        await _userManager.SetLockoutEndDateAsync(user, null);

        return Result.Success();
    }
    public async Task<Result<UserProfileResponse>> GetProfileAsync(string userId)
    {
        var user = await _userManager.Users
            .Where(x => x.Id == userId)
            .ProjectToType<UserProfileResponse>()
            .SingleAsync();

        return Result.Success(user);
    }

    public async Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request)
    {
        var affectedRows = await _userManager.Users
              .Where(x => x.Id == userId)
              .ExecuteUpdateAsync(s => s
              .SetProperty(c => c.FirstName, request.FirstName)
              .SetProperty(c => c.LastName, request.LastName));

        if (affectedRows == 0)
            return Result.Failure(UserErrors.NotFound(userId));

        return Result.Success();
    }

    public async Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        var user = await _userManager.FindByIdAsync(userId);

        var result = await _userManager.ChangePasswordAsync(user!, request.CurrentPassword, request.NewPassword);

        if (!result.Succeeded)
        {
            var error = result.Errors.First();

            return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        return Result.Success();
    }
}
