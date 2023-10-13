using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LccApi.Models;



namespace LccApi.Data;

public class LccDbContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
{
    public LccDbContext(DbContextOptions<LccDbContext> options) : base(options) {}

    public DbSet<ReplyEntity> Replies { get; set; }

    public DbSet<PostModel> Posts { get; set; } 



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>().ToTable("Users");
        }
    }

