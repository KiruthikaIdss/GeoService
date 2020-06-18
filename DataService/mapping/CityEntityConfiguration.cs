using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.mapping
{
   public  class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City")
         .HasOne<State>(s => s.State)
         .WithMany(g => g.Cities)
         .HasForeignKey(s => s.StateId);
            builder.ToTable("City");
            builder.HasKey(s => s.CityId);
            builder.Property(p => p.CityName)
                    .HasColumnName("CityName")
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");
            builder.Property(p => p.Citycode)
                   .HasColumnName("Citycode")
                   .HasMaxLength(3)
                   .HasColumnType("varchar(50)");
        }
    
    }
}
