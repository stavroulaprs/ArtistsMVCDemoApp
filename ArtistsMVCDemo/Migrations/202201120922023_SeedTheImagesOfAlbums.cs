namespace ArtistsMVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTheImagesOfAlbums : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Albums SET Thumbnail = 'na_image.jpg'");
        }
        
        public override void Down()
        {
            Sql("UPDATE Albums SET Thumbnail = ''");
        }
    }
}
