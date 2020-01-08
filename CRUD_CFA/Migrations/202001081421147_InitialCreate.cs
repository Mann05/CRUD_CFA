namespace CRUD_CFA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentDetail",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentDetail");
        }
    }
}
