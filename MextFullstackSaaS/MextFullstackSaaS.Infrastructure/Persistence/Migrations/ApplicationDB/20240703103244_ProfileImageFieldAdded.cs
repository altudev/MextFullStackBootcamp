using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullstackSaaS.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class ProfileImageFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfileImage" },
                values: new object[] { "05ba3921-48f4-497d-9286-2000f66ecf2f", "AQAAAAIAAYagAAAAEIWZX5VGR9dguRjsMFQCVH6NNaxO5f7PPnO47fNKpbpI6FZB7WtO5iSH0eREy/gatw==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c981ce68-b38e-48f7-b342-ed9dffb51072", "AQAAAAIAAYagAAAAEA5Q6MqF0wbKywatFFhRUtEmzw8uwW7M61/xcEOBrp9/G01wQJYZgkTqBCFz3fE5sw==" });
        }
    }
}
