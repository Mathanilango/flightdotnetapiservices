﻿// <auto-generated />
using System;
using Bookingservice.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bookingservice.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220625072503_nnn")]
    partial class nnn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bookingservice.Model.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<string>("Meal");

                    b.Property<string>("Pnrno");

                    b.Property<int>("Seatno");

                    b.Property<int>("age");

                    b.Property<DateTime>("datecreated");

                    b.Property<DateTime>("dateofjourney");

                    b.Property<string>("name");

                    b.Property<bool>("removed");

                    b.Property<int>("seattype");

                    b.HasKey("Id");

                    b.ToTable("passengers");
                });

            modelBuilder.Entity("Bookingservice.Model.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineId");

                    b.Property<int>("BookedSeats");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("Dateofjourney");

                    b.Property<string>("Email");

                    b.Property<int>("FlightId");

                    b.Property<string>("Gender");

                    b.Property<string>("Pnrno")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("N'PNR'+ RIGHT('00000'+CAST(ID AS VARCHAR(5)),5)");

                    b.Property<bool>("Removed");

                    b.Property<string>("Seattype");

                    b.Property<DateTime>("TicketcancelledDate");

                    b.Property<int>("amountpaided");

                    b.Property<int>("amountrefunded");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
