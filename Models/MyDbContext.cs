using Api.Models;
using Api.Models.Farmer;

using Microsoft.EntityFrameworkCore;
using System.Xml;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Api.Models.User> Users { get; set; }
    //public DbSet<Role> Roles { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<UserManagement> userManagements { get; set; }
    public DbSet<UserRole> userRoles { get; set; }

    public DbSet<Api.Models.Farmer.User> User { get; set; }
    public DbSet<Api.Models.Farmer.Land> Land { get; set; }
    public DbSet<Api.Models.Farmer.LandPart> LandPart { get; set; }
    public DbSet<Api.Models.Farmer.LandPartPesticide> LandPartPesticide { get; set; }
    public DbSet<Api.Models.Farmer.Pesticide> Pesticide { get; set; }
    public DbSet<Api.Models.Farmer.Yield> Yield { get; set; }

    ////Farmer New DbSets
    //public DbSet<Api.Models.FarmerNew.User> F_User { get; set; }
    //public DbSet<Api.Models.FarmerNew.Land> F_Land { get; set; }
    //public DbSet<Api.Models.FarmerNew.Cultivation> F_Cultivation { get; set; }
    //public DbSet<Api.Models.FarmerNew.Harvest> F_Harvest { get; set; }
    //public DbSet<Api.Models.FarmerNew.Pesticide> F_Pesticide { get; set; }
    //public DbSet<Api.Models.FarmerNew.Watering> F_Watering { get; set; }
    //public DbSet<Api.Models.FarmerNew.Reports> F_Reports { get; set; }

}
