using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tabloid.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeactivated",
                table: "UserProfiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    CommenteerId = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemoteAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdminApprovalId = table.Column<int>(type: "integer", nullable: false),
                    AdminToDemoteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoteAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    ReactorId = table.Column<int>(type: "integer", nullable: false),
                    ReactionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    Publication = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageURL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriberId = table.Column<int>(type: "integer", nullable: false),
                    FollowerId = table.Column<int>(type: "integer", nullable: false),
                    SubbedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UnsubbedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bf22cc3-f88c-4c57-9d9c-894185ad1c70", "AQAAAAIAAYagAAAAEFDoKfeq3LxnK0MzIIDM1YbY5WS8C+uDuICVXgcKOz6GqKMbTWv7nwvM4UycfxdyCQ==", "cdbd319d-9479-400a-81f2-dd95c61e9638" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0dc40cc-d4bd-4e60-a90a-d294e5d97378", "AQAAAAIAAYagAAAAECwd5G+C8jlDL06IzpZe5Wh0V2FVDZ475ruDDEia8r9F/PvTAq4HOSl8CElKOz7Xxg==", "80b08a76-8799-4626-b949-33fa5f7421a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2b355b3-f3ee-47e3-b40d-6ac847fa2bbf", "AQAAAAIAAYagAAAAEObOKj0e4orpZEwdN9UPuZfIVPR7pPsGkRPhHPWQR3MZ42wW5DjAP00TsHiN4tQMHQ==", "500d7590-a3c2-4ed8-b5da-3fdf9db02920" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79feded1-765e-4ca0-a6d4-05a6b481d6f4", "AQAAAAIAAYagAAAAEOh+3Kc9FlvnDLDJ16FbCo4HzCKPDr2acN2PKlOmBuJG+mFFIrQQiRvGAWz/0k+/YQ==", "7ef44bcc-80ca-49d9-b8a0-e4d9256064fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a44df6ab-9725-46b9-9316-67a4517c0dbf", "AQAAAAIAAYagAAAAEKSkKPTopSIzGPLaC2H4gyEcJGTFDhd7s386QPjYzZABJ7/nPsuruMMntLd2tcMstw==", "47a2dba9-1ae2-4c8d-9b05-915f8b4bf54c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30437bca-d790-496a-a8dd-d1d86705ebbf", "AQAAAAIAAYagAAAAEHnW29nAehWw6iWFxWh22aYo4ytQTQwNjX8h7aKEhgimFSqaq6FuADkr/X6djTm8cQ==", "e53387fe-35eb-4ad1-937b-f286caf1d1c4" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Tech" },
                    { 2, "Lifestyle" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommenteerId", "Content", "CreationDate", "PostId", "Subject" },
                values: new object[,]
                {
                    { 1, 2, "This is the first comment.", new DateTime(2024, 5, 28, 13, 40, 4, 416, DateTimeKind.Local).AddTicks(7421), 1, "First Comment" },
                    { 2, 1, "This is the second comment.", new DateTime(2024, 5, 28, 13, 40, 4, 416, DateTimeKind.Local).AddTicks(7424), 2, "Second Comment" }
                });

            migrationBuilder.InsertData(
                table: "DemoteAdmins",
                columns: new[] { "Id", "AdminApprovalId", "AdminToDemoteId" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "PostReactions",
                columns: new[] { "Id", "PostId", "ReactionId", "ReactorId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "Id", "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Content", "ImageURL", "IsApproved", "Publication", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "This is the content of the first post.", null, true, new DateTime(2024, 5, 28, 13, 40, 4, 416, DateTimeKind.Local).AddTicks(7179), "First Post" },
                    { 2, 2, 2, "This is the content of the second post.", null, true, new DateTime(2024, 5, 28, 13, 40, 4, 416, DateTimeKind.Local).AddTicks(7236), "Second Post" }
                });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "ImageURL" },
                values: new object[,]
                {
                    { 1, "https://example.com/reaction1.png" },
                    { 2, "https://example.com/reaction2.png" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "FollowerId", "SubbedDate", "SubscriberId", "UnsubbedDate" },
                values: new object[] { 1, 2, new DateTime(2024, 5, 28, 13, 40, 4, 416, DateTimeKind.Local).AddTicks(7493), 1, null });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 1, "EFCore" },
                    { 2, "CSharp" }
                });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeactivated",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeactivated",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeactivated",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeactivated",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeactivated",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsDeactivated",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DemoteAdmins");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "IsDeactivated",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4278cd83-4b6a-4223-8d9b-8109decbb145", "AQAAAAIAAYagAAAAEAx8s+7Poz7uqwvoQfLe5qXXPY6cPUiJ5Xr3w7rpE+BRemaCyw87MUaBRhljs1E/6w==", "67749420-0590-497f-acd5-4b7f4e335d17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f19ad98-7b7a-45fa-b8b4-cb49bd3c5291", "AQAAAAIAAYagAAAAEBJk5lFWF+4pPxD4Lrq19ciNjSSfp8Eb3Q96yq4lao1vRy70bJQvVUYErhmsmsdl/Q==", "ce3d12bf-f049-41a2-aabd-c1e5367b805c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10791a59-12f1-4fc3-9268-020d9ce12a3b", "AQAAAAIAAYagAAAAEAMbo+iFZ3dxo5TomIssrzIIZRm9KPZ2nFXb0xrF3XLlqds3N7vUxa5ubW92Fci4Pg==", "06ba5ab1-c13c-4fac-986a-6c51944e5a41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92b29ed8-cc54-4e71-91c9-248cec8902a9", "AQAAAAIAAYagAAAAEKS99rPKjkl/BaDmDRNcg97VVUM/ag5hkfb9Lm4ZDIGuxCqEaz0mG5oUKa47g7wg2Q==", "d1ea2998-9348-4ee6-a7b1-cd932340a4ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c7f0b5a-ed21-4b19-ab18-b7dfee7f29b3", "AQAAAAIAAYagAAAAEEFOZHnjSrLOHEqWPXwZvINtcOlSd9KM+h4IL7TM55/vWJI9W5InQ3lOO623V/aM8Q==", "e337996b-e40c-44cd-93a9-72b22ee39483" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a8d5608-fd2a-4558-bf14-a2c16539a67b", "AQAAAAIAAYagAAAAEELel2ub99/XsGHepuVshHluHSBv9EU+KNETV3MX6a7+nsA+esE7orngluU3e/go4g==", "6dc997c6-e374-45ae-aa17-e7b1a5fd8068" });
        }
    }
}
