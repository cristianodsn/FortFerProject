using Microsoft.EntityFrameworkCore;
using MinhaApi.Entities;
namespace MinhaApi.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        
        public DbSet<Produto>? produtos { get; set; }
    }
}
