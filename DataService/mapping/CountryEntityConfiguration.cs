using Entity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


using System.Text;

namespace DataService.mapping
{
    public class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(s => s.CountryId);
            builder.Property(p => p.CountryName)
                    .HasColumnName("CountryName")
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");
            builder.Property(p => p.Countrycode)
                   .HasColumnName("Countrycode")
                   .HasMaxLength(3)
                   .HasColumnType("varchar(50)");
        }
    }
}
