using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Football;

public partial class DbfootballLeagueContext : DbContext
{
    public DbfootballLeagueContext()
    {
    }

    public DbfootballLeagueContext(DbContextOptions<DbfootballLeagueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MI_G_LAPTOP\\SQLEXPRESS; Database=DBFootballLeague; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<League>(entity =>
        {
            entity.Property(e => e.LeagueCountry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("League_country");
            entity.Property(e => e.LeagueName)
                .HasColumnType("ntext")
                .HasColumnName("League_name");
            entity.Property(e => e.NumOfTeams).HasColumnName("Num_of_teams");
            entity.Property(e => e.PartnerId).HasColumnName("Partner_id");

            entity.HasOne(d => d.Partner).WithMany(p => p.Leagues)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Leagues_Partners");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartnerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Partner_name");
            entity.Property(e => e.TypeOfActivity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Type_of_activity");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.LeagueId).HasColumnName("League_id");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Owner_name");
            entity.Property(e => e.StadiumName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Stadium_name");
            entity.Property(e => e.TeamCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Team_city");
            entity.Property(e => e.TeamLogo)
                .IsUnicode(false)
                .HasColumnName("Team_logo");
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Team_name");

            entity.HasOne(d => d.League).WithMany(p => p.Teams)
                .HasForeignKey(d => d.LeagueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teams_Leagues");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
