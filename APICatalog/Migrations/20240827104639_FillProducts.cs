using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    /// <inheritdoc />
    public partial class FillProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                    "VALUES('Coca-cola Diet','Refrigerante de Cola 350ml','5.45','cocacola.jpg',50,now(),1)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                    "VALUES('Pepsi','Refrigerante de Cola 350ml','4.99','pepsi.jpg',40,now(),1)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Sprite','Refrigerante Limão 350ml','5.00','sprite.jpg',60,now(),1)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Fanta Laranja','Refrigerante de Laranja 350ml','4.75','fanta_laranja.jpg',45,now(),1)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Guaraná Antarctica','Refrigerante de Guaraná 350ml','5.10','guarana_antarctica.jpg',55,now(),1)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Heineken','Cerveja 330ml','7.50','heineken.jpg',30,now(),2)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Sanduíche de Frango','Sanduíche de frango grelhado com alface e tomate','12.90','sanduiche_frango.jpg',20,now(),2)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Hambúrguer Clássico','Hambúrguer com queijo, alface, tomate e maionese','15.50','hamburguer_classico.jpg',25,now(),2)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Coxinha de Frango','Coxinha de frango empanada e frita','3.50','coxinha_frango.jpg',50,now(),2)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Pão de Queijo','Pão de queijo tradicional','2.00','pao_queijo.jpg',100,now(),2)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Croissant de Presunto e Queijo','Croissant recheado com presunto e queijo','8.00','croissant_presunto_queijo.jpg',30,now(),2)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Bolo de Chocolate','Bolo de chocolate com cobertura cremosa','6.50','bolo_chocolate.jpg',20,now(),3)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Pudim de Leite','Pudim de leite condensado','4.00','pudim_leite.jpg',30,now(),3)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Torta de Limão','Torta de limão com base crocante','5.75','torta_limao.jpg',15,now(),3)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Sorvete de Morango','Sorvete artesanal de morango','3.50','sorvete_morango.jpg',40,now(),3)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Amount, CreateAt, CategoryId) " +
                   "VALUES('Mousse de Maracujá','Mousse de maracujá com cobertura de chocolate','4.25','mousse_maracuja.jpg',25,now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
