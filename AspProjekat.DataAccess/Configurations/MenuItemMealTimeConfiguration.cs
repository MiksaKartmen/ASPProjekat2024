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
    public class MenuItemMealTimeConfiguration : EntityConfiguration<MenuItemMealTime>
    {
        public override void ConfigureEntity(EntityTypeBuilder<MenuItemMealTime> builder)
        {          

            builder.HasOne(x => x.MenuItem).WithMany(x => x.MenuItemMealTimes)
                                           .HasForeignKey(x => x.MenuItemId)
                                           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.MealTime).WithMany(x => x.MenuItemMealTime)
                                           .HasForeignKey(x => x.MealTimeId)
                                           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
