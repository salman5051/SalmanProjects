namespace MoviePass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMovieModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
    }
}
