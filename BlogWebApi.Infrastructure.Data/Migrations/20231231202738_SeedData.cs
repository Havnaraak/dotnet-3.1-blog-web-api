using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace BlogWebApi.Infrastructure.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText("../BlogWebApi.Infrastructure.Data/Sql/SeedAuthors.sql"));
            migrationBuilder.Sql(File.ReadAllText("../BlogWebApi.Infrastructure.Data/Sql/SeedPosts.sql"));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText("../BlogWebApi.Infrastructure.Data/Sql/DeleteData.sql"));
        }
    }
}
