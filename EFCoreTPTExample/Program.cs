// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

using TPTExampleDb context = new();
//await context.Students.AddAsync(new() { Name = "Hilmi", School = "Yozgat Ticaret Meslek Lisesi" });
//await context.Students.AddAsync(new() { Name = "Furkan", School = "Kaşıkçı Torna Tesviye Meslek Lisesi" });
//await context.Students.AddAsync(new() { Name = "Ali", School = "Bülbülderesi Anadolu Meslek Lisesi" });
//await context.Teachers.AddAsync(new() { Name = "Emrah", Branch = "Matematik" });
//await context.Teachers.AddAsync(new() { Name = "Engin", Branch = "Müzik" });
//await context.Teachers.AddAsync(new() { Name = "Erol", Branch = "Dayak" });
//await context.SaveChangesAsync();

var students = await context.Students.ToListAsync();
var teachers = await context.Teachers.ToListAsync();

//Entity Framework Core - Table Per Type(TPT)
public class ApplicationUser
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Student : ApplicationUser
{
    public string School { get; set; }
}
public class Teacher : ApplicationUser
{
    public string Branch { get; set; }
}


public class TPTExampleDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Server=***");
    }
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Table Per Type(TPT)
        modelBuilder.Entity<Student>().ToTable("StudentUsers");
        modelBuilder.Entity<Teacher>().ToTable("TeacherUsers");
    }
}