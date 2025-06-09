using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Infra.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

    public DbSet<Applicant> Applicants => Set<Applicant>();
    public DbSet<PhoneNumber> PhoneNumbers => Set<PhoneNumber>();
    public DbSet<Official> OfficialUses => Set<Official>();
    public DbSet<ApplicationProgramme> ApplicationProgrammes => Set<ApplicationProgramme>();

    public DbSet<Gender> Genders => Set<Gender>();
    public DbSet<MaritalStatus> MaritalStatuses => Set<MaritalStatus>();
    public DbSet<Programme> Programmes => Set<Programme>();

    public DbSet<County> Counties => Set<County>();
    public DbSet<SubCounty> SubCounties => Set<SubCounty>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<SubLocation> SubLocations => Set<SubLocation>();
    public DbSet<Village> Villages => Set<Village>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>()
            .HasIndex(a => a.IDNumber)
            .IsUnique();

        modelBuilder.Entity<Applicant>()
            .HasIndex(a => a.ApplicationDate);

        modelBuilder.Entity<Applicant>()
            .HasOne(a => a.Gender)
            .WithMany(g => g.Applicants)
            .HasForeignKey(a => a.GenderId);

        modelBuilder.Entity<Applicant>()
            .HasOne(a => a.MaritalStatus)
            .WithMany(m => m.Applicants)
            .HasForeignKey(a => a.MaritalStatusId);

        modelBuilder.Entity<Applicant>()
            .HasOne(a => a.Village)
            .WithMany(v => v.Applicants)
            .HasForeignKey(a => a.VillageId);

        modelBuilder.Entity<PhoneNumber>()
            .HasIndex(p => p.Number);

        modelBuilder.Entity<PhoneNumber>()
            .HasOne(p => p.Applicant)
            .WithMany(a => a.PhoneNumbers)
            .HasForeignKey(p => p.ApplicantId);

        // === ApplicationProgramme ===
        modelBuilder.Entity<ApplicationProgramme>()
            .HasIndex(ap => new { ap.ApplicantId, ap.ProgrammeId });

        modelBuilder.Entity<ApplicationProgramme>()
            .HasOne(ap => ap.Applicant)
            .WithMany(a => a.ApplicationProgrammes)
            .HasForeignKey(ap => ap.ApplicantId);

        modelBuilder.Entity<ApplicationProgramme>()
            .HasOne(ap => ap.Programme)
            .WithMany(p => p.ApplicationProgrammes)
            .HasForeignKey(ap => ap.ProgrammeId);

        modelBuilder.Entity<Official>()
            .HasOne(o => o.Applicant)
            .WithOne(a => a.OfficialUse)
            .HasForeignKey<Official>(o => o.ApplicantId);

        modelBuilder.Entity<SubCounty>()
            .HasOne(sc => sc.County)
            .WithMany(c => c.SubCounties)
            .HasForeignKey(sc => sc.CountyId);

        modelBuilder.Entity<Location>()
            .HasOne(l => l.SubCounty)
            .WithMany(sc => sc.Locations)
            .HasForeignKey(l => l.SubCountyId);

        modelBuilder.Entity<SubLocation>()
            .HasOne(sl => sl.Location)
            .WithMany(l => l.SubLocations)
            .HasForeignKey(sl => sl.LocationId);

        modelBuilder.Entity<Village>()
            .HasOne(v => v.SubLocation)
            .WithMany(sl => sl.Villages)
            .HasForeignKey(v => v.SubLocationId);

        base.OnModelCreating(modelBuilder);
    }
}