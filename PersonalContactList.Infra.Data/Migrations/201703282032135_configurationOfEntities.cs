namespace PersonalContactList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configurationOfEntities : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Contacts", newName: "Contact");
            DropIndex("dbo.Contact", new[] { "CategoryId_CategoryID" });
            RenameColumn(table: "dbo.Contact", name: "CategoryId_CategoryID", newName: "CategoryId");
            AddColumn("dbo.Contact", "Name", c => c.String(nullable: false, maxLength: 80, unicode: false));
            AddColumn("dbo.Contact", "KnownAs", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Emails_EmailA", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Emails_EmailB", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Numbers_TelNumberA", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Numbers_TelNumberB", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Social_Facebook", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Social_Instagran", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Social_Twiiter", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Social_Whatsapp", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "Social_Linkedin", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Contact", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contact", "CategoryId");
            DropColumn("dbo.Contact", "CodeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "CodeName", c => c.String());
            DropIndex("dbo.Contact", new[] { "CategoryId" });
            AlterColumn("dbo.Contact", "CategoryId", c => c.Int());
            AlterColumn("dbo.Contact", "Social_Linkedin", c => c.String());
            AlterColumn("dbo.Contact", "Social_Whatsapp", c => c.String());
            AlterColumn("dbo.Contact", "Social_Twiiter", c => c.String());
            AlterColumn("dbo.Contact", "Social_Instagran", c => c.String());
            AlterColumn("dbo.Contact", "Social_Facebook", c => c.String());
            AlterColumn("dbo.Contact", "Numbers_TelNumberB", c => c.String());
            AlterColumn("dbo.Contact", "Numbers_TelNumberA", c => c.String());
            AlterColumn("dbo.Contact", "Emails_EmailB", c => c.String());
            AlterColumn("dbo.Contact", "Emails_EmailA", c => c.String());
            AlterColumn("dbo.Category", "CategoryName", c => c.String());
            DropColumn("dbo.Contact", "KnownAs");
            DropColumn("dbo.Contact", "Name");
            RenameColumn(table: "dbo.Contact", name: "CategoryId", newName: "CategoryId_CategoryID");
            CreateIndex("dbo.Contact", "CategoryId_CategoryID");
            RenameTable(name: "dbo.Contact", newName: "Contacts");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
