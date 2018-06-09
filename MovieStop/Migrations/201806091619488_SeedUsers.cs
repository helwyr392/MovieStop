namespace MovieStop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], " +
                "[PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], " +
                "[TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) " +
                "VALUES (N'10f34fbd-ecdd-4294-b483-f8aed4de68a0', N'guest@moviestop.com', 0, " +
                "N'AJcHlQAaHwjiX1QuOA1M0ae25yCEH1sCIDWrs20NWIUqldQpDfk+50kgz/bEN4QDYA==', N'c51a63ff-0137-4a44-a3c4-607f0846d5c7', " +
                "NULL, 0, 0, NULL, 1, 0, N'guest@moviestop.com')");
            Sql("INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], " +
                "[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], " +
                "[AccessFailedCount], [UserName]) VALUES(N'ff2fe9e0-8ac4-4c9a-9d82-c5f4049e2372', N'admin@moviestop.com', " +
                "0, N'AGc7u+lzGtWDbS9c7SMSf3LeIsmo0GhzKEeS1Xfth2aAz+sTWPBZsA2VufAJBx3uvg==', N'8fb90082-a500-488a-8eb0-f845a313c4d1', " +
                "NULL, 0, 0, NULL, 1, 0, N'admin@moviestop.com')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5f97ab6d-490a-4287-81cf-46a6921fd996', N'CanManageMovies')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ff2fe9e0-8ac4-4c9a-9d82-c5f4049e2372', " +
                "N'5f97ab6d-490a-4287-81cf-46a6921fd996')");
        }
        
        public override void Down()
        {
        }
    }
}
