using CodenameFlanker.Data.Entities;
using CodenameFlanker.Data.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;


#nullable disable

namespace CodenameFlanker.Data.Migrations
{
    /// <inheritdoc />
    public partial class insertdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			string jsonFile = "initialData.json";

			List<Artist> artists = JsonParser.ParseSection<Artist>("Artists", jsonFile);
			foreach (var artist in artists)
			{
				migrationBuilder.Sql(@$"INSERT INTO Artist (Id, Name, Icon, Role)
										VALUES ({artist.Id}, '{artist.Name}', '{artist.Icon}', '{artist.Role}')");
			}

			List<Artwork> artworks = JsonParser.ParseSection<Artwork>("Artworks", jsonFile);
			foreach (Artwork artwork in artworks)
			{
				string anchor = "https://";
				string anchorEnd = " ";
				if (artwork.Description.Contains(anchor))
				{
					string anchorPart = $"{anchor}{artwork.Description
						.Split(anchor)
						.Last()
						.Split(anchorEnd)
						.First()}";
					artwork.Description = artwork.Description.Replace(anchorPart, $"<a className=''link-primary'' target=''_blank'' href=''{anchorPart}''>{anchorPart}</a>");
				}

				migrationBuilder.Sql(@$"INSERT INTO Artwork (Id, Name, Thumbnail, ArtistId, Description)
										VALUES ({artwork.Id}, '{artwork.Name}', '{artwork.Thumbnail}', '{artwork.ArtistId}','{artwork.Description}')");
				foreach (Image image in artwork.Images)
				{
					migrationBuilder.Sql(@$"INSERT INTO Image (Path, Description, ArtworkId)
											VALUES ('{image.Path}', '{image.Description}', {artwork.Id})");
				}
			}

			List<Patchnote> patchnotes = JsonParser.ParseSection<Patchnote>("Patchnotes", jsonFile);
			foreach (Patchnote patchnote in patchnotes)
			{
				migrationBuilder.Sql(@$"INSERT INTO Patchnote (Id, Version)
										VALUES ({patchnote.Id}, '{patchnote.Version}')");
				foreach (PatchnoteChange patchnoteChange in patchnote.PatchnoteChanges)
				{
					migrationBuilder.Sql(@$"INSERT INTO PatchnoteChange (Name, Change, PatchnoteId)
										VALUES ('{patchnoteChange.Name}', '{patchnoteChange.Change}', {patchnote.Id})");
				}
			}

			List<Screenshot> screenshots = JsonParser.ParseSection<Screenshot>("Screenshots", jsonFile);
			foreach (Screenshot screenshot in screenshots)
			{
				migrationBuilder.Sql(@$"INSERT INTO Screenshot (Path, Thumbnail)
										VALUES ('{screenshot.Path}', '{screenshot.Thumbnail}')");
			}
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
