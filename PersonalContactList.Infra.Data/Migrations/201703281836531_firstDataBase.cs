namespace PersonalContactList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        EspecialCategory = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContatId = c.Int(nullable: false, identity: true),
                        CodeName = c.String(),
                        Emails_EmailA = c.String(),
                        Emails_EmailB = c.String(),
                        Numbers_TelNumberA = c.String(),
                        Numbers_TelNumberB = c.String(),
                        Social_Facebook = c.String(),
                        Social_Instagran = c.String(),
                        Social_Twiiter = c.String(),
                        Social_Whatsapp = c.String(),
                        Social_Linkedin = c.String(),
                        CategoryId_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ContatId)
                .ForeignKey("dbo.Categories", t => t.CategoryId_CategoryID)
                .Index(t => t.CategoryId_CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "CategoryId_CategoryID", "dbo.Categories");
            DropIndex("dbo.Contacts", new[] { "CategoryId_CategoryID" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
        }
    }
}
