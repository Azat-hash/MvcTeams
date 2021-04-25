using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamsMVC.Models;

namespace TeamsMVC.Context
{
    public class TeamsContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerAntropometrics> PlayerAntropometrics { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOptional(x => x.PlayerAntropometrics)
                .WithRequired(x => x.Player);

            base.OnModelCreating(modelBuilder);
        }
    }
}