using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastucture.Persistence.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "NumberPeopleItCanHold",
                table: "Tables",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TableStatusId",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DishCategoryId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DishCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TableStatusId",
                table: "Tables",
                column: "TableStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishCategoryId",
                table: "Dishes",
                column: "DishCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishCategories_DishCategoryId",
                table: "Dishes",
                column: "DishCategoryId",
                principalTable: "DishCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_TableStatuses_TableStatusId",
                table: "Tables",
                column: "TableStatusId",
                principalTable: "TableStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishCategories_DishCategoryId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_TableStatuses_TableStatusId",
                table: "Tables");

            migrationBuilder.DropTable(
                name: "DishCategories");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "TableStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Tables_TableStatusId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_DishCategoryId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "TableStatusId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DishCategoryId",
                table: "Dishes");

            migrationBuilder.AlterColumn<string>(
                name: "NumberPeopleItCanHold",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
