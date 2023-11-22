using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    //public DbSet<Role> Roles { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<UserManagement> userManagements { get; set; }
    public DbSet<UserRole> userRoles { get; set; }
}
