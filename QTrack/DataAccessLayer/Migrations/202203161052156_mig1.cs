namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        COMPANYID = c.Int(nullable: false, identity: true),
                        CNAME = c.String(),
                        CADDRESS = c.String(),
                        CPHONE = c.String(),
                        CPERSON = c.String(),
                        CDOMAIN = c.String(),
                        CSTATUS = c.Boolean(nullable: false),
                        COUNTRY = c.String(),
                        COTHER = c.String(),
                    })
                .PrimaryKey(t => t.COMPANYID);
            
            CreateTable(
                "dbo.QRs",
                c => new
                    {
                        QRID = c.Int(nullable: false, identity: true),
                        COMPANYID = c.Int(),
                        PRODUCTID = c.Int(),
                        QRCODE = c.String(),
                        QRSTATUS = c.Boolean(nullable: false),
                        OTHER = c.String(),
                        FACTORYDATE = c.DateTime(),
                        FILLDATE = c.DateTime(),
                        REFILLDATE = c.DateTime(),
                        EXPDATE = c.DateTime(),
                    })
                .PrimaryKey(t => t.QRID)
                .ForeignKey("dbo.Companies", t => t.COMPANYID)
                .ForeignKey("dbo.Products", t => t.PRODUCTID)
                .Index(t => t.COMPANYID)
                .Index(t => t.PRODUCTID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        PRODUCTID = c.Int(nullable: false, identity: true),
                        PTYPEID = c.Int(nullable: false),
                        PNAME = c.String(),
                        SERIAL = c.String(),
                        POTHER = c.String(),
                        PCAPACITY = c.String(),
                        LOCATION = c.String(),
                        PSTATUS = c.Boolean(nullable: false),
                        MANUDATE = c.DateTime(),
                    })
                .PrimaryKey(t => t.PRODUCTID)
                .ForeignKey("dbo.ProductTypes", t => t.PTYPEID, cascadeDelete: true)
                .Index(t => t.PTYPEID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        PTYPEID = c.Int(nullable: false, identity: true),
                        PTYPE = c.String(),
                    })
                .PrimaryKey(t => t.PTYPEID);
            
            CreateTable(
                "dbo.QRHistories",
                c => new
                    {
                        REFID = c.Int(nullable: false, identity: true),
                        QRID = c.Int(nullable: false),
                        OPERATION = c.String(),
                        OPERATIONDATE = c.DateTime(),
                    })
                .PrimaryKey(t => t.REFID)
                .ForeignKey("dbo.QRs", t => t.QRID, cascadeDelete: true)
                .Index(t => t.QRID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        USERID = c.Int(nullable: false, identity: true),
                        USERNAME = c.String(),
                        PASSWORD = c.String(),
                        USERTYPE = c.String(),
                        USERSTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.USERID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QRHistories", "QRID", "dbo.QRs");
            DropForeignKey("dbo.QRs", "PRODUCTID", "dbo.Products");
            DropForeignKey("dbo.Products", "PTYPEID", "dbo.ProductTypes");
            DropForeignKey("dbo.QRs", "COMPANYID", "dbo.Companies");
            DropIndex("dbo.QRHistories", new[] { "QRID" });
            DropIndex("dbo.Products", new[] { "PTYPEID" });
            DropIndex("dbo.QRs", new[] { "PRODUCTID" });
            DropIndex("dbo.QRs", new[] { "COMPANYID" });
            DropTable("dbo.Users");
            DropTable("dbo.QRHistories");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.QRs");
            DropTable("dbo.Companies");
        }
    }
}
