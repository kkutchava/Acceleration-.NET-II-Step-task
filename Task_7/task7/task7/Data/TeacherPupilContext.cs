using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task7.Models;


namespace task7.Data
{
    internal class TeacherPupilContext : DbContext
    {
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Pupil> Pupil { get; set; }
        public DbSet<TP> Tp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            optBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TeacherPupil;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TP>()
                .HasKey(tp => new { tp.TId, tp.PId });

            modelBuilder.Entity<TP>()
                .HasOne(tp => tp.Teacher)
                .WithMany()
                .HasForeignKey(tp => tp.TId);

            modelBuilder.Entity<TP>()
                .HasOne(tp => tp.Pupil)
                .WithMany()
                .HasForeignKey(tp => tp.PId);
        }

    }
}


