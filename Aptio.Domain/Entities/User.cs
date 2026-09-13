using Aptio.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aptio.Domain.Entities
{
    public class User :Base
    {
        [Key]
        public long Id { get; set; }


        [ForeignKey("RoleId")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }  


        [StringLength(50)]
        public string? FirstName { get; set; }


        [StringLength(50)]
        public string? LastName { get; set; }


        [StringLength(20)]
        public string? Phone { get; set; }


        [StringLength(100)]
        public string Email { get; set; }


        [StringLength(50)]
        public string Password { get; set; }


        [StringLength(200)]
        public string? Address { get; set; }


        [ForeignKey("CityId")]
        public long? CityId { get; set; }
        public virtual City City { get; set; }


        public class Cofiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User>builder)
            {
                builder.HasIndex(x => x.Email).IsUnique();
                

                builder.HasOne(x => x.Role).WithMany().OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.City).WithMany().OnDelete(DeleteBehavior.Restrict);
            }
        }

    }
}
