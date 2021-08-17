using BlazorLets.Shared.Models;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorLets.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<CycleGradeCourse> CycleGradeCourse { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Learn> Learn { get; set; }
        public DbSet<Example> Example { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<ReportedProblem> ReportedProblem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CycleGradeCourse>().ToTable("CycleGradeCourse");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Example>().ToTable("Example");
            modelBuilder.Entity<Learn>().ToTable("Learn");
            modelBuilder.Entity<Test>().ToTable("Test");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Answer>().ToTable("Answer");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<ReportedProblem>().ToTable("ReportedProblem");


            modelBuilder.Entity<Test>()
            .Property(o => o.MinimalScore).HasColumnType("decimal(3,1)");

            modelBuilder.Entity<Enrollment>()
           .Property(o => o.Score).HasColumnType("decimal(3,1)");

            modelBuilder.Entity<DeviceFlowCodes>()
           .HasNoKey();

            modelBuilder.Entity<PersistedGrant>()
           .HasKey("Key");

            modelBuilder.Entity<IdentityUserLogin<string>>()
           .HasNoKey();

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.HasKey(r => new { r.UserId, r.RoleId });

                b.ToTable("UserRoles");
            });

            modelBuilder.Entity<IdentityUserToken<string>>()
           .HasNoKey();

            modelBuilder.Entity<IdentityRole>(b =>
            {
                b.HasKey(r => r.Id);

                b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

                b.ToTable("Roles");

                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);

                b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            });

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasKey(u => u.Id);

                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

                b.ToTable("ApplicationUser");

                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });
        }
    }
}
