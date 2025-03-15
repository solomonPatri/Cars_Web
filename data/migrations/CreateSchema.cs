using FluentMigrator;
using Microsoft.OpenApi.Services;


namespace Cars_Web.data.migrations
{
    [Migration(120320251)]
    public class CreateSchema:Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }


        public override void Up()
        {

            Create.Table("cars")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Brand").AsString(120).NotNullable()
                .WithColumn("Model").AsString(120).NotNullable()
                .WithColumn("Color").AsString(120).NotNullable()
                .WithColumn("Year").AsInt32().NotNullable();

            






        }
















    }
}
