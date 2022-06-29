﻿// <auto-generated />
using System;
using Adminservice.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Adminservice.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220629045027_jkj")]
    partial class jkj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Adminservice.Model.Airline", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datecreated");

                    b.Property<string>("Name");

                    b.Property<bool>("Removed");

                    b.Property<bool>("blocked");

                    b.HasKey("ID");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("Adminservice.Model.Flight", b =>
                {
                    b.Property<int>("Flightnumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineId");

                    b.Property<int>("AvailableBusinessSeat");

                    b.Property<int>("AvailableNonBusinessSeat");

                    b.Property<int>("BusinessSeat");

                    b.Property<int>("BusinessSeatCost");

                    b.Property<string>("Couponcode");

                    b.Property<int>("Couponcodeamt");

                    b.Property<DateTime>("Datecreated");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("FromPlace");

                    b.Property<string>("Instrument");

                    b.Property<int>("NonBusinessSeat");

                    b.Property<int>("NonBusinessSeatCost");

                    b.Property<bool>("Removed");

                    b.Property<bool>("RoundTrip");

                    b.Property<string>("ScheduleDays");

                    b.Property<DateTime?>("StartDate");

                    b.Property<int>("TicketCost");

                    b.Property<string>("ToPlace");

                    b.HasKey("Flightnumber");

                    b.HasIndex("AirlineId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("Adminservice.Model.Flight", b =>
                {
                    b.HasOne("Adminservice.Model.Airline", "Airline")
                        .WithMany("flights")
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}