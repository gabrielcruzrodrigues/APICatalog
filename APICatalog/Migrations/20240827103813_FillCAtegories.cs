using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    /// <inheritdoc />
    public partial class FillCAtegories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO categories(Name, ImageUrl) VALUES('Drinks','drinks.jpg')");
            mb.Sql("INSERT INTO Categories(Name, ImageUrl) VALUES('Foods','foods.jpg')");
            mb.Sql("INSERT INTO Categories(Name, ImageUrl) VALUES('Desserts','desserts.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categories");
        }
    }
}
