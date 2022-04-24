﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using secretsantaapp.Database;

namespace secretsantaapp.Migrations
{
    [DbContext(typeof(SecretSantaContext))]
    [Migration("20220424124330_migracija2")]
    partial class migracija2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("secretsantaapp.Database.Gift", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime");

                    b.Property<int>("FromUsersId")
                        .HasColumnType("int");

                    b.Property<int>("ToUsersId")
                        .HasColumnType("int");

                    b.HasKey("GiftId");

                    b.HasIndex("FromUsersId");

                    b.HasIndex("ToUsersId");

                    b.ToTable("Gift");
                });

            modelBuilder.Entity("secretsantaapp.Database.Roles", b =>
                {
                    b.Property<int>("RolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleDuty")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("RolesId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("secretsantaapp.Database.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("secretsantaapp.Database.UsersRoles", b =>
                {
                    b.Property<int>("UsersRolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("UsersRolesId");

                    b.HasIndex("RolesId");

                    b.HasIndex("UsersId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("secretsantaapp.Database.Gift", b =>
                {
                    b.HasOne("secretsantaapp.Database.Users", "FromUsers")
                        .WithMany("GiftFromUsers")
                        .HasForeignKey("FromUsersId")
                        .HasConstraintName("fk_fromusers")
                        .IsRequired();

                    b.HasOne("secretsantaapp.Database.Users", "ToUsers")
                        .WithMany("GiftToUsers")
                        .HasForeignKey("ToUsersId")
                        .HasConstraintName("fk_tousers")
                        .IsRequired();
                });

            modelBuilder.Entity("secretsantaapp.Database.UsersRoles", b =>
                {
                    b.HasOne("secretsantaapp.Database.Roles", "Roles")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RolesId")
                        .HasConstraintName("fk_roleid")
                        .IsRequired();

                    b.HasOne("secretsantaapp.Database.Users", "Users")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UsersId")
                        .HasConstraintName("fk_usersid")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
