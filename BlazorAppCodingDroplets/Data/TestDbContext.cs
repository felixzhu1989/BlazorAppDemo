using Microsoft.EntityFrameworkCore;

namespace BlazorAppCodingDroplets.Data
{
    public class TestDbContext:DbContext
    {
        public DbSet<Member> Members { get; set; }
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }
    }
}
