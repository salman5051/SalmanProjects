namespace MoviePass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeNameColumn : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name = 'Pay As You Go' where Id= 1");
            Sql("Update MembershipTypes Set Name = 'Monthly' where Id= 2");
            Sql("Update MembershipTypes Set Name = 'Triply' where Id= 3");
            Sql("Update MembershipTypes Set Name = 'Year' where Id= 4");
            Sql("Update MembershipTypes Set DiscountRate = 15 where Id= 3");
            Sql("Update MembershipTypes Set DiscountRate = 20 where Id= 4");
        }
        
        public override void Down()
        {
        }
    }
}
