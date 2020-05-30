﻿// <auto-generated />
using System;
using Allowed.Telegram.Bot.Sample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Allowed.Telegram.Bot.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200523184104_AddUserFiles")]
    partial class AddUserFiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Allowed.Telegram.Bot.Data.DbModels.UserFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("UserFiles");
                });

            modelBuilder.Entity("Allowed.Telegram.Bot.Models.Store.TelegramBot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("TelegramBots");
                });

            modelBuilder.Entity("Allowed.Telegram.Bot.Models.Store.TelegramRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("TelegramRoles");
                });

            modelBuilder.Entity("Allowed.Telegram.Bot.Models.Store.TelegramState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("TelegramBotId")
                        .HasColumnType("int");

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("TelegramBotId");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("TelegramStates");
                });

            modelBuilder.Entity("Allowed.Telegram.Bot.Models.Store.TelegramUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("TelegramUsers");
                });

            modelBuilder.Entity("Allowed.Telegram.Bot.Models.Store.TelegramUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TelegramRoleId")
                        .HasColumnType("int");

                    b.Property<int>("TelegramUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TelegramRoleId");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("TelegramUserRoles");
                });

            modelBuilder.Entity("Allowed.Telegram.Bot.Data.DbModels.UserFile", b =>
                {
                    b.HasOne("Allowed.Telegram.Bot.Models.Store.TelegramUser", "TelegramUser")
                        .WithMany()
                        .HasForeignKey("TelegramUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Allowed.Telegram.Bot.Models.Store.TelegramState", b =>
                {
                    b.HasOne("Allowed.Telegram.Bot.Models.Store.TelegramBot", "TelegramBot")
                        .WithMany()
                        .HasForeignKey("TelegramBotId");

                    b.HasOne("Allowed.Telegram.Bot.Models.Store.TelegramUser", "TelegramUser")
                        .WithMany()
                        .HasForeignKey("TelegramUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Allowed.Telegram.Bot.Models.Store.TelegramUserRole", b =>
                {
                    b.HasOne("Allowed.Telegram.Bot.Models.Store.TelegramRole", "TelegramRole")
                        .WithMany()
                        .HasForeignKey("TelegramRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Allowed.Telegram.Bot.Models.Store.TelegramUser", "TelegramUser")
                        .WithMany()
                        .HasForeignKey("TelegramUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
