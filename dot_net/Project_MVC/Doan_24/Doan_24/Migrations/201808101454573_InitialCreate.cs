namespace Doan_24.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Levels = c.Int(),
                        Status = c.Boolean(),
                        CreateDate = c.DateTime(storeType: "date"),
                        TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(storeType: "ntext"),
                        Email = c.String(maxLength: 50),
                        Title = c.String(maxLength: 200),
                        Content = c.String(storeType: "ntext"),
                        DateSent = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        NameCus = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Adress = c.String(storeType: "ntext"),
                        Sex = c.String(maxLength: 10),
                        Birthday = c.DateTime(storeType: "date"),
                        CreateDate = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                        Account = c.String(maxLength: 40),
                        Password = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Manufactures",
                c => new
                    {
                        ManufacturesID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Adress = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ManufacturesID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(),
                        ProductID = c.Int(),
                        Quantity = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        DateSet = c.DateTime(storeType: "date"),
                        DeliveryDate = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Product_Image",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        Images = c.String(maxLength: 100),
                        Images_Thum = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        MetaTitle = c.String(storeType: "ntext"),
                        NameProduct = c.String(storeType: "ntext"),
                        Price = c.Decimal(precision: 18, scale: 2),
                        PriceNews = c.Decimal(precision: 18, scale: 2),
                        ManufacturesID = c.Int(),
                        ImagesMain = c.String(maxLength: 100),
                        DienAp = c.String(maxLength: 10),
                        LedChip = c.String(maxLength: 50),
                        Quantity = c.Int(),
                        TuoiTho = c.String(maxLength: 50),
                        QuangThong = c.String(maxLength: 10),
                        HeSoCRI = c.String(maxLength: 10),
                        NhietDoMau = c.String(maxLength: 10),
                        GocMo = c.String(maxLength: 10),
                        DoKin = c.String(maxLength: 10),
                        NhietDoLamViec = c.String(storeType: "ntext"),
                        HeSoCongSuat = c.String(maxLength: 10),
                        VatLieu = c.String(maxLength: 10),
                        Content = c.String(storeType: "ntext"),
                        Warranty = c.Int(),
                        UserID = c.Int(),
                        CreateDate = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        NameRole = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Account = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Products");
            DropTable("dbo.Product_Image");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Manufactures");
            DropTable("dbo.Customers");
            DropTable("dbo.Contacts");
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.Categories");
        }
    }
}
