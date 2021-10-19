using AcademyModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistance.EFContext
{
	public class AcademyContext : DbContext
	{
		public DbSet<Area> Areas { get; set; }
		public DbSet<Classroom> Classrooms { get; set; }
		public DbSet<Competence> Competences { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseEdition> CourseEditions { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }
		public AcademyContext() {}
		public AcademyContext(DbContextOptions<AcademyContext> options) : base(options) {}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = localhost; User Id=sa; Password=1Secure*Password; Database = Academy", x => x.UseNodaTime())
			    .LogTo(Console.WriteLine,
			    new[] {
				 DbLoggerCategory.Database.Command.Name
				    },
				     LogLevel.Information)
				     .EnableSensitiveDataLogging();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Student>()
				.HasMany(s => s.Enrollments)
				.WithOne(e => e.Student)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Course>()
				.Property(c => c.Title)
				.IsRequired();
			modelBuilder.Entity<Person>()
				.Property(c => c.Firstname)
				.IsRequired();
			modelBuilder.Entity<Person>()
				.Property(c => c.Lastname)
				.IsRequired();
			modelBuilder.Entity<Enrollment>()
				.HasIndex(e => new { e.StudentId, e.CourseEditionId });
		}
	}
}
