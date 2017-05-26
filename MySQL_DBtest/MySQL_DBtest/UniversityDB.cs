namespace MySQL_DBtest {
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class UniversityDB : DbContext {
    public UniversityDB()
        : base("name=Model1") {
    }

    public virtual DbSet<advisor> advisors { get; set; }
    public virtual DbSet<classroom> classrooms { get; set; }
    public virtual DbSet<course> courses { get; set; }
    public virtual DbSet<department> departments { get; set; }
    public virtual DbSet<instructor> instructors { get; set; }
    public virtual DbSet<section> sections { get; set; }
    public virtual DbSet<student> students { get; set; }
    public virtual DbSet<take> takes { get; set; }
    public virtual DbSet<teach> teaches { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Entity<advisor>()
          .Property(e => e.student_id)
          .IsUnicode(false);

      modelBuilder.Entity<advisor>()
          .Property(e => e.instructor_id)
          .IsUnicode(false);

      modelBuilder.Entity<classroom>()
          .Property(e => e.building)
          .IsUnicode(false);

      modelBuilder.Entity<classroom>()
          .Property(e => e.room_number)
          .IsUnicode(false);

      modelBuilder.Entity<classroom>()
          .Property(e => e.capacity)
          .HasPrecision(3, 0);

      modelBuilder.Entity<classroom>()
          .HasMany(e => e.sections)
          .WithOptional(e => e.classroom)
          .HasForeignKey(e => new { e.building, e.room_number });

      modelBuilder.Entity<course>()
          .Property(e => e.course_id)
          .IsUnicode(false);

      modelBuilder.Entity<course>()
          .Property(e => e.title)
          .IsUnicode(false);

      modelBuilder.Entity<course>()
          .Property(e => e.dept_name)
          .IsUnicode(false);

      modelBuilder.Entity<course>()
          .Property(e => e.credits)
          .HasPrecision(2, 0);

      modelBuilder.Entity<course>()
          .HasMany(e => e.teaches)
          .WithRequired(e => e.course)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<course>()
          .HasMany(e => e.sections)
          .WithRequired(e => e.course)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<course>()
          .HasMany(e => e.course1)
          .WithMany(e => e.courses)
          .Map(m => m.ToTable("prereq").MapLeftKey("course_id").MapRightKey("prereq_id"));

      modelBuilder.Entity<department>()
          .Property(e => e.dept_name)
          .IsUnicode(false);

      modelBuilder.Entity<department>()
          .Property(e => e.building)
          .IsUnicode(false);

      modelBuilder.Entity<department>()
          .Property(e => e.budget)
          .HasPrecision(12, 2);

      modelBuilder.Entity<instructor>()
          .Property(e => e.ID)
          .IsUnicode(false);

      modelBuilder.Entity<instructor>()
          .Property(e => e.name)
          .IsUnicode(false);

      modelBuilder.Entity<instructor>()
          .Property(e => e.dept_name)
          .IsUnicode(false);

      modelBuilder.Entity<instructor>()
          .Property(e => e.salary)
          .HasPrecision(10, 2);

      modelBuilder.Entity<instructor>()
          .HasMany(e => e.advisors)
          .WithOptional(e => e.instructor)
          .HasForeignKey(e => e.instructor_id);

      modelBuilder.Entity<section>()
          .Property(e => e.course_id)
          .IsUnicode(false);

      modelBuilder.Entity<section>()
          .Property(e => e.sec_id)
          .IsUnicode(false);

      modelBuilder.Entity<section>()
          .Property(e => e.semester)
          .IsUnicode(false);

      modelBuilder.Entity<section>()
          .Property(e => e.year)
          .HasPrecision(4, 0);

      modelBuilder.Entity<section>()
          .Property(e => e.building)
          .IsUnicode(false);

      modelBuilder.Entity<section>()
          .Property(e => e.room_number)
          .IsUnicode(false);

      modelBuilder.Entity<section>()
          .Property(e => e.time_slot_id)
          .IsUnicode(false);

      modelBuilder.Entity<section>()
          .HasMany(e => e.takes)
          .WithRequired(e => e.section)
          .HasForeignKey(e => new { e.course_id, e.sec_id, e.semester, e.year })
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<student>()
          .Property(e => e.ID)
          .IsUnicode(false);

      modelBuilder.Entity<student>()
          .Property(e => e.name)
          .IsUnicode(false);

      modelBuilder.Entity<student>()
          .Property(e => e.dept_name)
          .IsUnicode(false);

      modelBuilder.Entity<student>()
          .Property(e => e.tot_credit)
          .HasPrecision(3, 0);

      modelBuilder.Entity<student>()
          .HasOptional(e => e.advisor)
          .WithRequired(e => e.student);

      modelBuilder.Entity<take>()
          .Property(e => e.ID)
          .IsUnicode(false);

      modelBuilder.Entity<take>()
          .Property(e => e.course_id)
          .IsUnicode(false);

      modelBuilder.Entity<take>()
          .Property(e => e.sec_id)
          .IsUnicode(false);

      modelBuilder.Entity<take>()
          .Property(e => e.semester)
          .IsUnicode(false);

      modelBuilder.Entity<take>()
          .Property(e => e.year)
          .HasPrecision(4, 0);

      modelBuilder.Entity<take>()
          .Property(e => e.grade)
          .IsUnicode(false);

      modelBuilder.Entity<teach>()
          .Property(e => e.ID)
          .IsUnicode(false);

      modelBuilder.Entity<teach>()
          .Property(e => e.course_id)
          .IsUnicode(false);

      modelBuilder.Entity<teach>()
          .Property(e => e.sec_id)
          .IsUnicode(false);

      modelBuilder.Entity<teach>()
          .Property(e => e.semester)
          .IsUnicode(false);

      modelBuilder.Entity<teach>()
          .Property(e => e.year)
          .HasPrecision(4, 0);
    }
  }
}
