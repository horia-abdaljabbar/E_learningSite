using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29246ac3-7156-4c56-9dab-d168657ea7f2", null, "User", "USER" },
                    { "94bbcc61-346f-4014-9a7f-1d47302f4476", null, "SuperAdmin", "SUPERADMIN" },
                    { "dda8ec01-2ff5-4cf6-bd09-f29de6beb11a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "46a1f9b0-d69c-4eda-b30f-2052d6b26c71", 0, null, "49bfc236-66dd-404e-80ed-e70503e2de93", "user@Elearning.com", true, null, false, null, "USER@ELEARNING.COM", "USER@ELEARNING.COM", "AQAAAAIAAYagAAAAEI2cTPA+aa14Lg3Xaf9oquDP8VGRk4R94msqJvPtimJBPPfRhsM+3j//tK6eqCclRw==", null, false, "a437992f-d843-40ce-a209-6df14f901c7e", false, "user@Elearning.com" },
                    { "78d56371-918f-4022-81b3-30f73a87b3c6", 0, null, "cdcd5782-11c9-4ea6-9875-0c46c29be8b5", "admin@Elearning.com", true, null, false, null, "ADMIN@ELEARNING.COM", "ADMIN@ELEARNING.COM", "AQAAAAIAAYagAAAAEMkm5SO85W+82j0EYsgQR5TNjS/36hoFotbsfQZ6FUhV4B4Nrlrq2HB0DKcj0GRbTg==", null, false, "10ee3cc4-ddc1-435b-aedd-8ad1a9e9f505", false, "admin@Elearning.com" },
                    { "a8d2a2b4-6343-4dc3-90b0-86c6ef6bfdb0", 0, null, "616a5347-4dc1-4375-8997-e13d85264315", "superAdmin@Elearning.com", true, null, false, null, "SUPERADMIN@ELEARNING.COM", "SUPERADMIN@ELEARNING.COM", "AQAAAAIAAYagAAAAEPsGgFic6nGtGUsdG0kqs6sjy6IPxyjdTJcDudPoyqrYdnh4qiSQ3QSc2+9qzC3Z5Q==", null, false, "e4b5b8fe-c649-415d-8a38-0d9d2e4ef9b0", false, "superAdmin@Elearning.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "29246ac3-7156-4c56-9dab-d168657ea7f2", "46a1f9b0-d69c-4eda-b30f-2052d6b26c71" },
                    { "dda8ec01-2ff5-4cf6-bd09-f29de6beb11a", "78d56371-918f-4022-81b3-30f73a87b3c6" },
                    { "94bbcc61-346f-4014-9a7f-1d47302f4476", "a8d2a2b4-6343-4dc3-90b0-86c6ef6bfdb0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29246ac3-7156-4c56-9dab-d168657ea7f2", "46a1f9b0-d69c-4eda-b30f-2052d6b26c71" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dda8ec01-2ff5-4cf6-bd09-f29de6beb11a", "78d56371-918f-4022-81b3-30f73a87b3c6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94bbcc61-346f-4014-9a7f-1d47302f4476", "a8d2a2b4-6343-4dc3-90b0-86c6ef6bfdb0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29246ac3-7156-4c56-9dab-d168657ea7f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94bbcc61-346f-4014-9a7f-1d47302f4476");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dda8ec01-2ff5-4cf6-bd09-f29de6beb11a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46a1f9b0-d69c-4eda-b30f-2052d6b26c71");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78d56371-918f-4022-81b3-30f73a87b3c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8d2a2b4-6343-4dc3-90b0-86c6ef6bfdb0");
        }
    }
}
