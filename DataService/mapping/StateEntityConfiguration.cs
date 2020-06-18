using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.mapping
{
    
        public class StateEntityConfiguration : IEntityTypeConfiguration<State>
        {
            public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State")
         .HasOne<Country>(s => s.Country)
         .WithMany(g => g.States)
         .HasForeignKey(s => s.CountryId);
            builder.ToTable("State");
                builder.HasKey(s => s.StateId);
                builder.Property(p => p.StateName)
                        .HasColumnName("StateName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");
                builder.Property(p => p.Statecode)
                       .HasColumnName("Statecode")
                       .HasMaxLength(3)
                       .HasColumnType("varchar(50)");
            }
        }
    
}
