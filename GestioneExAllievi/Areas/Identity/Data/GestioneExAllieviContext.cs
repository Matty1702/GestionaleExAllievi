using GestioneExAllievi.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestioneExAllievi.Models;

namespace GestioneExAllievi.Data;

public class GestioneExAllieviContext : IdentityDbContext<GestioneExAllieviUser>
{
    public GestioneExAllieviContext(DbContextOptions<GestioneExAllieviContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<GestioneExAllievi.Models.DatiExAllievi> DatiExAllievi { get; set; } = default!;

    public DbSet<GestioneExAllievi.Models.Offerte> Offerte { get; set; } = default!;
}
