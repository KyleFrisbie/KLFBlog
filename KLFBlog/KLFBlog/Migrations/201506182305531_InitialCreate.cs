namespace KLFBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Date = c.String(),
                        Image = c.String(),
                        PostBody = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Date = c.String(),
                        Image = c.String(),
                        PostBody = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagBlogPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        BlogPost_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.BlogPost_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPost_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.BlogPost_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.TagBlogPosts", "BlogPost_Id", "dbo.BlogPosts");
            DropForeignKey("dbo.TagBlogPosts", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagBlogPosts", new[] { "BlogPost_Id" });
            DropIndex("dbo.TagBlogPosts", new[] { "Tag_Id" });
            DropIndex("dbo.Tags", new[] { "Project_Id" });
            DropTable("dbo.TagBlogPosts");
            DropTable("dbo.Projects");
            DropTable("dbo.Tags");
            DropTable("dbo.BlogPosts");
        }
    }
}
