using SurveyBasket.Api.Abstractions.DataSeeding;
using SurveyBasket.Api.Contracts.Roles;

namespace SurveyBasket.Api.Services;

public class RoleService(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context) : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default) =>
        await _roleManager.Roles
            .Where(c => !c.IsDefault && (!c.IsDeleted || includeDisabled))
            .ProjectToType<RoleResponse>()
            .ToListAsync(cancellationToken);

    public async Task<Result<RoleDetailsResponse>> GetByIdAsync(string id)
    {
        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure<RoleDetailsResponse>(RoleErrors.NotFound);

        var permissions = await _roleManager.GetClaimsAsync(role);

        var response = new RoleDetailsResponse(role.Id, role.Name!, role.IsDeleted, permissions.Select(c => c.Value));

        return Result.Success(response);
    }

    public async Task<Result<RoleDetailsResponse>> AddAsync(RoleRequest request)
    {
        var roleIsExists = await _roleManager.RoleExistsAsync(request.Name);

        if (roleIsExists)
            return Result.Failure<RoleDetailsResponse>(RoleErrors.DuplicatedRole);

        var allowedPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allowedPermissions).Any())
            return Result.Failure<RoleDetailsResponse>(RoleErrors.InvalidPermissions);

        var role = new ApplicationRole
        {
            Name = request.Name,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
        };

        var result = await _roleManager.CreateAsync(role);

        if (!result.Succeeded)
        {
            var error = result.Errors.First();
            return Result.Failure<RoleDetailsResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        var permissions = request.Permissions
            .Select(c => new IdentityRoleClaim<string>
            {
                ClaimType = Permissions.Type,
                ClaimValue = c,
                RoleId = role.Id
            });

        await _context.AddRangeAsync(permissions);
        await _context.SaveChangesAsync();

        var response = new RoleDetailsResponse(role.Id, role.Name!, role.IsDeleted, request.Permissions);

        return Result.Success(response);
    }

    public async Task<Result> UpdateAsync(string id, RoleRequest request, CancellationToken cancellationToken = default)
    {
        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure<RoleDetailsResponse>(RoleErrors.NotFound);

        var roleIsExists = await _roleManager.Roles.AnyAsync(c => c.Name == request.Name && c.Id != id, cancellationToken);

        if (roleIsExists)
            return Result.Failure<RoleDetailsResponse>(RoleErrors.DuplicatedRole);

        var allowedPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allowedPermissions).Any())
            return Result.Failure<RoleDetailsResponse>(RoleErrors.InvalidPermissions);

        role.Name = request.Name;

        var result = await _roleManager.UpdateAsync(role);

        if (!result.Succeeded)
        {
            var error = result.Errors.First();
            return Result.Failure<RoleDetailsResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        var currentPermissions = await _context.RoleClaims
            .Where(c => c.RoleId == id && c.ClaimType == Permissions.Type)
            .Select(c => c.ClaimValue)
            .ToListAsync(cancellationToken: cancellationToken);

        var newPermissions = request.Permissions.Except(currentPermissions)
            .Select(c => new IdentityRoleClaim<string>
            {
                ClaimType = Permissions.Type,
                ClaimValue = c,
                RoleId = role.Id
            });

        var removedPermissions = currentPermissions.Except(request.Permissions);

        await _context.RoleClaims
            .Where(c => c.RoleId == id && removedPermissions.Contains(c.ClaimValue))
            .ExecuteDeleteAsync(cancellationToken);

        await _context.RoleClaims.AddRangeAsync(newPermissions, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken: cancellationToken);

        return Result.Success();
    }

    public async Task<Result> ToggleStatusAsync(string id, CancellationToken cancellationToken = default)
    {
        //if (await _roleManager.FindByIdAsync(id) is not { } role)
        //    return Result.Failure<RoleDetailsResponse>(RoleErrors.NotFound);

        var AffectedRows = await _context.Roles
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(c => c.IsDeleted, c => !c.IsDeleted)
            , cancellationToken);

        if (AffectedRows == 0)
            return Result.Failure<RoleDetailsResponse>(RoleErrors.NotFound);

        return Result.Success();
    }
}
