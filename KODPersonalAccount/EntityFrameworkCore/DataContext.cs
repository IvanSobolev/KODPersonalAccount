using KODPersonalAccount.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KODPersonalAccount.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Direction> Directions { get; set; }
    public DbSet<Lesson> Lessons { get; set; }


    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(g =>
        {
            g.ToTable("Groups");

            g.HasKey(k => k.Id);
            g.HasOne<Direction>().WithMany()
                .HasForeignKey(p => p.Direction)
                .OnDelete(DeleteBehavior.Restrict);
            g.HasOne<User>().WithMany()
                .HasForeignKey(p => p.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            g.HasMany<User>(p => p.Students).WithMany()
                .UsingEntity("StudentToGroup");
        });
        
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
            l.HasMany<User>(p => p.Attendances).WithMany()
                .UsingEntity("Attendances");

            l.HasIndex(p => p.Date);
        });

        modelBuilder.Entity<User>(u =>
        {
            u.ToTable("Users");

            u.HasKey(k => k.Id);
        });
    }
}
