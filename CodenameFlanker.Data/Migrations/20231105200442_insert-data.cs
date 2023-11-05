﻿using CodenameFlanker.Data.Entities;
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
			List<Artwork> artworks = InitialDataParser.ParseSection<Artwork>("Artworks");

			foreach (Artwork artwork in artworks)
			{
				migrationBuilder.Sql(@$"INSERT INTO Artwork (Id, Name, Thumbnail, Description)
										VALUES ({artwork.Id}, '{artwork.Name}', '{artwork.Thumbnail}', '')");
				foreach (Image image in artwork.Images)
				{
					migrationBuilder.Sql(@$"INSERT INTO Image (Path, Description, ArtworkId)
											VALUES ('{image.Path}', '{image.Description}', {artwork.Id})");
				}
			}
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
