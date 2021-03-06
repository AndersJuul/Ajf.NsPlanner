﻿using Ajf.NsPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ajf.NsPlanner.Infrastructure.Data.Data
{
    public class PeriodConfiguration : IEntityTypeConfiguration<Period>
    {
        public void Configure(EntityTypeBuilder<Period> builder)
        {
            builder
                .OwnsOne(m => m.DateRange, a =>
                {
                    a.Property(p => p.Start)
                        .HasColumnType("datetime2(7)")
                        .HasColumnName("Start")
                        .IsRequired();
                    a.Property(p => p.End)
                        .HasColumnType("datetime2(7)")
                        .HasColumnName("End")
                        .IsRequired();
                });
            builder
                .HasIndex(u => u.Target)
                .IsUnique();
            builder
                .HasMany<EventRequest>()
                .WithOne(a => a.Period)
                .IsRequired()
                .HasPrincipalKey(x=>x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany<AvailableDate>()
                .WithOne(a => a.Period)
                .IsRequired()
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}