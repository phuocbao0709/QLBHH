namespace Doan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BestSale",
                c => new
                    {
                        IDPro = c.Long(nullable: false, identity: true),
                        NamePro = c.String(maxLength: 250),
                        Image = c.String(maxLength: 250),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Discriminator1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IDPro);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        IDProduct = c.Long(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 250),
                        MetaTitle = c.String(),
                        Description = c.String(),
                        Image = c.String(maxLength: 250),
                        MoreImage1 = c.String(maxLength: 250),
                        MoreImage2 = c.String(maxLength: 250),
                        MoreImage3 = c.String(maxLength: 250),
                        Price = c.Decimal(precision: 18, scale: 0),
                        Entryprice = c.Decimal(precision: 18, scale: 0),
                        PromotionPrice = c.Decimal(precision: 18, scale: 0),
                        IncludedVAT = c.Boolean(),
                        Quantity = c.Int(),
                        CategoryID = c.Long(),
                        SupplierID = c.Long(),
                        Detail = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        Status = c.String(maxLength: 25, fixedLength: true),
                    })
                .PrimaryKey(t => t.IDProduct)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID)
                .Index(t => t.CategoryID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        QuantitySale = c.Int(),
                        IDOrder = c.Long(),
                        IDProduct = c.Long(),
                        UnitPriceSale = c.Decimal(precision: 18, scale: 0),
                        CreadeDay = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.IDOrder)
                .ForeignKey("dbo.Product", t => t.IDProduct)
                .Index(t => t.IDOrder)
                .Index(t => t.IDProduct);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        IDOrder = c.Long(nullable: false, identity: true),
                        OrderDate = c.DateTime(),
                        Descriptions = c.String(maxLength: 500),
                        CodeCus = c.Long(),
                        Email_Cus = c.String(maxLength: 150),
                        Password_cus = c.String(maxLength: 50, unicode: false),
                        SDT_Cus = c.String(maxLength: 25, fixedLength: true),
                    })
                .PrimaryKey(t => t.IDOrder)
                .ForeignKey("dbo.Customer", t => t.CodeCus)
                .Index(t => t.CodeCus);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CodeCus = c.Long(nullable: false, identity: true),
                        IDCus = c.Long(nullable: false),
                        Email_Cus = c.String(maxLength: 150),
                        Address_Cus = c.String(maxLength: 200),
                        Phone_Cus = c.String(maxLength: 15, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        FirstName = c.String(maxLength: 10, fixedLength: true),
                        LastName = c.String(maxLength: 10, fixedLength: true),
                        CreatedDay = c.DateTime(),
                        ModifiedDay = c.DateTime(),
                    })
                .PrimaryKey(t => t.CodeCus);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierID = c.Long(nullable: false, identity: true),
                        SupplierName = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        IdContact = c.Long(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 10, fixedLength: true),
                        LastName = c.String(maxLength: 10, fixedLength: true),
                        Email = c.String(maxLength: 10, fixedLength: true),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.IdContact);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Address = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Logo = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 250),
                        Link = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Target = c.String(maxLength: 50),
                        Status = c.Boolean(),
                        TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 25, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        IdPro = c.Long(nullable: false, identity: true),
                        NamePro = c.String(maxLength: 250),
                        Image = c.String(maxLength: 250),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => t.IdPro);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Link = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(storeType: "date"),
                        ModifiedBy = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IDUser = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(unicode: false),
                        ConfirmPassword = c.String(nullable: false),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        Status = c.Boolean(),
                        IdRole = c.Long(),
                    })
                .PrimaryKey(t => t.IDUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.OrderDetail", "IDProduct", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "IDOrder", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CodeCus", "dbo.Customer");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Orders", new[] { "CodeCus" });
            DropIndex("dbo.OrderDetail", new[] { "IDProduct" });
            DropIndex("dbo.OrderDetail", new[] { "IDOrder" });
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropTable("dbo.User");
            DropTable("dbo.Slide");
            DropTable("dbo.Sale");
            DropTable("dbo.Role");
            DropTable("dbo.MenuType");
            DropTable("dbo.Menu");
            DropTable("dbo.Footer");
            DropTable("dbo.Contact");
            DropTable("dbo.Supplier");
            DropTable("dbo.Customer");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            DropTable("dbo.BestSale");
        }
    }
}
