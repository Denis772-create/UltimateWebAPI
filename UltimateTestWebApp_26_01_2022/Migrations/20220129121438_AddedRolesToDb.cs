using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bdb2bfcb-a94a-4f7c-bbc9-c2b6751fdfd2", "b38cb5bb-ad31-40a1-a6a7-e91550ec0a99", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "faae955e-9452-40b2-8462-e298a6604578", "919d2ed9-276c-4794-8fe0-2888f72ae4e2", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdb2bfcb-a94a-4f7c-bbc9-c2b6751fdfd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faae955e-9452-40b2-8462-e298a6604578");
        }
    }
}
