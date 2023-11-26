using BlazorNet8.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BlazorNet8.Api.Infrastructure;
public class BlazorNetContext : DbContext
{
    public BlazorNetContext(DbContextOptions<BlazorNetContext> options) : base(options) { }

    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
}