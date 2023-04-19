using Microsoft.EntityFrameworkCore;
using WebSchoolMVC.Domain.Entity;

namespace WebSchoolMVC.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Subject>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasMany(a => a.Marks)
                .WithOne(b => b.Subject).HasForeignKey(x => x.Subject_Id)
                .OnDelete(DeleteBehavior.Cascade);

                x.HasMany(a => a.Timetables)
                .WithOne(b => b.Subject).HasForeignKey(x => x.Subject_Id)
                .OnDelete(DeleteBehavior.Cascade);

                x.HasMany(a => a.Teachers)
                .WithMany(b => b.Subjects)
                .UsingEntity<SubjectTeacher>(
                    c => c.HasOne(x => x.Teacher)
                    .WithMany(x => x.TeacherHasSubjects)
                    .HasForeignKey(x => x.Teacher_Id),

                    c => c.HasOne(x => x.Subject)
                    .WithMany(x => x.SubjectHasTeachers)
                    .HasForeignKey(x => x.Subject_Id),

                    c =>
                    {
                        c.HasKey(x => new { x.Subject_Id, x.Teacher_Id });
                        c.ToTable("SubjectTeacher");
                    }
                    );
            });

            builder.Entity<Teacher>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(a => a.GroupUnderLeading).WithOne(b => b.Teacher).HasForeignKey<Group>(x => x.Teacher_Id).OnDelete(DeleteBehavior.Cascade);
                x.HasOne(a => a.Room).WithOne(b => b.Teacher).HasForeignKey<Room>(x => x.Teacher_Id).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Student>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasMany(a => a.Marks).WithOne(b => b.Student).HasForeignKey(c => c.Student_Id);
            });

            builder.Entity<Group>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasMany(a => a.Students).WithOne(b => b.Group).HasForeignKey(c => c.Group_Id);
                x.HasMany(a => a.Timetables).WithOne(b => b.Group).HasForeignKey(c => c.Group_Id);
            });

            builder.Entity<Room>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasMany(a => a.Timetables).WithOne(b => b.Room).HasForeignKey(c => c.Room_Id);
            });

            builder.Entity<Admins>(x =>
            {
                x.HasKey(x => x.Id);
            });

            builder.Entity<Timetable>(x =>
            {
                x.HasKey(x => x.Id);
            });

            base.OnModelCreating(builder);
        }

        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Room> Room { get; set; }

        public DbSet<Group> Group { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Journal> Journal { get; set; }

        public DbSet<Admins> Admins { get; set; }
        public DbSet<Timetable> Timetable { get; set; }
        public DbSet<SubjectTeacher> SubjectTeacher { get; set; }
    }
}
