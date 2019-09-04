﻿// <auto-generated />

using System;
using Ajf.NsPlanner.Infrastructure.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190815123950_added-eventrequest")]
    partial class addedeventrequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview7.19362.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Counselor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Counselors");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.EventRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("EventRequests");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Target");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Period", b =>
                {
                    b.OwnsOne("Ajf.NsPlanner.Domain.Entities.DateRange", "DateRange", b1 =>
                        {
                            b1.Property<Guid>("PeriodId");

                            b1.Property<DateTime>("End")
                                .HasColumnName("End")
                                .HasColumnType("datetime2(7)");

                            b1.Property<DateTime>("Start")
                                .HasColumnName("Start")
                                .HasColumnType("datetime2(7)");

                            b1.HasKey("PeriodId");

                            b1.ToTable("Periods");

                            b1.WithOwner()
                                .HasForeignKey("PeriodId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
