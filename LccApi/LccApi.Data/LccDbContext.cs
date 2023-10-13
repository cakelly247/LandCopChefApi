using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LccApi.Models;

namespace LccApi.Data;

public class LccDbContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
<<<<<<< HEAD
    {
    public LccDbContext(DbContextOptions<LccDbContext> options) : base(options) {}

    public DbSet<CommentModel> Comments {get; set;}
=======
{
    public LccDbContext(DbContextOptions<LccDbContext> options) : base(options) {}

    public DbSet<ReplyEntity> Replies { get; set; }
>>>>>>> main

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserModel>().ToTable("Users");
        modelBuilder.Entity<CommentModel>().ToTable("Comments");
    }
}