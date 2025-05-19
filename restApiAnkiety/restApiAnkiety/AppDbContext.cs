namespace restApiAnkiety
{
    using Microsoft.EntityFrameworkCore;
    using restApiAnkiety.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Form> Forms => Set<Form>();
        public DbSet<Option> Options => Set<Option>();

        public DbSet<Answer> Answers => Set<Answer>();
    }

}
