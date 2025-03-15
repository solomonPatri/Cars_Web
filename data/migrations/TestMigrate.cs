using Cars_Web.cars;
using FluentMigrator;


namespace Cars_Web.data.migrations
{
    [Migration(120320252)]
    public class TestMigrate:Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }
        public override void Up()
        {
            Execute.Script("data/scripts/data.sql");
        }









    }
}
