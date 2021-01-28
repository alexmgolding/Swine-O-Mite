namespace SwineOMite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectCleanup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompleteIngredient",
                c => new
                    {
                        CompleteIngredientId = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                        QuantityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompleteIngredientId)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.IngredientQuantity", t => t.QuantityId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.QuantityId);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.IngredientQuantity",
                c => new
                    {
                        QuantityId = c.Int(nullable: false, identity: true),
                        IngredientAmount = c.Int(nullable: false),
                        MeasurementUnit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuantityId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        RecipeOwner = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        RecipeTitle = c.String(),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.Direction",
                c => new
                    {
                        DirectionId = c.Int(nullable: false, identity: true),
                        StepNumber = c.Int(nullable: false),
                        Instructions = c.String(nullable: false),
                        Recipe_RecipeId = c.Int(),
                    })
                .PrimaryKey(t => t.DirectionId)
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeId)
                .Index(t => t.Recipe_RecipeId);
            
            CreateTable(
                "dbo.SmokingWoodQuantity",
                c => new
                    {
                        SmokingWoodQuantityId = c.Int(nullable: false, identity: true),
                        WoodQuantityId = c.Int(nullable: false),
                        SmokingWoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SmokingWoodQuantityId)
                .ForeignKey("dbo.SmokingWood", t => t.SmokingWoodId, cascadeDelete: true)
                .ForeignKey("dbo.WoodQuantity", t => t.WoodQuantityId, cascadeDelete: true)
                .Index(t => t.WoodQuantityId)
                .Index(t => t.SmokingWoodId);
            
            CreateTable(
                "dbo.SmokingWood",
                c => new
                    {
                        SmokingWoodId = c.Int(nullable: false, identity: true),
                        WoodSpecies = c.Int(nullable: false),
                        WoodVariety = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SmokingWoodId);
            
            CreateTable(
                "dbo.WoodQuantity",
                c => new
                    {
                        WoodQuantityId = c.Int(nullable: false, identity: true),
                        WoodAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WoodQuantityId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.RecipeCompleteIngredient",
                c => new
                    {
                        Recipe = c.Int(nullable: false),
                        CompleteIngredient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe, t.CompleteIngredient })
                .ForeignKey("dbo.Recipe", t => t.Recipe, cascadeDelete: true)
                .ForeignKey("dbo.CompleteIngredient", t => t.CompleteIngredient, cascadeDelete: true)
                .Index(t => t.Recipe)
                .Index(t => t.CompleteIngredient);
            
            CreateTable(
                "dbo.SmokingWoodQuantityRecipe",
                c => new
                    {
                        SmokingWoodQuantity_SmokingWoodQuantityId = c.Int(nullable: false),
                        Recipe_RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SmokingWoodQuantity_SmokingWoodQuantityId, t.Recipe_RecipeId })
                .ForeignKey("dbo.SmokingWoodQuantity", t => t.SmokingWoodQuantity_SmokingWoodQuantityId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeId, cascadeDelete: true)
                .Index(t => t.SmokingWoodQuantity_SmokingWoodQuantityId)
                .Index(t => t.Recipe_RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.SmokingWoodQuantity", "WoodQuantityId", "dbo.WoodQuantity");
            DropForeignKey("dbo.SmokingWoodQuantity", "SmokingWoodId", "dbo.SmokingWood");
            DropForeignKey("dbo.SmokingWoodQuantityRecipe", "Recipe_RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.SmokingWoodQuantityRecipe", "SmokingWoodQuantity_SmokingWoodQuantityId", "dbo.SmokingWoodQuantity");
            DropForeignKey("dbo.Direction", "Recipe_RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.RecipeCompleteIngredient", "CompleteIngredient", "dbo.CompleteIngredient");
            DropForeignKey("dbo.RecipeCompleteIngredient", "Recipe", "dbo.Recipe");
            DropForeignKey("dbo.CompleteIngredient", "QuantityId", "dbo.IngredientQuantity");
            DropForeignKey("dbo.CompleteIngredient", "IngredientId", "dbo.Ingredient");
            DropIndex("dbo.SmokingWoodQuantityRecipe", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.SmokingWoodQuantityRecipe", new[] { "SmokingWoodQuantity_SmokingWoodQuantityId" });
            DropIndex("dbo.RecipeCompleteIngredient", new[] { "CompleteIngredient" });
            DropIndex("dbo.RecipeCompleteIngredient", new[] { "Recipe" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.SmokingWoodQuantity", new[] { "SmokingWoodId" });
            DropIndex("dbo.SmokingWoodQuantity", new[] { "WoodQuantityId" });
            DropIndex("dbo.Direction", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.CompleteIngredient", new[] { "QuantityId" });
            DropIndex("dbo.CompleteIngredient", new[] { "IngredientId" });
            DropTable("dbo.SmokingWoodQuantityRecipe");
            DropTable("dbo.RecipeCompleteIngredient");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.WoodQuantity");
            DropTable("dbo.SmokingWood");
            DropTable("dbo.SmokingWoodQuantity");
            DropTable("dbo.Direction");
            DropTable("dbo.Recipe");
            DropTable("dbo.IngredientQuantity");
            DropTable("dbo.Ingredient");
            DropTable("dbo.CompleteIngredient");
        }
    }
}
