using CodenameFlanker.Data.Entities;
using CodenameFlanker.Data.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable disable

namespace CodenameFlanker.Data.Migrations
{
    /// <inheritdoc />
    public partial class insertdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<Artwork> artworks = InitialDataParser.ParseSection<Artwork>("Artworks");

            foreach (Artwork artwork in artworks) 
            {
				Console.WriteLine(artwork.Id);
				Console.WriteLine(artwork.Name);
				Console.WriteLine(artwork.Thumbnail);
				Console.WriteLine(artwork.Description);
			}

			//migrationBuilder.Sql(@"INSERT INTO Artwork (Id, Name, Thumbnail)
			//                              VALUES (1, 'R-27T', 'R-27T_3.jpg')");

			//migrationBuilder.Sql(@"INSERT INTO Image (Path, Description, ArtworkId)
			//                              VALUES ('R-27T_3.jpg', '', 1)");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
