using Aptio.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aptio.Domain.Entities
{
    public class City : Base
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("StateId")]
        public long StateId { get; set; }
        public virtual State State { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public class Configuration : IEntityTypeConfiguration<City>
        {
            public void Configure(EntityTypeBuilder<City> builder)
            {
                builder.HasIndex(x => x.Name).IsUnique();

                builder.HasOne(x => x.State).WithMany().OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}
