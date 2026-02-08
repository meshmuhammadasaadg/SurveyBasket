using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

namespace SurveyBasket.Api.Presistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
    : IdentityDbContext<AppUser>(options)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor; 

    public DbSet<Poll> Polls { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var currentUserId = _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var entries = ChangeTracker.Entries<AuditableEntity>();

        foreach (var entity in entries)
        {
            if (entity.State == EntityState.Added)  
                entity.Property(c => c.CreatedById).CurrentValue = currentUserId;

            else if (entity.State == EntityState.Modified)
            {
                entity.Property(c => c.UpdatedById).CurrentValue = currentUserId;
                entity.Property(c => c.UpdatedOn).CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}

