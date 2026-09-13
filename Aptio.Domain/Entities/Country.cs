using Aptio.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Aptio.Domain.Entities
{
    public class Country :Base
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public class Configuration : IEntityTypeConfiguration<Country>
        {
            public void Configure(EntityTypeBuilder<Country> builder)
            {
                builder.HasIndex(x => x.Name).IsUnique();

            }
        }
    }
}
