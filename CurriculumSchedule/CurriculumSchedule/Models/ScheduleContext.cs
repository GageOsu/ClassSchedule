using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CurriculumSchedule.Models;

public partial class ScheduleContext : DbContext
{
    public ScheduleContext()
    {
    }

    public ScheduleContext(DbContextOptions<ScheduleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<CabinetType> CabinetTypes { get; set; }

    public virtual DbSet<Day> Days { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonNumber> LessonNumbers { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Week> Weeks { get; set; }

    public virtual DbSet<Weekday> Weekdays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GAGE-OSU-LAPTOP; Database=Schedule; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.Idcabinet);

            entity.HasIndex(e => e.CabinetNumber, "UQ_Cabinet_CabinetNumber").IsUnique();

            entity.Property(e => e.Idcabinet)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDCabinet");
            entity.Property(e => e.CabinetNumber).HasMaxLength(20);
            entity.Property(e => e.IdcabinetType).HasColumnName("IDCabinetType");

            entity.HasOne(d => d.IdcabinetNavigation).WithOne(p => p.Cabinet)
                .HasForeignKey<Cabinet>(d => d.Idcabinet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cabinets_CabinetTypes");
        });

        modelBuilder.Entity<CabinetType>(entity =>
        {
            entity.HasKey(e => e.Idcabinet);

            entity.Property(e => e.Idcabinet).HasColumnName("IDCabinet");
            entity.Property(e => e.CabinetName).HasMaxLength(45);
            entity.Property(e => e.Discription).HasMaxLength(45);
        });

        modelBuilder.Entity<Day>(entity =>
        {
            entity.HasKey(e => e.Idday);

            entity.Property(e => e.Idday).HasColumnName("IDDay");
            entity.Property(e => e.Idweek).HasColumnName("IDWeek");
            entity.Property(e => e.Idweekday).HasColumnName("IDWeekday");

            entity.HasOne(d => d.IdweekNavigation).WithMany(p => p.Days)
                .HasForeignKey(d => d.Idweek)
                .HasConstraintName("FK_Days_Weeks");

            entity.HasOne(d => d.IdweekdayNavigation).WithMany(p => p.Days)
                .HasForeignKey(d => d.Idweekday)
                .HasConstraintName("FK_Days_Weekdays");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Idgroup).HasName("PK_Group_IDGroup");

            entity.HasIndex(e => e.GroupNumber, "UQ_Group_GroupNumber").IsUnique();

            entity.HasIndex(e => e.ShortNumber, "UQ_Group_ShortNumber").IsUnique();

            entity.Property(e => e.Idgroup).HasColumnName("IDGroup");
            entity.Property(e => e.GroupNumber).HasMaxLength(50);
            entity.Property(e => e.ShortNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Idlesson);

            entity.Property(e => e.Idlesson).HasColumnName("IDLesson");
            entity.Property(e => e.Idcabinet).HasColumnName("IDCabinet");
            entity.Property(e => e.Idday).HasColumnName("IDDay");
            entity.Property(e => e.Idgroup).HasColumnName("IDGroup");
            entity.Property(e => e.IdlessonNumber).HasColumnName("IDLessonNumber");
            entity.Property(e => e.Idsubject).HasColumnName("IDSubject");
            entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");

            entity.HasOne(d => d.IdcabinetNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idcabinet)
                .HasConstraintName("FK_Lessons_Cabinets");

            entity.HasOne(d => d.IddayNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idday)
                .HasConstraintName("FK_Lessons_Days");

            entity.HasOne(d => d.IdgroupNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idgroup)
                .HasConstraintName("FK_Lessons_Groups");

            entity.HasOne(d => d.IdlessonNumberNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.IdlessonNumber)
                .HasConstraintName("FK_Lessons_LessonNumbers");

            entity.HasOne(d => d.IdsubjectNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idsubject)
                .HasConstraintName("FK_Lessons_Subjects");

            entity.HasOne(d => d.IdteacherNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.Idteacher)
                .HasConstraintName("FK_Lessons_Teachers");
        });

        modelBuilder.Entity<LessonNumber>(entity =>
        {
            entity.HasKey(e => e.IdlessonNumber);

            entity.Property(e => e.IdlessonNumber).HasColumnName("IDLessonNumber");
            entity.Property(e => e.LessonNumber1).HasColumnName("LessonNumber");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Idsemester);

            entity.Property(e => e.Idsemester).HasColumnName("IDSemester");
            entity.Property(e => e.Year)
                .HasMaxLength(4)
                .IsFixedLength();
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Idsubject);

            entity.Property(e => e.Idsubject).HasColumnName("IDSubject");
            entity.Property(e => e.SubjectName).HasMaxLength(70);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Idteacher).HasName("PK_Teachers_1");

            entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");
            entity.Property(e => e.MiddleName).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Surname).HasMaxLength(45);
        });

        modelBuilder.Entity<Week>(entity =>
        {
            entity.HasKey(e => e.Idweek);

            entity.Property(e => e.Idweek).HasColumnName("IDWeek");
            entity.Property(e => e.Idsemester).HasColumnName("IDSemester");

            entity.HasOne(d => d.IdsemesterNavigation).WithMany(p => p.Weeks)
                .HasForeignKey(d => d.Idsemester)
                .HasConstraintName("FK_Weeks_Semesters");
        });

        modelBuilder.Entity<Weekday>(entity =>
        {
            entity.HasKey(e => e.Idweekday);

            entity.Property(e => e.Idweekday).HasColumnName("IDWeekday");
            entity.Property(e => e.NameWeekday).HasMaxLength(11);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
