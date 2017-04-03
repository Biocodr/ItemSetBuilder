﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.DataAccess.DbContexts;
using WebApi.Model.Enums;

namespace WebApi.DataAccess.Migrations
{
    [DbContext(typeof(LeagueContext))]
    [Migration("20170403181217_CreateLeageContext")]
    partial class CreateLeageContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Model.Model.League.SummonerLeagueEntry", b =>
                {
                    b.Property<long>("PlayerId");

                    b.Property<int>("LeaguePoints");

                    b.Property<int>("Losses");

                    b.Property<int>("Region");

                    b.Property<int>("Wins");

                    b.HasKey("PlayerId");

                    b.ToTable("SummonerLeagueEntry");
                });
        }
    }
}