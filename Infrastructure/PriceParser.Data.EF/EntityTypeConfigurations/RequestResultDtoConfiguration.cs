using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using PriceParser.Application.Data;

namespace PriceParser.Data.EF.EntityTypeConfigurations
{
    internal class RequestResultDtoConfiguration : IEntityTypeConfiguration<RequestResultDto>
    {
        public void Configure(EntityTypeBuilder<RequestResultDto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Items)
                   .HasConversion(
                                  value => JsonConvert.SerializeObject(value),
                                  value => JsonConvert.DeserializeObject<List<Item>>(value),
                   new ValueComparer<List<Item>>(
                       (c1, c2) => c1.SequenceEqual(c2),
                       c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                       c => c.ToList()));
            builder.Property(x => x.BestItems)
                   .HasConversion(
                                  value => JsonConvert.SerializeObject(value),
                                  value => JsonConvert.DeserializeObject<List<Item>>(value),
                   new ValueComparer<List<Item>>(
                       (c1, c2) => c1.SequenceEqual(c2),
                       c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                       c => c.ToList()));
        }
    }
}
