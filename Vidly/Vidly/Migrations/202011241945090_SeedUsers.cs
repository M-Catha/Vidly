namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
                VALUES (N'0689e759-4376-4392-bbff-39d052b419b9', N'guest@vidly.com', 0, N'AI0TUr20IIcGlOvhOhO6DsQ2PcBb8gSWeylRwbNy16nJ7caSIsgEa2FTmJIPwkH1eQ==', N'0fe4d5a5-7a0d-4df7-adac-cef7500dd43f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com');

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
                VALUES (N'58bb08ca-f7a8-4c46-b7e4-c32f79ada137', N'admin@vidly.com', 0, N'AJWh5qz2KwMTYCyUseqenC51hRqNPgfcthqV0FTC0GOpzHR3UWc4efjIONmjs9zdIA==', N'cae8f4cf-fce4-47c0-b904-cc183434e37a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com');

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name])
                VALUES (N'5446b616-2578-458d-9dd2-17cfa1532bb2', N'CanManageMovies');

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
                VALUES (N'58bb08ca-f7a8-4c46-b7e4-c32f79ada137', N'5446b616-2578-458d-9dd2-17cfa1532bb2');");
        }
        
        public override void Down()
        {
        }
    }
}
