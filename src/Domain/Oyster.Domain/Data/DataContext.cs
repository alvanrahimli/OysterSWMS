using Microsoft.EntityFrameworkCore;
using Oyster.Domain.Models;
using Oyster.Domain.Models.Enums;
using Oyster.Utils;

namespace Oyster.Domain.Data;

public class DataContext : DbContext
{
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<ApiToken> ApiTokens => Set<ApiToken>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<TrashBin> TrashBins => Set<TrashBin>();
    public DbSet<Media> Medias => Set<Media>();
    public DbSet<BinArea> BinAreas => Set<BinArea>();
    public DbSet<ServiceArea> ServiceAreas => Set<ServiceArea>();
    public DbSet<TrashBinSnapshot> TrashBinSnapshots => Set<TrashBinSnapshot>();
    public DbSet<Truck> Trucks => Set<Truck>();
    public DbSet<CalculatedRoute> CalculatedRoutes => Set<CalculatedRoute>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AppUser>()
            .HasData(new AppUser
            {
                Id = 1,
                Email = "alvan@rahim.li",
                FullName = "Alvan Rahimli",
                PasswordHash = Crypto.GeneratePwdHash("Admin123"),
                CreatedAt = new DateTime(2023, 5, 6, 13, 42, 0, DateTimeKind.Utc),
                Roles = new List<Role> { Role.Administrator }
            });
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    { }
}
