using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentReport.Migrations
{
    /// <inheritdoc />
    public partial class ModelsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountContact");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ContactId",
                table: "Accounts",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Contacts_ContactId",
                table: "Accounts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Contacts_ContactId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ContactId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "AccountContact",
                columns: table => new
                {
                    AccountsId = table.Column<int>(type: "int", nullable: false),
                    ContactsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountContact", x => new { x.AccountsId, x.ContactsId });
                    table.ForeignKey(
                        name: "FK_AccountContact_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountContact_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_ContactsId",
                table: "AccountContact",
                column: "ContactsId");
        }
    }
}
