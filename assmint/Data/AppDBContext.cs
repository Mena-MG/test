using assmint.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace assmint.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> f) : base(f) { }
        public DbSet<Taske> tasks { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taske>()
                .HasOne(o => o.Projects)
                .WithMany(c => c.taskes)
                .HasForeignKey(o => o.Projectsid)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Taske>()
               .HasOne(o => o.TeamMembers)
               .WithMany(c => c.tasks)
               .HasForeignKey(o => o.TeamMembersid)
               .OnDelete(DeleteBehavior.Cascade);



            //modelBuilder.Entity<TeamMember>().HasMany(x=>x.tasks).WithOne(o=>o.TeamMembers).HasForeignKey(o=>o.TeamMembersid).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
