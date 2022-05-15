﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WiredBrainCoffee.Api.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20211204031308_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("WiredBrainCoffee.MinApi.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PromoCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 12, 3, 22, 13, 8, 225, DateTimeKind.Local).AddTicks(1651),
                            Description = "A coffee order",
                            OrderNumber = 100,
                            PromoCode = "Wired123",
                            Total = 25m
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2021, 12, 3, 22, 13, 8, 225, DateTimeKind.Local).AddTicks(1689),
                            Description = "A food order",
                            OrderNumber = 125,
                            PromoCode = "Wired123",
                            Total = 35m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
