namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImgeUrl = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        
        public override void Down()
        {
            DropTable("dbo.Cakes");
        }
    }
}
