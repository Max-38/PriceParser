using Microsoft.EntityFrameworkCore;
using PriceParser.Application.Data;
using PriceParser.Data.EF.EntityTypeConfigurations;

namespace PriceParser.Data.EF
{
    public class PriceParserDbContext : DbContext
    {
        public DbSet<RequestResultDto> requestResults { get; set; }

        public PriceParserDbContext(DbContextOptions<PriceParserDbContext> options)
            : base(options) { }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RequestResultDtoConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
