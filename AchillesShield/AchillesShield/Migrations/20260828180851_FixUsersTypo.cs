using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AchillesShield.Migrations
{
    /// <inheritdoc />
    public partial class FixUsersTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_Usres_UserId",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Usres_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Usres_AssignedUserId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Usres_Roles_RoleId",
                table: "Usres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usres",
                table: "Usres");

            migrationBuilder.RenameTable(
                name: "Usres",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Usres_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_Users_UserId",
                table: "AuditLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Users_AssignedUserId",
                table: "Incidents",
                column: "AssignedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_Users_UserId",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Users_AssignedUserId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Usres");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Usres",
                newName: "IX_Usres_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usres",
                table: "Usres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_Usres_UserId",
                table: "AuditLogs",
                column: "UserId",
                principalTable: "Usres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Usres_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Usres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Usres_AssignedUserId",
                table: "Incidents",
                column: "AssignedUserId",
                principalTable: "Usres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usres_Roles_RoleId",
                table: "Usres",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
