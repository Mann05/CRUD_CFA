namespace CRUD_CFA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId);
            
            AddColumn("dbo.StudentDetail", "ClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentDetail", "ClassId");
            AddForeignKey("dbo.StudentDetail", "ClassId", "dbo.Class", "ClassId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetail", "ClassId", "dbo.Class");
            DropIndex("dbo.StudentDetail", new[] { "ClassId" });
            DropColumn("dbo.StudentDetail", "ClassId");
            DropTable("dbo.Class");
        }
    }
}
