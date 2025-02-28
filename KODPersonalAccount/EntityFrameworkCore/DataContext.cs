using KODPersonalAccount.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KODPersonalAccount.Models;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Direction> Directions { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<UserToGroup> UserToGroups { get; set; }
    public DbSet<LessonAttendance> LessonAttendances { get; set; }


    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserToGroup>()
            .HasKey(ug => new { ug.UserId, ug.GroupId });

        modelBuilder.Entity<LessonAttendance>()
            .HasKey(la => new { la.LessonId, la.UserId });

        modelBuilder.Entity<Group>(g =>
        {
            g.ToTable("Groups");
            
            g.HasKey(k => k.Id);
            g.HasOne<Direction>().WithMany()
                .HasForeignKey(p => p.DirectionId)
                .OnDelete(DeleteBehavior.Restrict);
            g.HasOne<User>().WithMany()
                .HasForeignKey(p => p.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            g.HasMany<User>().WithMany()
                .UsingEntity("UserToGroup");

        modelBuilder.Entity<Direction>(d =>
        {
            d.ToTable("Directions");

            d.HasKey(k => k.Title);
            d.Property(k => k.Title)
                .HasMaxLength(128);
            d.Property(k => k.Title)
                .IsRequired();
        });

        modelBuilder.Entity<Lesson>(l =>
        {
            l.ToTable("Lessons");
            
            l.HasKey(k => k.Id);
            l.HasOne<Group>().WithMany()
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            l.Property(p => p.Title)
                .HasMaxLength(128)
                .HasConversion<string>()
                .IsRequired();

            l.HasIndex(p => p.Date);
        });
        
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Role);
    }
}