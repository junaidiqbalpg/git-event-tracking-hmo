using GitEventTrackingApi.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Data
{
    public class GitEventTrackingContext :DbContext
    {
        public GitEventTrackingContext(DbContextOptions<GitEventTrackingContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actor { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Repo> Repo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
