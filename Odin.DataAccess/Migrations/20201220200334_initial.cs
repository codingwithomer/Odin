using Microsoft.EntityFrameworkCore.Migrations;

namespace Odin.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TCIdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "IsDeleted", "LastName", "Phone", "TCIdentityNumber" },
                values: new object[,]
                {
                    { 1, "alibekir.pasaran@nomail.com", "Ali", false, "Pasaran", "05445467893", "17459647263" },
                    { 2, "bekir.terzi@nomail.com", "Bekir", false, "Terzi", "05558254793", "83219547632" },
                    { 3, "mucella.yapici@nomail.com", "Mücella", false, "Yapıcı", "05042561782", "42356178469" },
                    { 4, "viktor.pasaran@nomail.com", "Viktor", false, "Panteleev", "05434587965", "92473156214" },
                    { 5, "jasar.ahmedovski@nomail.com", "Jasar", false, "Ahmedovski", "05321478214", "96573145217" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CustomerId", "Description", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, "Apple'ın gözdesi ayran", false, "IRun", 15m },
                    { 2, null, "Yarının Kısa Bir Tarihi", false, "Homo Deus", 30m },
                    { 3, null, "Dostoyevski", false, "Suç ve Ceza", 27.5m },
                    { 4, null, "Apple'ın gözdesi ayran", false, "IRun", 14.5m },
                    { 5, null, "G3 Laptop For Gamers", false, "Dell", 14500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
