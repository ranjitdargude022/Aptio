using Aptio.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aptio.Domain.Entities
{
    public class State : Base
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("CountryId")]
        public long CountryId { get; set; }

        public virtual Country Country { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public class Configuration : IEntityTypeConfiguration<State>
        {
            public void Configure(EntityTypeBuilder<State>builder)
            {
                builder.HasIndex(x => x.Name).IsUnique();

                builder.HasOne(x => x.Country).WithMany().OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}
