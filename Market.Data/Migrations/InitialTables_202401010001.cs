using FluentMigrator;

namespace Market.Data.Migrations
{
    [Migration(202401010001)]
    public class InitialTables_202401010001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Product");
        }

        public override void Up()
        {
            Create.Table("Product")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(30).NotNullable()
                .WithColumn("Quantity").AsInt32()
                .WithColumn("Price").AsDecimal(19,2).NotNullable();
        }
    }
}
