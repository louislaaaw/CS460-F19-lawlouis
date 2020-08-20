namespace HW_8.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HW_8.Models;

    public partial class HSTrackContext : DbContext
    {
        public HSTrackContext()
            : base("name=HSTrackContext")
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>()
                .Property(e => e.AthleteName)
                .IsUnicode(false);

            modelBuilder.Entity<Athlete>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Athlete)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .Property(e => e.CoachName)
                .IsUnicode(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Coach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.TeamName)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Athletes)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);
        }
    }
}
