using CodenameFlanker.Data.Entities;
using CodenameFlanker.Data.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodenameFlanker.Data.Migrations
{
    /// <inheritdoc />
    public partial class insertdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			List<Artist> artists = InitialDataParser.ParseSection<Artist>("Artists");
			foreach (var artist in artists)
			{
				migrationBuilder.Sql(@$"INSERT INTO Artist (Id, Name, Icon, Role)
										VALUES ({artist.Id}, '{artist.Name}', '{artist.Icon}', '{artist.Role}')");
			}

			List<Artwork> artworks = InitialDataParser.ParseSection<Artwork>("Artworks");
			foreach (Artwork artwork in artworks)
			{
				migrationBuilder.Sql(@$"INSERT INTO Artwork (Id, Name, Thumbnail, ArtistId, Description)
										VALUES ({artwork.Id}, '{artwork.Name}', '{artwork.Thumbnail}', '{artwork.ArtistId}','{artwork.Description}')");
				foreach (Image image in artwork.Images)
				{
					migrationBuilder.Sql(@$"INSERT INTO Image (Path, Description, ArtworkId)
											VALUES ('{image.Path}', '{image.Description}', {artwork.Id})");
				}
			}

			List<Patchnote> patchnotes = InitialDataParser.ParseSection<Patchnote>("Patchnotes");
			foreach (Patchnote patchnote in patchnotes)
			{
				migrationBuilder.Sql(@$"INSERT INTO Patchnote (Id, Version)
										VALUES ({patchnote.Id}, '{patchnote.Version}')");
				foreach(PatchnoteChange patchnoteChange in patchnote.PatchnoteChanges)
				{
					migrationBuilder.Sql(@$"INSERT INTO PatchnoteChange (Name, Change, PatchnoteId)
										VALUES ('{patchnoteChange.Name}', '{patchnoteChange.Change}', {patchnote.Id})");
				}
			}
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
