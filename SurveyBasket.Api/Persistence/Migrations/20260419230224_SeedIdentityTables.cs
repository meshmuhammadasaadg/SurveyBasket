using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyBasket.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "D6951876-E125-4896-A4A6-D2C31B89CBC0", "D6951876-E125-4896-A4A6-D2C31B89CBC0", false, false, "Admin", "ADMIN" },
                    { "F7A1234B-C456-7890-D123-E45F67890ABC", "F7A1234B-C456-7890-D123-E45F67890ABC", true, false, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "A1B2C3D4-E5F6-7890-ABCD-EF1234567890", 0, "A1B2C3D4E5F67890ABCDEF1234567890", "admin@surveybasket.com", true, "Muhammad", "Asaad", false, null, "ADMIN@SURVEYBASKET.COM", "ADMIN@SURVEYBASKET.COM", "AQAAAAIAAYagAAAAELTBMSaom3U7o1sXnbkVgZUYbwtWeZdqQOvpIP71BBpUK9J7wHhW7ZviRQbkmXKIOg==", null, false, "A1B2C3D4-E5F6-7890-ABCD-EF1234567890", false, "admin@surveybasket.com" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permissions", "polls:read", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 2, "Permissions", "polls:Create", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 3, "Permissions", "polls:Delete", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 4, "Permissions", "polls:Edit", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 5, "Permissions", "questions:read", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 6, "Permissions", "questions:Create", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 7, "Permissions", "questions:Edit", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 8, "Permissions", "users:read", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 9, "Permissions", "users:Create", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 10, "Permissions", "users:Edit", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 11, "Permissions", "roles:read", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 12, "Permissions", "roles:Create", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 13, "Permissions", "roles:Edit", "D6951876-E125-4896-A4A6-D2C31B89CBC0" },
                    { 14, "Permissions", "results:read", "D6951876-E125-4896-A4A6-D2C31B89CBC0" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "D6951876-E125-4896-A4A6-D2C31B89CBC0", "A1B2C3D4-E5F6-7890-ABCD-EF1234567890" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F7A1234B-C456-7890-D123-E45F67890ABC");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "D6951876-E125-4896-A4A6-D2C31B89CBC0", "A1B2C3D4-E5F6-7890-ABCD-EF1234567890" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D6951876-E125-4896-A4A6-D2C31B89CBC0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A1B2C3D4-E5F6-7890-ABCD-EF1234567890");
        }
    }
}
