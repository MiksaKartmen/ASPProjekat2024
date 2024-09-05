using ASPProjekat.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain.Configurations
{
    public class ReservationConfiguration : EntityConfiguration<Reservation>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.People).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.HasOne(x => x.Table).WithMany(x => x.Reservations)
                                        .HasForeignKey(x => x.TableId)
                                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
