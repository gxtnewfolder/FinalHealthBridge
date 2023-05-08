using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HB.Models;
using FinalHealthBridge.Models;

namespace FinalHealthBridge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HB.Models.Patient> Patient { get; set; } = default!;
        public DbSet<FinalHealthBridge.Models.HealthcareProvider> HealthcareProvider { get; set; } = default!;
        public DbSet<FinalHealthBridge.Models.Medical_History> Medical_History { get; set; } = default!;
        public DbSet<FinalHealthBridge.Models.Prescription> Prescription { get; set; } = default!;
        public DbSet<FinalHealthBridge.Models.Test_Result> Test_Result { get; set; } = default!;
        public DbSet<FinalHealthBridge.Models.Treatment_Plan> Treatment_Plan { get; set; } = default!;
    }
}