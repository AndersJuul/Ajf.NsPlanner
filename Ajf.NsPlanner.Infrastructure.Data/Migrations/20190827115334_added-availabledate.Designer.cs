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
    [Migration("20190827115334_added-availabledate")]
    partial class addedavailabledate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview8.19405.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CounselorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeOfStart")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EventRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SchoolEventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SpecificationStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CounselorId");

                    b.HasIndex("EventRequestId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("SchoolEventId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.AvailableDate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AvailableDates");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Counselor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Counselors");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.EventRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredMeetingPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredWhen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionOrSchool")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantsAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantsGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantsNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolInstituteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeStamp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventRequests");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Target")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.SchoolEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SchoolEvent");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("Ajf.NsPlanner.Domain.Entities.Counselor", "Counselor")
                        .WithMany()
                        .HasForeignKey("CounselorId");

                    b.HasOne("Ajf.NsPlanner.Domain.Entities.EventRequest", "EventRequest")
                        .WithMany()
                        .HasForeignKey("EventRequestId");

                    b.HasOne("Ajf.NsPlanner.Domain.Entities.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.HasOne("Ajf.NsPlanner.Domain.Entities.SchoolEvent", "SchoolEvent")
                        .WithMany()
                        .HasForeignKey("SchoolEventId");
                });

            modelBuilder.Entity("Ajf.NsPlanner.Domain.Entities.Period", b =>
                {
                    b.OwnsOne("Ajf.NsPlanner.Domain.Entities.DateRange", "DateRange", b1 =>
                        {
                            b1.Property<Guid>("PeriodId")
                                .HasColumnType("uniqueidentifier");

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
