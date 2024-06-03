﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tabloid.Data;

#nullable disable

namespace Tabloid.Migrations
{
    [DbContext(typeof(TabloidDbContext))]
    partial class TabloidDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            Name = "Admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "12394234-2ad0-4d5f-b452-76e45ba30622",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAECvTSdS6WAhPCIAHGEF3Ikfl/PdFc+i8Q3vuC1X/BJAGKlGjzBwt+0Xx4H+fHGV/Hw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3cddd2ab-0224-4b58-bf7b-a999e2798487",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        },
                        new
                        {
                            Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8c7c01cc-1f7e-419a-938b-7c3f57a24182",
                            Email = "john@doe.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEK2I7TSJUTK5klzfVrmhZVYFioUYBxtHo4bW+sGCCCYwAc5toAui4jBTFBJG5kplaA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cdefe3b8-e3a1-42fe-ab7c-9988421e9851",
                            TwoFactorEnabled = false,
                            UserName = "JohnDoe"
                        },
                        new
                        {
                            Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "28bbaba2-6ee9-4fe0-b7f7-ad64d197cd9b",
                            Email = "jane@smith.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEP2qAH9Rz4YziNBSLX8HqsK4ANHY9ErrunKDFgAtWydZpFMtH0liV5k8La5a+EsG9A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3b7c3cfa-b574-448b-86dc-b79661dfa68a",
                            TwoFactorEnabled = false,
                            UserName = "JaneSmith"
                        },
                        new
                        {
                            Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "156e29a7-a1e7-42fd-8484-1e748d5431eb",
                            Email = "alice@johnson.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAENrQTWOXuqgGkBPw6vYIq01tKNtrR0/Rsk8mLuDejDYQi3GFsoPeJsx5cFCFhSx2Bw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "723afc3c-4455-4aa2-895e-f18b0e6784b4",
                            TwoFactorEnabled = false,
                            UserName = "AliceJohnson"
                        },
                        new
                        {
                            Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ca8e4a85-8f89-4b86-b2b4-6e809280d168",
                            Email = "bob@williams.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEKrPTRojNgrmgCfER/MOWUIW8F562v+JlCvb/zLQJJQIsi3SID/l20ubfjW3UQAg8w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "83bbc999-2d83-49c1-b527-4f267b160c3d",
                            TwoFactorEnabled = false,
                            UserName = "BobWilliams"
                        },
                        new
                        {
                            Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e32bb354-0baf-4471-b309-0f463b4c6417",
                            Email = "Eve@Davis.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEBsMycinu8pxLudZmk9qDt5ti28p6/aO6xzXSif3hcflisBl4Q0W9ZBKbgngxOW5Pw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4ab0f4f3-ed2d-4331-9dff-65cb366afc32",
                            TwoFactorEnabled = false,
                            UserName = "EveDavis"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        },
                        new
                        {
                            UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Tabloid.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Tech"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Lifestyle"
                        });
                });

            modelBuilder.Entity("Tabloid.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CommenteerId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommenteerId = 2,
                            Content = "This is the first comment.",
                            CreationDate = new DateTime(2024, 5, 29, 9, 28, 27, 218, DateTimeKind.Local).AddTicks(6130),
                            PostId = 1,
                            Subject = "First Comment"
                        },
                        new
                        {
                            Id = 2,
                            CommenteerId = 1,
                            Content = "This is the second comment.",
                            CreationDate = new DateTime(2024, 5, 29, 9, 28, 27, 218, DateTimeKind.Local).AddTicks(6140),
                            PostId = 2,
                            Subject = "Second Comment"
                        });
                });

            modelBuilder.Entity("Tabloid.Models.DemoteAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminApprovalId")
                        .HasColumnType("integer");

                    b.Property<int>("AdminToDemoteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("DemoteAdmins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminApprovalId = 1,
                            AdminToDemoteId = 2
                        });
                });

            modelBuilder.Entity("Tabloid.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Publication")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CategoryId = 1,
                            Content = "This is the content of the first post.",
                            IsApproved = true,
                            Publication = new DateTime(2024, 5, 29, 9, 28, 27, 218, DateTimeKind.Local).AddTicks(5820),
                            Title = "First Post"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            CategoryId = 2,
                            Content = "This is the content of the second post.",
                            IsApproved = true,
                            Publication = new DateTime(2024, 5, 29, 9, 28, 27, 218, DateTimeKind.Local).AddTicks(5930),
                            Title = "Second Post"
                        });
                });

            modelBuilder.Entity("Tabloid.Models.PostReaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("ReactionId")
                        .HasColumnType("integer");

                    b.Property<int>("ReactorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PostReactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 1,
                            ReactionId = 1,
                            ReactorId = 2
                        },
                        new
                        {
                            Id = 2,
                            PostId = 2,
                            ReactionId = 2,
                            ReactorId = 1
                        });
                });

            modelBuilder.Entity("Tabloid.Models.PostTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PostTags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 1,
                            TagId = 1
                        },
                        new
                        {
                            Id = 2,
                            PostId = 2,
                            TagId = 2
                        });
                });

            modelBuilder.Entity("Tabloid.Models.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Reactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageURL = "https://example.com/reaction1.png"
                        },
                        new
                        {
                            Id = 2,
                            ImageURL = "https://example.com/reaction2.png"
                        });
                });

            modelBuilder.Entity("Tabloid.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FollowerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SubbedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SubscriberId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UnsubbedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FollowerId = 2,
                            SubbedDate = new DateTime(2024, 5, 29, 9, 28, 27, 218, DateTimeKind.Local).AddTicks(6210),
                            SubscriberId = 1
                        });
                });

            modelBuilder.Entity("Tabloid.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TagName = "EFCore"
                        },
                        new
                        {
                            Id = 2,
                            TagName = "CSharp"
                        });
                });

            modelBuilder.Entity("Tabloid.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("text");

                    b.Property<string>("ImageLocation")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsDeactivated")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDateTime = new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Admina",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            ImageLocation = "https://robohash.org/numquamutut.png?size=150x150&set=set1",
                            IsDeactivated = false,
                            LastName = "Strator"
                        },
                        new
                        {
                            Id = 2,
                            CreateDateTime = new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                            ImageLocation = "https://robohash.org/nisiautemet.png?size=150x150&set=set1",
                            IsDeactivated = false,
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            CreateDateTime = new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jane",
                            IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                            ImageLocation = "https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1",
                            IsDeactivated = false,
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 4,
                            CreateDateTime = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alice",
                            IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                            ImageLocation = "https://robohash.org/deseruntutipsum.png?size=150x150&set=set1",
                            IsDeactivated = false,
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 5,
                            CreateDateTime = new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bob",
                            IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                            ImageLocation = "https://robohash.org/quiundedignissimos.png?size=150x150&set=set1",
                            IsDeactivated = true,
                            LastName = "Williams"
                        },
                        new
                        {
                            Id = 6,
                            CreateDateTime = new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Eve",
                            IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                            ImageLocation = "https://robohash.org/hicnihilipsa.png?size=150x150&set=set1",
                            IsDeactivated = false,
                            LastName = "Davis"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tabloid.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
                });
#pragma warning restore 612, 618
        }
    }
}
